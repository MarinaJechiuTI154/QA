using System;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.lists;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> _list;

        [SetUp]
        public void Init()
        {
            _list = new SinglyLinkedList<int>();
        }

        [Test]
        public void CreateEmptyList_CorrectState()
        {
            var list = new SinglyLinkedList<int>();
            Assert.IsTrue(_list.IsEmpty);
            Assert.IsNull(_list.Head);
            Assert.IsNull(_list.Tail);
        }

        [Test]
        public void AddFirst_OneItem_CorrectState()
        {
            _list.AddFirst(5);
            CheckStateWithSingleNode(_list);
        }

        [Test]
        public void AddLast_OneItem_CorrectState()
        {
            _list.AddLast(5);
            CheckStateWithSingleNode(_list);
        }

        [Test]
        public void AddRemoveToGetToStateSingleNode_CorrectState()
        {
            //check RemoveFirst
            _list.AddFirst(3);
            _list.AddLast(2);
            _list.RemoveFirst();
            CheckStateWithSingleNode(_list);

            //check RemoveLast
            _list.AddLast(7);
            _list.RemoveLast();
            CheckStateWithSingleNode(_list);


        }

        private void CheckStateWithSingleNode(SinglyLinkedList<int> list)
        {
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.IsEmpty);
            Assert.AreSame(list.Head, list.Tail);
        }

        [Test]
        public void AddFirst_and_AddLast_AddItemsInCorrectOrder()
        {
            _list.AddFirst(1);
            _list.AddFirst(2);
            Assert.AreEqual(2, _list.Head.value);
            Assert.AreEqual(1, _list.Tail.value);

            _list.AddLast(3);
            Assert.AreEqual(3, _list.Tail.value);
        }

        [Test]
        public void RemoveFirst_and_RemoveLast_RemoveItemsInCorrectOrder()
        { 
            //test remove from empty list
            _list.RemoveFirst();
            Assert.IsTrue(_list.IsEmpty);
            Assert.AreSame(_list.Head, _list.Tail);

            //test remove from list.count == 1
            _list.AddLast(1);
            _list.RemoveFirst();
            Assert.IsTrue(_list.IsEmpty);
            Assert.IsTrue(_list.Head == null);
            Assert.IsTrue(_list.Tail == null);

            //test remove in right order
            _list.AddLast(1);
            _list.AddLast(2);
            _list.AddLast(3);
            _list.AddLast(4);
            _list.AddLast(5);

            //check remove first
            _list.RemoveFirst();
            Assert.AreEqual(2, _list.Head.value);
            Assert.AreEqual(4, _list.Count);


            //check remove last
            _list.RemoveLast();
            Assert.AreEqual(4, _list.Tail.value);
            Assert.AreEqual(3, _list.Count);
        }
    }
}

