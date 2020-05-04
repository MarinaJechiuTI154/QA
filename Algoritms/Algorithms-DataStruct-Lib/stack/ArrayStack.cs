using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.stack 
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private T[] items;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public ArrayStack()
        {
            const int defaultCapacity = 4;
            items = new T[defaultCapacity];
        }

        public ArrayStack(int capacity)
        {
            items = new T[capacity];
        }

        public void Push(T item)
        {
            //if stask is full, we double it
            if (items.Length == Count)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(items, largerArray, Count);

                items = largerArray;
            }

            items[Count++] = item;
        }

        //will delete the pop element
        public void Pop()
        {
            if(IsEmpty)
                throw new InvalidOperationException();
            items[--Count] = default(T);
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return items[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
