using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Algorithms_DataStruct_Lib.queue
{
    public class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] queue;
        private int _head;
        private int _tail;
        public int Count => _tail - _head;
        public bool IsEmpty => Count == 0;
        public ArrayQueue()
        {
            const int defaultCapacity = 4;
            queue = new T[defaultCapacity];
        }

        public ArrayQueue(int capacity)
        {
            queue = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (queue.Length == _tail)
            {
                T[] largerArray = new T[Count*2];
                Array.Copy(queue, largerArray, Count);
                queue = largerArray;
            }

            queue[_tail++] = item;

        }

        public void Dequeue()
        {
            if(IsEmpty)
                throw new InvalidOperationException();
            queue[_head++] = default(T);

            if (IsEmpty)
                _head = _tail = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return queue[_head];
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _head; i < _tail; i++)
            {
                yield return queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
