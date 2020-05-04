using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.symbol_table
{
    class SequentialSearhSymbolTable<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get; }
            public TValue Value { set; get; }
            public  Node Next { set; get; }

            public Node(TKey tKey, TValue tValue, Node next)
            {
                Key = tKey;
                Value = tValue;
                Next = next;
            }
        }

        private Node first;
        private readonly EqualityComparer<TKey> comparer;
        public int Count { get; private set; }

        public SequentialSearhSymbolTable()
        {
            comparer = EqualityComparer<TKey>.Default;
        }

        public SequentialSearhSymbolTable(EqualityComparer<TKey> comparer)
        {
            //if comparer is null, then we throw the exception
            this.comparer = comparer ?? throw new ArgumentNullException();
        }

        public bool TryGet(TKey tKey, out TValue value)
        {
            for (Node x = first; x != null;  x = x.Next)
            {
                if (comparer.Equals(tKey, x.Key))
                {
                    value = x.Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue value)
        {
            if(key == null)
                throw new ArgumentNullException("Key can't be null");
            //if the key exist, we just change the value
            for (Node x = first; x != null; x = x.Next)
            {
                x.Value = value;
                return;
            }
            //if key doesn't exist yet, we add a new element as first
            first = new Node(key, value, first);
            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = first; x != null; x = x.Next)
            {
                if (comparer.Equals(key, x.Key))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (Node x = first; x != null; x = x.Next)
            {
                yield return x.Key;
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentException("Key can't be null");
                return false;
            }

            if (Count == 1 && comparer.Equals(key, first.Key))
            {
                first = null;
                Count--;
                return true;
            }

            Node prev = null;
            Node current = first;
            while (current != null)
            {
                if (comparer.Equals(current.Key, key))
                {
                    if (prev == null)
                    {
                        first = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }

                    Count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }
            return false;

        }
    }
}
