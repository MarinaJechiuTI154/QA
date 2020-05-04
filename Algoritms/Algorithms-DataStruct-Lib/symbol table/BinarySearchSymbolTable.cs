using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Algorithms_DataStruct_Lib.queue;

namespace Algorithms_DataStruct_Lib.symbol_table
{
    public class BinarySearchSymbolTable<TKey, TValue>
    {
        private TKey[] keys;
        private TValue[] values;
        public int Count { get; private set; }
        private readonly IComparer<TKey> comparer;
        public int Capacity => keys.Length;
        public const int DefaultCapacity = 4;
        public bool IsEmpty => Count == 0;
        public BinarySearchSymbolTable(int capacity, IComparer<TKey> comparer)
        {
            keys = new TKey[capacity];
            values = new TValue[capacity];
            this.comparer = comparer ?? throw new ArgumentNullException("Comparer cannot be NULL");
        }

        //implement the existing previous constructor
        public BinarySearchSymbolTable(int capacity) : this(capacity, Comparer<TKey>.Default)
        {

        }

        public BinarySearchSymbolTable() : this(DefaultCapacity, Comparer<TKey>.Default)
        {
        }

        //return the index of found key
        public int Rank(TKey key)
        {
            int low = 0;
            int high = Count -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                int cmp = comparer.Compare(key, keys[mid]);
                if (cmp < 0)
                    high = mid - 1;
                else if (cmp > 0)
                    low = mid + 1;
                else
                    return mid;
            }

            return low;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            if (IsEmpty)
            {
                return default(TValue);
            }
            //we return the value of the searching key
            int rank = Rank(key);
            if (rank < Count && comparer.Compare(keys[rank], key)==0)
            {
                return values[rank];
            }

            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) 
                throw new ArgumentNullException("Key shouldn't be NULL");
            int rank = Rank(key);
            //if such key already exists, we just update the value
            if (rank < Count && comparer.Compare(key, keys[rank]) == 0)
            {
                values[rank] = value;
                return;
            }

            if (Count == Capacity)
            {
                Resize(Capacity * 2);
            }
            //if key doesn't exist, we place the element in the table in the rank position. So that, after add new element, table remains sorted
            for (int i = Count; i > rank; i--)
            {
                keys[i] = keys[i - 1];
                values[i] = values[i - 1];
            }

            keys[rank] = key;
            values[rank] = value;
            Count++;

        }

        public void Remove(TKey key)
        {
            if(key == null)
                throw new ArgumentNullException("Key shouldn't be NULL");
            if(IsEmpty)
                return;
            int rank = Rank(key);
            if(rank == Count || comparer.Compare(key, keys[rank]) != 0)
                return;

            //move all the elements to the left in the place of the removed element
            for (int i = rank; i < Count - 1; i++)
            {
                keys[i] = keys[i + 1];
                values[i] = values[i + 1];
            }

            Count--;
            //delete last element
            values[Count - 1] = default(TValue);
            keys[Count - 1] = default(TKey);

            //resize if 1/4 just full
            if(Count > 0 && Count == Capacity / 4)
                Resize(Capacity / 2);
        }

        public bool Contains(TKey key)
        {
            int rank = Rank(key);
            if (rank >= 0 &&  comparer.Compare(key, keys[rank]) == 0)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            foreach (var key in keys)
            {
                yield return key;
            }
        }

        private void Resize(int capacity)
        {
            TKey[] resizedKey = new TKey[capacity];
            TValue[] resizedValue = new TValue[capacity];
            for (int i = 0; i < Count; i++)
            {
                resizedKey[i] = keys[i];
                resizedValue[i] = values[i];
            }

            values = resizedValue;
            keys = resizedKey;
        }

        public TKey Min()
        {
            if(IsEmpty)
                throw new InvalidOperationException("The array is empty");
            return keys[0];
        }

        public TKey Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The array is empty");
            return keys[Count-1];
        }

        public void RemoveMin()
        {
            if(IsEmpty)
                throw new InvalidOperationException("The array is empty");
            Remove(Min());
        }

        public void RemoveMax()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The array is empty");
            Remove(Max());
        }

        public TKey Select(int index)
        {
            if(index < 0 || index > Count - 1)
                throw new InvalidOperationException("The array is empty");
            return keys[index];
        }

        public TKey Ceiling(TKey key)
        {
            if(key == null) 
                throw new ArgumentNullException("Key is null");
            int rank = Rank(key);
            if (rank == Count)
                return default(TKey);
            else
                return keys[rank];
        }

        public TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is null");
            int rank = Rank(key);
            if (rank < Count && comparer.Compare(keys[rank], key) == 0)
                return keys[rank];
            if (rank == 0)
                return default(TKey);
            else
                return keys[rank - 1];
        }

        public IEnumerable<TKey> Range(TKey start, TKey end)
        {
            if(start == null || end == null)
                throw  new ArgumentNullException();

            var q = new LinkedListQueue<TKey>();
            int low = Rank(start);
            int high = Rank(end);
            if (low > high)
                return q;
            for (int i = low; i <= high; i++)
            {
                q.Enqueue(keys[i]);
            }

            return q;
        }
 
    }
}
