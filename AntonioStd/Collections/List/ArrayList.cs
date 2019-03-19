using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.List
{
    public class ArrayList<T> : IMutableList<T>, IEquatable<ArrayList<T>>
    {
        private const double GROUGTH_COEFFICIENT = 1.5;

        private T[] innerArray;
        private int count;

        private ArrayList(T[] innerArray, int count)
        {
            this.innerArray = innerArray;
            this.count = count;
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
            T[] innerProlongedArray = new T[(int)(count * GROUGTH_COEFFICIENT)];

            Array.Copy(innerArray, 0, innerProlongedArray, 0, count);
        }

        public void Add(T value)
        {
            int addIndex = count;

            if (innerArray.Length > addIndex)
            {
                innerArray[addIndex] = value;

                count++;
            }
            else
            {
                expendArray();

                innerArray[addIndex] = value;

                count++;
            }
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (Equals(innerArray[i], value))
                {
                    return true;
                }
            }

            return false;
        }

        public int Count()
        {
            return count;
        }

        public IIterator<T> GetIterator()
        {
            return new ArrayListIterator<T>(this);
        }

        public void Insert(int index, T value)
        {
            if (count < index)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {count}. Actual index = {index}");
            }

            count++;

            if (index + 1 >= innerArray.Length)
            {
                expendArray();
            }

            for (int i = count; index < i && i - 1 > 0; i--)
            {
                innerArray[i] = innerArray[i - 1];
            }

            innerArray[index] = value;
        }

        public void Remove(int index)
        {
            if (count < index)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {count}. Actual index = {index}");
            }

            for (var i = index; i < count && i + 1 < innerArray.Length; i++)
            {
                innerArray[i] = innerArray[i + 1];
            }

            count--;
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            Array.Copy(innerArray, 0, array, 0, count);

            return array;
        }

        public void Set(int index, T value)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {count}. Actual index = {index}");
            }

            innerArray[index] = value;
        }

        public T Get(int index)
        {
            if (index > count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > {count}. Actual index = {index}");
            }

            return innerArray[index];
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ArrayList<T>);
        }

        public bool Equals(ArrayList<T> other)
        {
            if (other == null)
            {
                return false;
            }

            if (count != other.count)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (!Equals(innerArray[i], other.innerArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder($"({count})[");

            for (int i = 0; i < count; i++)
            {
                if (i < count - 1)
                {
                    stringBuilder.Append(innerArray[i]).Append(", ");
                }
                else
                {
                    stringBuilder.Append(innerArray[i]);
                }
            }

            return stringBuilder.Append("]").ToString();
        }

        class ArrayListIterator<E> : IIterator<E>
        {
            private int currentIndex = 0;
            private ArrayList<E> elements;

            public ArrayListIterator(ArrayList<E> elements)
            {
                this.elements = elements;
            }

            public bool HasNext()
            {
                return currentIndex < elements.Count();
            }

            public E Next()
            {
                return elements.Get(currentIndex++);
            }
        }
    }
}
