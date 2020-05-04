using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;

namespace ConcurrentCollections
{
    class Program
    {
        public class RemoteBookStore
        {
            public static readonly List<string> Books = 
                new List<string>{"Book1", "Book2", "Book3", "Book4", "Book5"};
        }

        public class  StockController
        {
            readonly ConcurrentDictionary<string, int> stock = new ConcurrentDictionary<string, int>();

            public void BuyBook(string item, int quantity)
            {
                stock.AddOrUpdate(item, quantity, (key, oldValue) => oldValue + quantity);
            }

            public bool TryRemoveBookFromStore(string item)
            {
                if (stock.TryRemove(item, out int val))
                {
                    Console.WriteLine($"How much was removed: {val}");
                    return true;
                }

                return false;
            }

            public bool TrySellBook(string item)
            {
                bool success = false;
                stock.AddOrUpdate(item,
                    itemName =>
                    {
                        success = false;
                        return 0;
                    },
                    (itemName, oldValue) =>
                    {
                        if (oldValue == 0)
                        {
                            success = false;
                            return 0;
                        }
                        else
                        {
                            success = true;
                            return -1;
                        }
                    }
                );
                return success;
            }
        }

        private static readonly List<int> largeList = new List<int>(100000);

        private static void GerenarateList()
        {
            for (int i = 0; i < 100000; i++)
            {
                largeList.Add(i);
            }
        }

        static void Main(string[] args)
        {
            //StackDemo();
            //QueueDemo();
            //ListDemo();
            //SetDemo();
            //DictionaryDemo();
            //ConcurrentQueueDemo();
            //ConcurrentStackDemo();
            //ConcurrentBagDemo();
            Console.ReadKey();
        }


        //Immutable Collections
        static void QueueDemo()
        {
            var queue = ImmutableQueue<int>.Empty;
            queue = queue.Enqueue(1);
            queue = queue.Enqueue(3);
            queue = queue.Enqueue(5);

            PrinOutCollection(queue);

            Console.WriteLine($"Last: {queue.Peek()}");

            queue = queue.Dequeue();

            Console.WriteLine($"Last after dequeue: {queue.Peek()}");
        }

        static void StackDemo()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);

            int last = stack.Peek();
            Console.WriteLine($"Last element: {last}");

            stack = stack.Pop();

            Console.WriteLine($"Last item:{last};  Last after pop:{stack.Peek()}");
        }

        static void ListDemo()
        {
            var list = ImmutableList<int>.Empty;
            list = list.Add(2);
            list = list.Add(8);
            list = list.Add(-3);
            list = list.Add(18);

            PrinOutCollection(list);

            Console.WriteLine("Remove 2 and then RemoveAt index = 2");
            list = list.Remove(2);
            list = list.RemoveAt(2);

            PrinOutCollection(list);

            Console.WriteLine("Insert 1 at 0 and 99 at 2");
            list = list.Insert(0, 1);
            list = list.Insert(2, 99);

            PrinOutCollection(list);
        }

        static void SetDemo()
        {
            Console.WriteLine("-------------HashSet Demo ----------------");

            var hashSet = ImmutableHashSet<int>.Empty;
            hashSet = hashSet.Add(5);
            hashSet = hashSet.Add(10);
            hashSet = hashSet.Add(13);


            PrinOutCollection(hashSet);

            Console.WriteLine("Remove 5");
            hashSet = hashSet.Remove(5);
            PrinOutCollection(hashSet);

            Console.WriteLine("-------------ImmutableSortedSet Demo ----------------");
            var sortedSet = ImmutableSortedSet<int>.Empty;
            sortedSet = sortedSet.Add(13);
            sortedSet = sortedSet.Add(10);
            sortedSet = sortedSet.Add(5);

            PrinOutCollection(sortedSet);
            Console.WriteLine($"The smallest: {sortedSet[0]}");

            Console.WriteLine($"Remove 5");
            sortedSet = sortedSet.Remove(5);
            PrinOutCollection(sortedSet);




        }

        static void DictionaryDemo()
        {
            var dictionary = ImmutableDictionary<int, string>.Empty;
            dictionary = dictionary.Add(1, "Marina");
            dictionary = dictionary.Add(3, "Mihai");
            dictionary = dictionary.Add(-2, "Lena");
            dictionary = dictionary.Add(7, "Ana");

            IterateDictionary(dictionary);

            Console.WriteLine("Changing value of key 2 to Bob");

            dictionary = dictionary.SetItem(2, "Bob");
            IterateDictionary(dictionary);

            var lena = dictionary[-2];
            Console.WriteLine($"The value of key -2: {lena}");

            Console.WriteLine("Remove elementent with key -2");
            dictionary = dictionary.Remove(-2);

            IterateDictionary(dictionary);

        }

        static void BuilImmutableCollectionDemo()
        {
            var builder = ImmutableList.CreateBuilder<int>();
            foreach (var item in largeList)
            {
                builder.Add(item);
            }

            var realyImmutableList = builder.ToImmutable();
        }
        private static void IterateDictionary(ImmutableDictionary<int, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }

        private static void PrinOutCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }





        //Concurrent Collections

        static void ConcurrentQueueDemo()
        {
            var names = new ConcurrentQueue<string>();
            names.Enqueue("Bob");
            names.Enqueue("Alice");
            names.Enqueue("Rob");

            Console.WriteLine($"After enqueue length: {names.Count}");

            string item1;

            bool success = names.TryDequeue(out item1);
            if(success)
                Console.WriteLine($"Removing of ite: {item1}");
            else
                Console.WriteLine("Queue empty");

            string item2;
            success = names.TryPeek(out item2);
            if(success)
                Console.WriteLine("Peeking item" + item2);
            else
                Console.WriteLine("Queue empty");

            PrinOutCollection(names);
            Console.WriteLine($"After enqueue length: {names.Count}");

        }

        static void ConcurrentStackDemo()
        {
            var names = new ConcurrentStack<string>();
            names.Push("Bob");
            names.Push("Alice");
            names.Push("Rob");

            Console.WriteLine($"After enqueue length: {names.Count}");

            string item1;

            bool success = names.TryPop(out item1);
            if (success)
                Console.WriteLine($"Removing of ite: {item1}");
            else
                Console.WriteLine("Queue empty");

            string item2;
            success = names.TryPeek(out item2);
            if (success)
                Console.WriteLine("Peeking item" + item2);
            else
                Console.WriteLine("Queue empty");

            PrinOutCollection(names);
            Console.WriteLine($"After enqueue length: {names.Count}");
        }

        static void ConcurrentBagDemo()
        {
            var names = new ConcurrentBag<string>();
            names.Add("Bob");
            names.Add("Alice");
            names.Add("Rob");

            Console.WriteLine($"After enqueue length: {names.Count}");

            string item1;

            bool success = names.TryTake(out item1);
            if (success)
                Console.WriteLine($"Removing of ite: {item1}");
            else
                Console.WriteLine("Queue empty");

            string item2;
            success = names.TryPeek(out item2);
            if (success)
                Console.WriteLine("Peeking item" + item2);
            else
                Console.WriteLine("Queue empty");

            PrinOutCollection(names);
            Console.WriteLine($"After enqueue length: {names.Count}");
        }
    }

    
}
