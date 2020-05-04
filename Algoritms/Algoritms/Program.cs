using Algorithms_DataStruct_Lib;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_DataStruct_Lib.lists;
using Algorithms_DataStruct_Lib.sort;
using Algorithms_DataStruct_Lib.stack;
using Algorithms_DataStruct_Lib.trees;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Algorithms_DataStruct_Lib.hash_tables;

namespace Algoritms
{
    class Program
    {
        //static void Main(string[] args)
        //{

        //    var customersList = new List<Customer>()
        //    {
        //        new Customer {Age = 3, Name = "Ann"},
        //        new Customer {Age = 16, Name = "Bill"},
        //        new Customer {Age = 20, Name = "Rose"},
        //        new Customer {Age = 14, Name = "Rob"},
        //        new Customer {Age = 28, Name = "Bill"},
        //        new Customer {Age = 14, Name = "John"}
        //    };

        //    var intList = new List<int>(){1, 4, 2, 7, 9, 12, 3, 2, 1};

        //    bool contantains = intList.Contains(3);
        //    bool contains2 = customersList.Contains(new Customer() {Age = 14, Name = "Rob"}, new CustomerComparer());

        //    bool exists = customersList.Exists(customer => customer.Age == 28);
        //    int min = intList.Min();
        //    int max = intList.Max();

        //    int youngestCustomer = customersList.Min(customer => customer.Age);
        //    Customer bill = customersList.Find(customer => customer.Name == "Bill");

        //    Customer lastBill = customersList.FindLast(customer => customer.Name == "Bill");
        //    Customer lastBill2 = customersList.Last(customer => customer.Name == "Bill");

        //    List<Customer> customers = customersList.FindAll(customer => customer.Age > 18);
        //    IEnumerable<Customer> whereAge = customersList.Where(customer => customer.Age > 18);

        //    int index1 = customersList.FindIndex(customer => customer.Age == 14);
        //    int lastIndex = customersList.FindLastIndex(customer => customer.Age == 14);

        //    int indexOf = intList.IndexOf(2);
        //    int lastIndexOf = intList.LastIndexOf(5);

        //    //from list
        //    bool isTrueForAll = customersList.TrueForAll(customer => customer.Age > 10);

        //    //from Linq
        //    bool all = customersList.All(customer => customer.Age > 10);

        //    bool areThereAny = customersList.Any(customer => customer.Name == "Bob");

        //    int count = customersList.Count(customer => customer.Age > 18);
        //    Customer firstBill = customersList.First(customer => customer.Name == "Bill");
        //    Customer singleAnn = customersList.Single(customer => customer.Name == "Ann");

        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{

 
        //    //var books  = new Dictionary<int, string>();
        //    //books.Add(3, "Lord of the Rings");
        //    //books.Add(2, "Other story");

        //    //string bookName = books[3];
        //    //Console.WriteLine(bookName);
            
        //    //element with same key isn't accepted
        //    //books.Add(3, "Harry Potter");

        //    //var number1 = new PhoneNumber( "373", "27" ,"789456");
        //    //var number2 = new PhoneNumber( "373", "27" ,"789456");
        //    //var number3 = new PhoneNumber( "373", "27" , "789456");

        //    //Console.WriteLine(number1.GetHashCode());
        //    //Console.WriteLine(number2.GetHashCode());
        //    //Console.WriteLine(number1.Equals(number2));

        //    //var customers = new Dictionary<PhoneNumber, Person>();

        //    //customers.Add(number1, new Person());

        //    //Console.WriteLine(customers.ContainsKey(number1));

        //    //var c = customers[number3];

        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            var heap = new MaxHeap<int>();
            heap.Insert(24);
            heap.Insert(35);
            heap.Insert(2);
            heap.Insert(31);
            heap.Insert(50);
            heap.Insert(67);
            heap.Insert(29);
            heap.Insert(15);
            //Console.WriteLine("_____" + heap.Peek());
            //heap.Remove();
            //Console.WriteLine("_____" + heap.Peek());
            heap.Sort();
            foreach (var item in heap.Values())
            {
                Console.Write($"{item}  ");
            }


            Console.ReadKey();
        }


        private static bool Exists(int[] array, int searchedNumber)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchedNumber)
                    return true;
            }

            return false;
        }

        private static int IndexOf(int[] array, int searchedNumber)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchedNumber)
                    return i;
            }

            return -1;
        }

        private static void ArrayDemo()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] {1, 2, 3, 4, 5};

            int[] a4 = {1, 2, 3};

            Array myArr = new int[5];

            Array myArr1 = Array.CreateInstance(typeof(int), 5);
            myArr1.SetValue(3, 0);

            //create an array with wirst index starts with 2
            Array myArray2 = Array.CreateInstance(typeof(int), new[] {4}, new[] {2});
            myArray2.SetValue(5, 2);
            myArray2.SetValue(10, 3);

            for (int i = 0; i < myArray2.Length; i++)
            {
                Console.Write(myArray2.GetValue(i) + "\t");
            }
        }

        private static void multipleDimArrays()
        {
            int[,] a1 = new int[2, 3] { {1, 2, 3}, {1, 2, 3}};

            int[,] a2 = {{2, 3}, {4, 3}};
            for (int i = 0; i < a1.GetLength(0); i++)
            {
                for (int j = 0; j < a1.GetLength(1); j++)
                {
                    Console.Write($"{a1[i,j]} \t");
                }
                Console.WriteLine();
            }

        }

        private static void JaggedArrays()
        {
            Random random = new Random();
            //array of arrays
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[1];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j <jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = random.Next(1, 20);
                }
            }


            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} \t");
                }
                Console.WriteLine();
            }
        }

        private static unsafe void IterateOver(int[] array)
        {
            //iterate directly from memory
            fixed (int* b = array)
            {
                int* p = b;
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(*p);
                    p++;
                }
            }
        }

        private static int IterativeFactorial(int n)
        {
            if (n <= 0)
                return 1;
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        private static int RecursiveFactorial(int n)
        {
            if (n == 0)
                return 1;
            return n * RecursiveFactorial(n - 1);
        }


    }

    internal class CustomerComparer : IEqualityComparer<Customer>
    {
        public CustomerComparer()
        {
        }

        public bool Equals(Customer x, Customer y)
        {
            return x.Age == y.Age && x.Name == y.Name;
        }

        public int GetHashCode(Customer obj)
        {
            return obj.GetHashCode();
        }
    }
}
