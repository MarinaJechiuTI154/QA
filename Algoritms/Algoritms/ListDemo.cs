using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { set; get; }
    }
    public class ListDemo
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            LogCountAndCapacity(list);

            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
                LogCountAndCapacity(list);
            }

            for (int i = 10; i > 0; i--)
            {
                list.RemoveAt(i - 1);
                LogCountAndCapacity(list);
            }

            list.TrimExcess();
            LogCountAndCapacity(list);


            list.Add(1);
            LogCountAndCapacity(list);

        }

        private static void LogCountAndCapacity(List<int> list)
        {
            Console.WriteLine($"Count={list.Count}.  Capacity={list.Capacity}");
        }

        public static void ApiMembers()
        {
            var list = new List<int>(){1 ,-2, 7, 18, 20};

            //find the index of a value of one element
            var index = list.BinarySearch(7);

            //reverse a list
            list.Reverse();

            //nothing can be changed in this list 
            ReadOnlyCollection <int> readOnly = list.AsReadOnly();

            foreach (var el in readOnly)
            {
                Console.WriteLine(el);
            }

            var listCustomers= new List<Customer>()
            {
                new Customer(){BirthDate = new DateTime(1990, 10, 10), Name = "Marina"},
                new Customer(){BirthDate = new DateTime(1990, 8, 10), Name = "Ion"},
                new Customer(){BirthDate = new DateTime(1990, 4, 10), Name = "Cristian"}

            };
            //sorts by default 
            list.Sort();

            //sort by custom - lambda expression
            listCustomers.Sort((left, right) =>
            {
                if (left.BirthDate > right.BirthDate)
                    return 1;
                if (right.BirthDate > left.BirthDate)
                    return -1;
                return 0;
            });
        }
    }
}
