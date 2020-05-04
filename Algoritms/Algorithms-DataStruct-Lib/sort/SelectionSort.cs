using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.sort
{
    public class SelectionSort
    {
        public static void Sort(int[] array)
        {
            int max;
            int temp;
            for (int sortIndex = array.Length - 1; sortIndex > 0; sortIndex--)
            {
                max = 0;
                for (int i = 1; i <= sortIndex ; i++)
                {
                    if (array[i] > array[max])
                        max = i;
                }
                BubbleSort.Swap(array, max, sortIndex);
            }
        }
    }
}
