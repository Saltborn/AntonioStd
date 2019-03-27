using AntonioStd.Collections.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.List
{
    public class LinkedList<T> : IMutableList<T>, IEquatable<LinkedList<T>>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        private LinkedList(Node<T> head, Node<T> tail, int count)
        {
            this.head = head;
            this.tail = tail;
            this.count = count;
        }

        public static LinkedList<T> Of()
        {
            return new LinkedList<T>(null, null, 0);
        }

        public static LinkedList<T> Of(T head, params T[] values)
        {
            LinkedList<T> linkedList = Of();
            linkedList.Add(head);

            foreach (T value in values)
            {
                linkedList.Add(value);
            }

            return linkedList;
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(null, tail, value);

            if (tail == null)
            {
                tail = head = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            var iterator = GetIterator();
            while (iterator.HasNext())
            {
                var element = iterator.Next();
                if (element.Equals(value))
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

        public T Get(int index)
        {
            return GetNode(index).Value;
        }

        public IIterator<T> GetIterator()
        {
            return new ForwardIterator<T>(head);
        }

        public IIterator<T> GetReverseIterator()
        {
            return new ReverseIterator<T>(tail, count - 1);
        }

        public void Insert(int index, T value)
        {
            Node<T> currentNode = GetNode(index);
            Node<T> insertedNode = new Node<T>(currentNode, currentNode.Previous, value);

            if (currentNode.Previous != null)
            {
                currentNode.Previous.Next = insertedNode;
            }

            if (currentNode.Next != null)
            {
                currentNode.Previous = insertedNode;
            }

            count++;
        }

        public void Remove(int index)
        {
            Node<T> currentNode = GetNode(index);

            if (currentNode.Previous != null)
            {
                currentNode.Previous.Next = currentNode.Next;
            }

            if (currentNode.Next != null)
            {
                currentNode.Next.Previous = currentNode.Previous;
            }

            count--;
        }

        public void Set(int index, T value)
        {
            GetNode(index).Value = value;
        }

        public T[] ToArray()
        {
            T[] array = new T[count];

            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                array[iterator.Index] = iterator.Next();
            }

            return array;
        }

        private Node<T> GetNode(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException($"Expcected index in range from 0 to {count}. But got {index}");
            }

            Node<T> currentNode = null;

            AbstractLinkedListIterator<T> iterator;

            if (index < count / 2)
            {
                iterator = getForwardLinkedListIterator();
            }
            else
            {
                iterator = getReversetLinkedListIterator();
            }

            while (iterator.HasNext())
            {
                currentNode = iterator.CurrentNode;

                if (iterator.Index == index)
                {
                    break;
                }

                iterator.Next();
            }

            return currentNode;
        }

        private AbstractLinkedListIterator<T> getForwardLinkedListIterator()
        {
            return new ForwardIterator<T>(head);
        }

        private AbstractLinkedListIterator<T> getReversetLinkedListIterator()
        {
            return new ReverseIterator<T>(tail, count - 1);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LinkedList<T>);
        }

        public bool Equals(LinkedList<T> other)
        {
            if (count != other.count)
            {
                return false;
            }

            var iterator = new ZippedIterator<T, T>(GetIterator(), other.GetIterator());

            while (iterator.HasNext())
            {
                (var first, var second) = iterator.Next();

                if (!first.Equals(second))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;

            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                hashCode += iterator.Next().GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[ ");

            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                stringBuilder.Append(iterator.Next());

                if (iterator.HasNext())
                {
                    stringBuilder.Append(", ");
                }
            }

            return stringBuilder.Append(" ]").ToString();
        }

        private class Node<V>
        {
            public Node<V> Next { get; set; }
            public Node<V> Previous { get; set; }
            public V Value { get; set; }

            public Node(Node<V> next, Node<V> previous, V value)
            {
                Next = next;
                Previous = previous;
                Value = value;
            }
        }

        private abstract class AbstractLinkedListIterator<K> : AbstarctIterator<K>
        {
            public Node<K> CurrentNode { get; set; }

            public AbstractLinkedListIterator(Node<K> currentNode, int index) : base(index)
            {
                this.CurrentNode = currentNode;
                this.Index = index;
            }

            public override bool HasNext()
            {
                return CurrentNode != null;
            }
        }

        private class ReverseIterator<K> : AbstractLinkedListIterator<K>
        {
            public ReverseIterator(Node<K> currentNode, int index) : base(currentNode, index)
            {
            }

            public override K Next()
            {
                var currentValue = CurrentNode.Value;

                CurrentNode = CurrentNode.Previous;

                Index--;

                return currentValue;
            }
        }

        private class ForwardIterator<K> : AbstractLinkedListIterator<K>
        {
            public ForwardIterator(Node<K> currentNode) : base(currentNode, 0)
            {
            }

            public override K Next()
            {
                var currentValue = CurrentNode.Value;

                CurrentNode = CurrentNode.Next;

                Index++;

                return currentValue;
            }
        }
    }
}
