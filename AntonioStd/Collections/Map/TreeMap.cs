using AntonioStd.Collections.Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Map
{
    class TreeMap<K, T> : AbstractMap<K, T>, IMutableMap<K, T>
    {
        private Node<K, T> root;
        private IComparer<K> comparer;

        public TreeMap(IComparer<K> comparer)
        {
            this.comparer = comparer;
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public override T Get(K key)
        {
            T innerGet(Node<K, T> currentNode)
            {
                if (currentNode == null)
                {
                    return default(T);
                }
                else if (comparer.Compare(key, currentNode.Key) < 0)
                {
                    return innerGet(currentNode.Left);
                }
                else if (comparer.Compare(key, currentNode.Key) > 0)
                {
                    return innerGet(currentNode.Right);
                }
                else
                {
                    return currentNode.Value;
                }
            }

            return innerGet(root);
        }

        public override IIterator<Tuple<K, T>> GetIterator()
        {
            throw new NotImplementedException();
        }

        public IMutableMap<K, T> Put(K key, T value)
        {

            void innerPut(Node<K, T> currentNode)
            {
                if(currentNode == null)
                {
                    currentNode = new Node<K, T>(key, value);
                }
                else if ((comparer.Compare(key, currentNode.Key)) == 0)
                {
                    currentNode.Value = value;
                }
                else if (currentNode.Right == null && comparer.Compare(key, currentNode.Key) > 0)
                {
                    currentNode.Right = new Node<K, T>(key, value);
                }
                else if (currentNode.Left == null && comparer.Compare(key, currentNode.Key) < 0)
                {
                    currentNode.Left = new Node<K, T>(key, value);
                }
                else if (comparer.Compare(key, currentNode.Key) < 0)
                {
                    innerPut(currentNode.Left);
                }
                else if (comparer.Compare(key, currentNode.Key) > 0)
                {
                    innerPut(currentNode.Right);
                }                
            }

            return this;
        }

        public void DepthFirstSearch (Action<K, T> action)
        {
            void innerSearch(Node<K, T> currentNode)
            {
                if (currentNode == null)
                {
                    return;
                }

                action.Invoke(currentNode.Key, currentNode.Value);

                innerSearch(currentNode.Left);
                innerSearch(currentNode.Right);
            }
        }

        private class Node<P, V>
        {
            public Node<P, V> Left { get; set; }
            public Node<P, V> Right { get; set; }

            public P Key { get; }
            public V Value { get; set; }

            public Node(P key, V value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
