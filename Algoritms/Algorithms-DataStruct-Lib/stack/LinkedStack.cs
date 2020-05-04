using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Algorithms_DataStruct_Lib.lists;

namespace Algorithms_DataStruct_Lib.stack
{
    public class LinkedStack<T> : IEnumerable<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public bool IsEmpty => Count == 0;
        public int Count => list.Count;

        public T Peek()
        { if(IsEmpty)
                throw new InvalidOperationException();
           
            return list.Head.value;
        }

        public void Pop()
        {
            if(IsEmpty)
                throw new InvalidOperationException();
            list.RemoveFirst();
        }

        public void Push(T item)
        {
            list.AddFirst(item);
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
