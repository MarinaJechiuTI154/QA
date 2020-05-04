using System;
using Algorithms_DataStruct_Lib.sort;
using NUnit.Framework;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    class SortingTests
    {

        private int[][] Samples()
        {
            int[][] sampels = new int[9][];
            sampels[0] = new int[]{1};
            sampels[1] = new int[]{2,1};
            sampels[2] = new int[]{2,1,3};
            sampels[3] = new int[]{1,1,1};
            sampels[4] = new int[]{2,-1,3,3};
            sampels[5] = new int[]{4,-5,3,3};
            sampels[6] = new int[]{0,-5,3,3};
            sampels[7] = new int[]{0,-5,3,0};
            sampels[8] = new int[]{3,2,5,5,1,0,7,8};
            return sampels;
        }

        private void RunTestsForSortingAlgorithms(Action<int[]> sort)
        {
            foreach (var sample in Samples())
            {
                sort(sample);
                CollectionAssert.IsOrdered(sample);
                PrintOut(sample);
            }
        }

        private void PrintOut(int[] array)
        {
            TestContext.WriteLine("----Trace----");
            foreach (var el in array)
            {
                TestContext.Write(el + " ");
            }
            TestContext.WriteLine("\n\n");
        }

        [Test]
        public void BubbleSort_ValidInput_SortedInput()
        {
            RunTestsForSortingAlgorithms(BubbleSort.Sort);
        }

        [Test]
        public void SelectionSort_ValidInput_SortedOutput()
        {
            RunTestsForSortingAlgorithms(SelectionSort.Sort);
        }

        [Test]
        public void InsertionSort_ValidInput_SortedOutput()
        {
            RunTestsForSortingAlgorithms(InsertionSort.Sort);
        }

        [Test]
        public void ShellSort_ValidInput_SortOutput()
        {
            RunTestsForSortingAlgorithms(ShellSort.Sort);
        }

        [Test]
        public void MergeSort_ValidInput_SortOut()
        {
            RunTestsForSortingAlgorithms(MergeSort.Sort);
        }

        [Test]
        public void QuickSort_ValidInput_SortOutpu()
        {
            RunTestsForSortingAlgorithms(QuickSort.Sort);
        }
    }
}
