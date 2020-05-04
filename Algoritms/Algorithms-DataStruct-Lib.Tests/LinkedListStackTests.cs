using System;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.stack;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    class LinkedListStackTests
    {
        private LinkedStack<int> stack;

        [SetUp]
        public void Init()
        {
            stack = new LinkedStack<int>();
        }
        [Test]
        public void IsEmpty_EmptyStack_ReturnTrue()
        {
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnOne()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowException()
        {
            Assert.Throws<InvalidOperationException>((
                stack.Pop
            ));
        }
        //[Test]
        //public void Peek_PushTwoItems_ReturnsHeadElement()
        //{
        //    stack.Push(1);
        //    stack.Push(2);
        //    Assert.AreEqual(2, stack.Peek());

        //    stack.Pop();
        //    Console.Write("Length: ", stack.Count);
        //    Assert.AreEqual(1, stack.Peek());
        //}
    }
}
