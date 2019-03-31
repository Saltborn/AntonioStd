using AntonioStd.Collections.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.List
{
    public class ArrayList<T> : AbstractCollection<T>, IMutableList<T>
    {
        private const double GROUGTH_COEFFICIENT = 1.5;

        private T[] innerArray;
        public override int Count { get; protected set; }

        private ArrayList(T[] innerArray, int count)
        {
            this.innerArray = innerArray;
            this.Count = count;
        }

        public static ArrayList<T> WithInitialCapacity(int capacity)
        {
            T[] innerArray = new T[capacity];

            return new ArrayList<T>(innerArray, 0);
        }

        public static ArrayList<T> Of(params T[] values)
        {
            int count = values.Length;

            T[] innerArray = new T[(int)(count * GROUGTH_COEFFICIENT)];

            Array.Copy(values, 0, innerArray, 0, count);

            return new ArrayList<T>(innerArray, count);
        }

        private void expendArray()
        {
            T[] innerProlongedArray = new T[(int)(Count * GROUGTH_COEFFICIENT)];

            Array.Copy(innerArray, 0, innerProlongedArray, 0, Count);
        }

        public void Add(T value)
        {
            int addIndex = Count;

            if (innerArray.Length > addIndex)
            {
                innerArray[addIndex] = value;

                Count++;
            }
            else
            {
                expendArray();

                innerArray[addIndex] = value;

                Count++;
            }
        }

        public void Clear()
        {
            Count = 0;
        }

        public override bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(innerArray[i], value))
                {
                    return true;
                }
            }

            return false;
        }


        public override IIterator<T> GetIterator()
        {
            return new ArrayListIterator<T>(this);
        }

        public void Insert(int index, T value)
        {
            if (Count < index)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {Count}. Actual index = {index}");
            }

            Count++;

            if (index + 1 >= innerArray.Length)
            {
                expendArray();
            }

            for (int i = Count; index < i && i - 1 > 0; i--)
            {
                innerArray[i] = innerArray[i - 1];
            }

            innerArray[index] = value;
        }

        public void Remove(int index)
        {
            if (Count < index)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {Count}. Actual index = {index}");
            }

            for (var i = index; i < Count && i + 1 < innerArray.Length; i++)
            {
                innerArray[i] = innerArray[i + 1];
            }

            Count--;
        }

        public override T[] ToArray()
        {
            T[] array = new T[Count];
            Array.Copy(innerArray, 0, array, 0, Count);

            return array;
        }

        public void Set(int index, T value)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {Count}. Actual index = {index}");
            }

            innerArray[index] = value;
        }

        public T Get(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {Count}. Actual index = {index}");
            }

            return innerArray[index];
        }

        class ArrayListIterator<E> : AbstractForwardIterator<E>
        {
            private ArrayList<E> elements;

            public ArrayListIterator(ArrayList<E> elements)
            {
                this.elements = elements;
            }

            public override bool HasNext()
            {
                return Index < elements.Count;
            }

            protected override E InternalNext()
            {
                return elements.Get(Index);
            }
        }
    }
}
