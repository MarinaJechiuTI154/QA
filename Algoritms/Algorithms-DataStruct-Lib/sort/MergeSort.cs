using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib
{
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            int [] aux = new int[array.Length];
            SortArray(0, array.Length - 1);

            //an inner function that will sort the elements
            void SortArray(int low, int high)
            {
                if(high <= low)
                    return;
                int midindex = (high + low) / 2;

                //split the array again - split the left side
                SortArray(low, midindex);

                //split the right side
                SortArray(midindex + 1, high);
                Merge(low, midindex, high);          
            }

            void Merge(int low, int mid, int high)
            {
                //if the last element of first array is smaller than first of the second one, that means arrays are sorted and they don't need to be rearrenged
                if (array[mid] <= array[mid + 1])
                    return;
                //first element of the left array
                int i = low;
                //first element of right array
                int j = mid + 1;
                Array.Copy(array, low, aux, low, high - low + 1);

                for (int k = low; k <= high; k++)
                {
                    if (i > mid)
                        array[k] = aux[j++];
                    else if (j > high)
                        array[k] = aux[i++];
                    else if (aux[j] < aux[i])
                        array[k] = aux[j++];
                    else
                        array[k] = aux[i++];
                }
            }

        }
    }
}
