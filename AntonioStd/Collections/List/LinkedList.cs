using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.List
{
    public class LinkedList<T> : IMutableList<T>
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
            tail = new Node<T>(null, tail, value);

            if (head == null)
            {
                head = tail;
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
           
        }

        public int Count()
        {
            return count;
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public IIterator<T> GetIterator()
        {
            return LinkedLIstIterator();
        }

        public void Insert(int index, T value)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public void Set(int index, T value)
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }

        private class Node<V>
        {
            public Node<V> next { get; set; }
            public Node<V> previous { get; set; }
            private V value { get; set; }

            public Node(Node<V> next, Node<V> previous, V value)
            {
                this.next = next;
                this.previous = previous;
                this.value = value;
            }
        }

        private class LinkedListIterator<K> : IIterator<T>
        {
            public bool HasNext()
            {
                throw new NotImplementedException();
            }

            public T Next()
            {
                throw new NotImplementedException();
            }
        }
    }
}
