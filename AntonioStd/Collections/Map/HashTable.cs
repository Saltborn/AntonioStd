using AntonioStd.Collections.List;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Map
{
    public class HashTable<K, T> : AbstractCollection<Tuple<K, T>>, IMutableMap<K, T>
    {
        private LinkedList<Tuple<K, T>>[] table;

        public override int Count { get; protected set; }

        public HashTable(int expectedCount)
        {
            this.table = new LinkedList<Tuple<K, T>>[expectedCount];
        }

        public void Clear()
        {
            Count = 0;

            table = new LinkedList<Tuple<K, T>>[Count];
        }

        public bool ContainsKey(K key)
        {
            var iterator = table[GetIndex(key)]?.GetIterator();

            while (iterator?.HasNext() ?? false)
            {
                if (Equals(iterator.Next().Item1, key))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsValue(T value)
        {
            foreach (var list in table)
            {
                var iterator = list?.GetIterator();

                while (iterator?.HasNext() ?? false)
                {
                    if (Equals(iterator.Next().Item2, value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public T Get(K key)
        {
            var iterator = table[GetIndex(key)]?.GetIterator();

            while (iterator?.HasNext() ?? false)
            {
                (K currentKey, T currentValue) = iterator.Next();

                if (Equals(currentKey, key))
                {
                    return currentValue;
                }
            }

            return default(T);
        }

        public override IIterator<Tuple<K, T>> GetIterator()
        {
            return new HashTableIterator<K, T>(table);
        }

        public IMutableMap<K, T> Put(K key, T value)
        {
            int putIndex = GetIndex(key);

            if (table[putIndex] == null)
            {
                table[putIndex] = LinkedList<Tuple<K, T>>.Of();
            }

            table[putIndex].Add(new Tuple<K, T>(key, value));

            Count++;

            return this;
        }

        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % table.Length;
        }

        private class HashTableIterator<R, P> : IIterator<Tuple<K, T>>
        {
            private LinkedList<Tuple<K, T>>[] table;
            private IIterator<Tuple<K, T>> iterator;

            public int Index { get; private set; }

            public HashTableIterator(LinkedList<Tuple<K, T>>[] table)
            {
                this.table = table;
            }

            public bool HasNext()
            {
                if (iterator?.HasNext() ?? false)
                {
                    return true;
                }

                for (int i = Index; i < table.Length; i++)
                {
                    if (table[i] != null)
                    {
                        return true;
                    }
                }

                return false;
            }

            public Tuple<K, T> Next()
            {
                while (iterator == null || !iterator.HasNext())
                {
                    iterator = table[Index]?.GetIterator();

                    Index++;
                }

                return iterator.Next();
            }
        }
    }
}
