using System;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.queue;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class CircularQueueTests
    {
        private CircularQueue<int> queue;

        [SetUp]
        public void Init()
        {
            queue = new CircularQueue<int>();
        }

        [Test]
        public void Capcity_EnqueueManyItems_DoubledCapacity()
        {
            queue.Enqueue(1);
            queue.Dequeue();

            queue.Enqueue(2);
            queue.Dequeue();

            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Assert.AreEqual(8, queue.Capacity);
        }

        [Test]
        public void TestTail_AfterEnqueue()
        {
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.tail);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(2, queue.tail);
        }

        [Test]
        public void TestHead_AfterDequeue()
        {
            queue.Enqueue(1);
            
            queue.Enqueue(2);
           
            queue.Dequeue();
            queue.Dequeue();

            queue.Dequeue();
            foreach (var o in queue)
            {
                Console.Write(o);

            }
        }

    }
}
