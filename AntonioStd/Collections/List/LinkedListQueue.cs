using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.List
{
    public class LinkedListQueue<T> : AbstractCollection<T>, IQueue<T>
    {
        private LinkedList<T> linkedList = LinkedList<T>.Of();

        public override int Count
        {
            get
            {
                return linkedList.Count ;
            }
            protected set { }
        }

        public void Clear()
        {
            linkedList.Clear();
        }

        public T Dequeue()
        {
            var head = linkedList.Head;

            linkedList.Remove(0);

            return head;   
        }

        public IQueue<T> Enqueue(T value)
        {
            linkedList.Add(value);

            return this;
        }

        public override IIterator<T> GetIterator()
        {
            return linkedList.GetIterator();
        }

        public T Peek()
        {
            return linkedList.Head;
        }
    }
}
