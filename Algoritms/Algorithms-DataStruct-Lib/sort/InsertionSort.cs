using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            for (int sortIndex = 1; sortIndex < array.Length; sortIndex++)
            {
                int compare = array[sortIndex];
                int i;
                for (i = sortIndex; i > 0 && array[i - 1] > compare; i--)
                {
                    array[i] = array[i - 1];
                }

                array[i] = compare;

            }
        }
    }
}
