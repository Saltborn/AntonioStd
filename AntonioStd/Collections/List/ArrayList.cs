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
                T[] innerProlongedArray = new T[(int)(count * GROUGTH_COEFFICIENT)];

                Array.Copy(innerArray, 0, innerProlongedArray, 0, count);

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
            if (index + 1 >= innerArray.Length)
            {
                T[] innerProlongedArray = new T[(int)(count * GROUGTH_COEFFICIENT)];

                Array.Copy(innerArray, 0, innerProlongedArray, 0, count);

                for (var i = count - 1; 0 < i; i--)
                {
                    innerProlongedArray[i] = innerProlongedArray[i + 1];

                    if (index == i)
                    {
                        innerProlongedArray[i] = value;
                    }
                }
            }
            else
            {
                for (var i = count - 1; 0 < i; i--)
                {
                    innerArray[i] = innerArray[i + 1];

                    if (index == i)
                    {
                        innerArray[i] = value;
                    }
                }
            }

            count++;
        }

        public void Remove(int index)
        {
            for (var i = count - 1; index == i; i--)
            {
                var temporary = innerArray[i + 1];
                innerArray[i + 1] = innerArray[i];
                innerArray[i] = temporary;

                if (index == i)
                {
                    count--;
                }
            }
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
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > $count. Actual index = $index");
            }

            innerArray[index] = value;
        }

        public T Get(int index)
        {
            if (index > count-1 || index < 0)
            {
                throw new IndexOutOfRangeException($"Invalid index Argument. Expected 0 < index > $count. Actual index = $index");
            }

            return innerArray[index-1];
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ArrayList<T>);
        }

        public bool Equals(ArrayList<T> other)
        {
            return other != null &&
                   EqualityComparer<T[]>.Default.Equals(innerArray, other.innerArray) &&
                   count == other.count;
        }

        public override int GetHashCode()
        {
            var hashCode = -1730768040;
            hashCode = hashCode * -1521134295 + EqualityComparer<T[]>.Default.GetHashCode(innerArray);
            hashCode = hashCode * -1521134295 + count.GetHashCode();
            return hashCode;
        }

        class ArrayListIterator<T> : IIterator<T>
        {
            private int currentIndex = 0;
            private ArrayList<T> elements;

            public ArrayListIterator(ArrayList<T> elements)
            {
                this.elements = elements;
            }

            public bool HasNext()
            {
                return currentIndex <= elements.Count();
            }

            public T Next()
            {
                return elements.Get(currentIndex++);
            }
        }
    }
}
