using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.sort
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            SortArray(0, array.Length - 1);

            void SortArray(int low, int high)
            {
                if(high <= low)
                    return;
                int j = Partition(low, high);
                SortArray(low, j-1);
                SortArray(j + 1, high);

            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;
                int pivot = array[low];
                while (true)
                {
                    while (array[++i] < pivot)
                    {
                        if(i == high)
                            break;
                    }

                    while (pivot < array[--j])
                    {
                        if(j == low)
                            break;
                    }

                    if(i >=j )
                        break;
                    BubbleSort.Swap(array, i, j);
                }
                BubbleSort.Swap(array, low, j);
                return j;
            }
        } 
    }
}
