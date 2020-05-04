using System;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.lists.Doubly_linked_list;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    class DoublyLinkedListTests
    {
        private DoublyLinkedList<int> list;
        [SetUp]
        public void Init()
        {
            list = new DoublyLinkedList<int>();
        }

        [Test]
        public void CreateEmptyList_CorrectState()
        {
            Assert.True(list.Count == 0);
            Assert.True(list.IsEmpty);
            Assert.True(list.Head == null);
            Assert.True(list.Tail == null);
        }

        [Test]
        public void AddFirst_OneItem_CorrectState()
        {
            list.AddFirst(2);
            CheckStateWithSingleNode(list);
        }

        [Test]
        public void AddLast_OneItem_CorrectState()
        {
            list.AddLast(-9);
            CheckStateWithSingleNode(list);
        }

        private void CheckStateWithSingleNode(DoublyLinkedList<int> list)
        {
            Assert.True(list.Count == 1);
            Assert.AreSame(list.Head, list.Tail);
            Assert.IsNull(list.Head.Next);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNull(list.Head.Prev);
            Assert.IsNull(list.Tail.Prev);
        }

        [Test]
        public void RemoveFirst_OneElement()
        {
            list.AddLast(7);
            list.AddFirst(10);
            list.RemoveFirst();
            CheckStateWithSingleNode(list);
            Assert.AreEqual(7, list.Head.Value);
        }

        [Test]
        public void RemoveLast_OneEelemnt()
        {
            list.AddLast(7);
            list.AddFirst(10);
            list.RemoveLast();
            CheckStateWithSingleNode(list);
            Assert.AreEqual(10, list.Head.Value);
        }

        [Test]
        public void Add_Remove_CheckCorrectState()
        {
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            //add first
            list.AddFirst(-2);
            Assert.AreEqual(-2, list.Head.Value);
            Assert.AreEqual(1, list.Head.Next.Value);

            //add last
            list.AddLast(5);
            Assert.AreEqual(5, list.Tail.Value);
            Assert.AreEqual(4, list.Tail.Prev.Value);

            //remove first
            list.RemoveFirst();
            Assert.AreEqual(1, list.Head.Value);
            Assert.Null(list.Head.Prev);

            //remove last
            list.RemoveLast();
            Assert.AreEqual(4, list.Tail.Value);
            Assert.Null(list.Tail.Next);
        }
    }
}
