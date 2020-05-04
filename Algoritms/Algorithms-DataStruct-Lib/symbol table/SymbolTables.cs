using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Algorithms_DataStruct_Lib.queue;
using Algorithms_DataStruct_Lib.symbol_table;

namespace Algorithms_DataStruct_Lib.SymbolTables
{

    //Solving Collisions using Separate Chaining
    public class ChainHashSet<TKey, TValue>
    {
        private SequentialSearhSymbolTable<TKey, TValue>[] chains;
        private const int DefaultCapacity = 4;
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ChainHashSet() : this(Prime.MinPrime)
        {

        }

        public ChainHashSet(int capacity)
        {
            Capacity = capacity;
            chains = new SequentialSearhSymbolTable<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                chains[i] = new SequentialSearhSymbolTable<TKey, TValue>();
            }
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7ffffff) % Capacity;
        }

        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null");

            int index = Hash(key);
            if (chains[index].TryGet(key, out TValue val))
            {
                return val;
            }

            throw new ArgumentNullException("Key was not found");
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentException(("Key can't be null"));

            int index = Hash(key);
            return chains[index].TryGet(key, out TValue _);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentException(("Key can't be null"));

            int index = Hash(key);
            if (chains[index].Contains(key))
            {
                Count--;
                chains[index].Remove(key);

                if (Capacity > DefaultCapacity && Count <= 2 * Capacity)
                {
                    Resize(Prime.ReducePrime(Capacity));
                }

                return true;
            }

            return false;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentException(("Key can't be null"));

            if (value == null)
            {
                Remove(key);
                return;
            }

            if (Count >= 10 * Capacity) Resize(Prime.ExpandPrime(Capacity));

            int i = Hash(key);
            if (!chains[i].Contains(key))
                Count++;

            chains[i].Add(key, value);
        }

        private void Resize(int chainsNum)
        {
            var temp = new ChainHashSet<TKey, TValue>(chainsNum);
            for (int i = 0; i < Capacity; i++)
            {
                foreach (var key in chains[i].Keys())
                {
                    if (chains[i].TryGet(key, out TValue val))
                    {
                        temp.Add(key, val);
                    }
                }
            }

            Capacity = temp.Capacity;
            Count = temp.Count;
            chains = temp.chains;
        }

        public IEnumerable<TKey> Keys()
        {
            var queue = new LinkedListQueue<TKey>();
            for (int i = 0; i < Capacity; i++)
            {
                foreach (var key in chains[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }

            return queue;
        }
    }

    public class Prime
    {
        private static readonly int[] Predefined =
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103,
            107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199
        };

        public static int MinPrime => Predefined[0];
        private const int HashPrime = 101;
        public const int MaxPrimeArrayLength = 0x7FEFFFFD;

        public static int GetPrime(int min)
        {
            if (min < 0)
                throw new ArgumentException("Min cannot be negative");
            for (int i = 0; i < Predefined.Length; i++)
            {
                int prime = Predefined[i];
                if (prime >= min) return prime;
            }

            for (int i = min | 1; i < int.MaxValue; i += 2)
            {
                if (IsPrime(i) && (i - 1) % HashPrime != 0)
                    return i;
            }

            return min;
        }

        private static bool IsPrime(int candidate)
        {
            if (candidate % 2 != 0)
            {
                int limit = (int) Math.Sqrt(candidate);
                for (int divisor = 3; divisor <= limit; divisor++)
                {
                    if (candidate % divisor == 0)
                    {
                        return false;
                    }

                    return true;
                }
            }

            return candidate == 2;
        }

        public static int ExpandPrime(int oldSize)
        {
            int newSize = 2 * oldSize;
            if ((uint) newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
                return MaxPrimeArrayLength;
            return GetPrime(newSize);
        }

        public static int ReducePrime(int oldSize)
        {
            int newSize = oldSize / 2;
            if (newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
                return MaxPrimeArrayLength;
            return GetPrime(newSize);
        }
    }


    //Solving Collisions using Linear Probing

    public class LinearProbingHashSet<TKey, TValue>
    {
        private const int DefaultCapacity = 4;
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        private TKey[] keys;
        private TValue[] values;

        public LinearProbingHashSet() : this(DefaultCapacity)
        {

        }

        private LinearProbingHashSet(int capacity)
        {
            Capacity = capacity;
            keys = new TKey[capacity];
            values = new TValue[capacity];
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key not allowed to be null");

            for (int i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                    return true;
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is not allowed to be null");
            for (int i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                    return values[i];
            }

            throw new ArgumentNullException("Key was not found");
        }

        public bool TryGet(TKey key, out int index)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is not allowed to be null");
            }

            for (int i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is not allowed to be null");
            if (!TryGet(key, out int index))
                return;

            keys[index] = default(TKey);
            values[index] = default(TValue);

            index = (index + 1) / Capacity;

            while (keys[index] != null)
            {
                TKey keyToRehash = keys[index];
                TValue valToRehash = values[index];

                keys[index] = default(TKey);
                values[index] = default(TValue);

                Count--;

                Add(keyToRehash, valToRehash);

                index = (index + 1) / Capacity;

            }

            Count--;
            if (Count > 0 && Count <= Capacity / 8)
            {
                Resize(Capacity / 2);
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("Key is not allowed to be null");

            if (value == null)
            {
                Remove(key);
                return;
            }

            if (Count >= Capacity / 2)
            {
                Resize(2 * Capacity);
            }

            int i;
            for (i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                {
                    values[i] = value;
                    return;
                }
            }

            keys[i] = key;
            values[i] = value;
            Count++;
        }

        private void Resize(int capacity)
        {
            var temp = new LinearProbingHashSet<TKey, TValue>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                if (keys[i] != null)
                {
                    temp.Add(keys[i], values[i]);
                }
            }

            keys = temp.keys;
            values = temp.values;
            Capacity = temp.Capacity;
        }

        public IEnumerable<TKey> Keys()
        {
            var q = new Queue<TKey>();

            for (int i = 0; i < Capacity; i++)
            {
                if(keys[i] != null)
                    q.Enqueue(keys[i]);
            }

            return q;
        }
    }
}
