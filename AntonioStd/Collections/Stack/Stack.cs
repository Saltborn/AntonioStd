using AntonioStd.Collections.List;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Stack
{
    public class Stack<T> : AbstractCollection<T>, IStack<T>
    {
        LinkedList<T> linkedList = LinkedList<T>.Of();

        public override int Count {
            get
            {
                return linkedList.Count;
            }
            protected set { }
        }

        public void Clear()
        {
            linkedList.Clear();
        }

        public override IIterator<T> GetIterator()
        {
            return linkedList.GetIterator();
        }

        public T Peek()
        {
            return linkedList.Tail;
        }

        public T Pop()
        {
            var tail = linkedList.Tail;

            linkedList.Remove(Count - 1);

            return tail;
        }

        public IStack<T> Push(T value)
        {
            linkedList.Add(value);

            return this;
        }
    }
}
