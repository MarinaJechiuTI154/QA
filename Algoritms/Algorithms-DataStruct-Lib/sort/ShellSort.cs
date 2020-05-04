using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.sort
{
    public class ShellSort
    {
        public static void Sort(int[] array)
        {
            int gap = 1;
            while (gap < array.Length/3)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j-gap]; j-=gap)
                    {
                        BubbleSort.Swap(array, j, j-gap);
                    }
                }
                gap /= 3;
            }
        }

    }
}
