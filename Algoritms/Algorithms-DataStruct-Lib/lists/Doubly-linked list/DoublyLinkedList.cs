using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.lists.Doubly_linked_list
{
    public class DoublyLinkedList<T>
    {
        public Node<T> Head { private set;  get; }
        public Node<T> Tail { private set;  get; }

        public int Count;
        public bool IsEmpty => Count == 0;

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        private void AddFirst(Node<T> node)
        {
            var temp = Head;
            Head = node;

            Head.Next = temp;
            if (Head.Next == null)
                Tail = node;
            else
            {
                temp.Prev = Head;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        private void AddLast(Node<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }
            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if(IsEmpty)
                return;

            Head = Head.Next;
            Count--;
            if (IsEmpty)
                Tail = null;
            else
            {
                Head.Prev = null;
            }
        }

        public void RemoveLast()
        {
            if(IsEmpty)
                return;

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }

            Count--;
        }
    }
}
