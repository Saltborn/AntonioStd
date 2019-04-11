using AntonioStd.Collections.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public abstract class AbstractSet<T> : AbstractCollection<T>, IMutableSet<T>
    {
        private IMutableMap<T, object> map;

        public AbstractSet(IMutableMap<T, object> map)
        {
            this.map = map;
        }

        public override int Count { get => map.Count; protected set { } }

        public void Clear()
        {
            map.Clear();
        }

        public ISet<T> Exept(ISet<T> other)
        {
            var iterator = GetIterator();
            var result = CreateSet();

            while (iterator.HasNext())
            {
                var current = iterator.Next();

                if (!other.Contains(current))
                {
                    result.Add(current);

                }
            }

            return result;
        }

        public override IIterator<T> GetIterator()
        {
            return new TreeSetIterator<T>(map.GetIterator());
        }

        public ISet<T> Intersect(ISet<T> other)
        {
            var iterator = GetIterator();
            var result = CreateSet();

            while (iterator.HasNext())
            {
                var current = iterator.Next();

                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public IMutableSet<T> Add(T key)
        {
            map.Put(key, null);

            return this;
        }

        public ISet<T> Union(ISet<T> other)
        {
            var iterator = other.GetIterator();
            var thisItertor = GetIterator();
            var result = CreateSet();

            while (iterator.HasNext())
            {
                result.Add(iterator.Next());
            }

            while (thisItertor.HasNext())
            {
                result.Add(thisItertor.Next());
            }

            return result;
        }

        protected abstract IMutableSet<T> CreateSet();

        private class TreeSetIterator<K> : IIterator<K>
        {
            private IIterator<Tuple<K, object>> iterator;

            public int Index => iterator.Index;

            public TreeSetIterator(IIterator<Tuple<K, object>> iterator)
            {
                this.iterator = iterator;
            }

            public bool HasNext()
            {
                return iterator.HasNext();
            }

            public K Next()
            {
                return iterator.Next().Item1;
            }
        }
    }
}

