using System;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.search;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    class BinarySearchTest
    {
        [Test]
        public void IterativeBinarySearch_SortedInput_CorrectIndex()
        {
            int[] a = {0, 3, 4, 7, 8, 12, 15, 22};
            Assert.AreEqual(2, Searching.IterativeBinarySearch(a, 4));
            Assert.AreEqual(0, Searching.IterativeBinarySearch(a, 0));
            Assert.AreEqual(4, Searching.IterativeBinarySearch(a, 8));
            Assert.AreEqual(6, Searching.IterativeBinarySearch(a, 15));

        }

        [Test]

        public void RecursiveBinarySearch_SortedInput_CorrectOutput()
        {
            int[] a = { 0, 3, 4, 7, 8, 12, 15, 22 };
            Assert.AreEqual(2, Searching.RecursiveBinarySearch(a, 4));
            Assert.AreEqual(0, Searching.RecursiveBinarySearch(a, 0));
            Assert.AreEqual(4, Searching.RecursiveBinarySearch(a, 8));
            Assert.AreEqual(6, Searching.RecursiveBinarySearch(a, 15));
        }
    }
}
