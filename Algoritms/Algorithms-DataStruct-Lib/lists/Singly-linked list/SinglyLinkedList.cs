using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms_DataStruct_Lib.lists
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { set; get; }
        public Node<T> Tail { set; get; }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        private void AddFirst(Node<T> node)
        {

            Node<T> temp = Head;
            Head = node;
            Head.Next = Head;
            Count++;
            if (Count == 1)
                Tail = Head;
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        private void AddLast(Node<T> node)
        {
            if (IsEmpty)
                Head = node;
            else
                Tail.Next = node;

            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            Head = Head.Next;
            if (Count == 1)
                Tail = null;
            Count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                return;

            if (Count == 1)
            {
                Tail = null;
                Head = null;
            }
            else
            {
                var node = Head;
                while (node.Next != Tail)
                {
                    node = node.Next;
                }

                node.Next = null;
                Tail = node;
            }

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}