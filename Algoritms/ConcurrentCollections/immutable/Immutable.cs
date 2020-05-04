using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.immutable
{
    public interface IStack<T> : IEnumerable<T>
    {
        IStack<T> Push(T value);
        IStack<T> Pop();
        T Peek();
        bool IsEmpty { get; }
    }

    public sealed class Stack<T> : IStack<T>
    {
        private sealed class EmptyStack : IStack<T>
        {
            public bool IsEmpty => true;

            public T Peek()
            {
                throw new Exception("Empty stack");
            }

            public IStack<T> Pop()
            {
                throw new Exception("Empty stack");
            }

            public IStack<T> Push(T value)
            {
                return new Stack<T>(value, this);
            }

            public IEnumerator<T> GetEnumerator()
            {
                yield break;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        private static readonly  EmptyStack empty = new EmptyStack();
        private readonly T head;
        private readonly IStack<T> tail;

        public static IStack<T> Empty => empty;
        public bool IsEmpty => false;


        private Stack(T _head, IStack<T> _tail)
        {
            head = _head;
            tail = _tail;
        }
        public T Peek()
        {
            return head;
        }

        public IStack<T> Pop()
        {
            return tail;
        }

        public IStack<T> Push(T value)
        {
            return new Stack<T>(value, this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (IStack<T> stack = this; !stack.IsEmpty; stack = stack.Pop())
            {
                yield return stack.Peek();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
