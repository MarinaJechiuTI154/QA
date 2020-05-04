using System;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.queue;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    class ArrayQueueTests
    {
        private ArrayQueue<int> queue;

        [SetUp]
        public void Init()
        {
            queue = new ArrayQueue<int>();
        }
        [Test]
        public void IsEmpty_EmptyStack_ReturnTrue()
        {
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Count_EnqueueOneItem_ReturnOne()
        {
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Dequeue_EmptyStack_ThrowException()
        {
            Assert.Throws<InvalidOperationException>((
                queue.Dequeue
            ));
        }
        [Test]
        public void Peek_EnqueueTwoItems_ReturnsHeadElement()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            Assert.AreEqual(2, queue.Peek());
        }
    }
}
