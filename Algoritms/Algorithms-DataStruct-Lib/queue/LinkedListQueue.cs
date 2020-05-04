using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.lists;

namespace Algorithms_DataStruct_Lib.queue
{
    public class LinkedListQueue<T> : IEnumerable<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count => list.Count;
        public bool IsEmpty => Count == 0;

        public void Enqueue(T item)
        {
            list.AddLast(item);
        }

        public void Dequeue()
        {
            list.RemoveFirst();
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return list.Head.value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
