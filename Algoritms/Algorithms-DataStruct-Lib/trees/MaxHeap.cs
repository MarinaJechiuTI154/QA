using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Authentication;
using System.Text;

namespace Algorithms_DataStruct_Lib.trees
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] heap;
        public int Count { get; private set; }
        public bool IsFull => Count == heap.Length;
        public bool IsEmpty => Count == 0;

        public MaxHeap():this(DefaultCapacity)
        {
           
        }

        public MaxHeap(int capacity)
        {
            heap = new T[capacity];
        }

        public void Insert(T value)
        {
            if (IsFull)
            {
                var newHeap = new T[heap.Length * 2];
                Array.Copy(heap, 0, newHeap, 0, heap.Length);
                heap = newHeap;
            }

            heap[Count] = value;
            Swim(Count);
            Count++;
        }

        public void Swim(int indexOfSwimmingItem)
        {
            T newValue = heap[indexOfSwimmingItem];
            while (indexOfSwimmingItem > 0 && IsParrentLess(indexOfSwimmingItem))
            {
                heap[indexOfSwimmingItem] = GetParent(indexOfSwimmingItem);
                indexOfSwimmingItem = ParentIndex(indexOfSwimmingItem);
            }

            heap[indexOfSwimmingItem] = newValue;

            bool IsParrentLess(int indexSwimmingItem)
            {
                return newValue.CompareTo(GetParent(indexSwimmingItem)) > 0;
            }
        }

        private T GetParent(int index)
        {
            return heap[ParentIndex(index)];
        }

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public IEnumerable<T> Values()
        {
            for (int i = 0; i < Count; i++)
            {
                var item = heap[i];
                yield return item;
            }
        }


        //return the max value of the heap
        public T Peek()
        {
            if(IsEmpty)
                throw new InvalidOperationException();
            return heap[0];
        }

        //remove the root
        public T Remove()
        {
            return Remove(0);
        }

        public T Remove(int index)
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            T removedValue = heap[index];
            heap[index] = heap[Count - 1];
            if (index == 0 || heap[index].CompareTo(GetParent(index)) < 0)
            {
                Sink(index, Count - 1);
            }
            else
            {
                Swim(index);
            }

            Count--;
            return removedValue;
        }

        private void Sink(int indexOfSinkingItem, int lastHeapIndex)
        {
            while (indexOfSinkingItem <= lastHeapIndex)
            {
                int leftChildIndex = LeftChildIndex(indexOfSinkingItem);
                int rightChildIndex = RightChildIndex(indexOfSinkingItem);

                if(leftChildIndex > lastHeapIndex)
                    break;
                int childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);

                if (SinkingIsLessThan(childIndexToSwap))
                {
                    Exchange(indexOfSinkingItem, childIndexToSwap);
                }
                else
                {
                    break;
                }

                indexOfSinkingItem = childIndexToSwap;
            }

            bool SinkingIsLessThan(int childToSwap)
            {
                return heap[indexOfSinkingItem].CompareTo(heap[childToSwap]) < 0;
            }

            int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex)
            {
                int childToSwap;
                if (rightChildIndex > lastHeapIndex)
                {
                    childToSwap = leftChildIndex;
                }
                else
                {
                    int compareTo = heap[leftChildIndex].CompareTo(heap[rightChildIndex]);
                    childToSwap = (compareTo > 0 ? leftChildIndex : rightChildIndex);
                }

                return childToSwap;
            }
        }
        private void Exchange(int leftIndex, int RightIndex)
        {
            var tmp = heap[leftIndex];
            heap[leftIndex] = heap[RightIndex];
            heap[RightIndex] = tmp;
        }


        private int RightChildIndex(int parentIndex)
        {
            return 2 * parentIndex  + 2;
        }

        private int LeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        public void Sort()
        {
            int lastHeapIndex = Count - 1;
            for (int i = 0; i < lastHeapIndex; i++)
            {
                Exchange(0, lastHeapIndex -i);
                Sink(0, lastHeapIndex - i - 1);
            }
        }
    }
}
