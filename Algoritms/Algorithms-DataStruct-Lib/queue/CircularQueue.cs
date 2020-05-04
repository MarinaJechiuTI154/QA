using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorithms_DataStruct_Lib.queue
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] queue;
        public int head;
        public int tail;

        public int Count => head <= tail ? tail - head : tail - head + queue.Length;
        public bool IsEmpty => Count == 0;
        public int Capacity => queue.Length;
        public CircularQueue()
        {
            const int defaultCapacity = 4;
            queue = new T[defaultCapacity];
        }

        public CircularQueue(int capacity)
        {
            queue = new T[capacity];
        }

        public void Enqueue(T item)
        {
            //unwrap the queue when is needed the resize
            if (Count == queue.Length - 1)
            {
                int countPriorResize = Count;
                T[] largerArray = new T[2*queue.Length];
                Array.Copy(queue, head, largerArray, 0, queue.Length - head);
                Array.Copy(queue, 0, largerArray, queue.Length - head, tail);
                queue = largerArray;

                head = 0;
                tail = countPriorResize;
            }

            queue[tail] = item;
            if (tail < queue.Length - 1)
            {
                tail++;
            }
            else
            {
                tail = 0;
            }
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            queue[head] = default(T);

            if (IsEmpty)
            {
                head = 0;
                tail = 0;
            }
            else if(head == queue.Length)
            {
                head ++;
            }
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return queue[head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            //if the queue is unwraped
            if (head <= tail)
            {
                for (int i = head; i < tail; i++)
                {
                    yield return queue[i];
                }
            }
            //if queue is raped
            else
            {
                for (int i = head; i < queue.Length; i++)
                {
                    yield return queue[i];
                }

                for (int i = 0; i < tail; i++)
                {
                    yield return queue[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
