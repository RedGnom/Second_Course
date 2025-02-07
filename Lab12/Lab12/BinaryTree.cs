using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class BinaryTree<T> : ICollection<T>, IEnumerable<T>, ICloneable
    {
        Node<T> root;
        int count;
        private  IComparer<T> comparer;
        public int Count { get; private set; }
        public bool IsReadOnly => false;
        public BinaryTree() {
            comparer = comparer ?? Comparer<T>.Default;
            root = null;
            count = 0;
        }
        public BinaryTree(BinaryTree<T> tree)
        {
            comparer = comparer ?? Comparer<T>.Default;
            root = null;
            count = tree.Count;
            foreach (var item in tree.TraverseInOrder())
            {
                this.Add(item);
            }
        }
        public object Clone()
        {
            return (BinaryTree<T>)this.MemberwiseClone();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return TraverseInOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private IEnumerable<T> TraverseInOrder()
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> current = root;

            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    yield return current.Value;
                    current = current.Right;
                }
            }
        }

        public void Add(T item)
        {
            if (root == null)
            {
                root = new Node<T>(item);
            }
            else
            {
                Node<T> current = root;
                while (true)
                {
                    int compareResult = comparer.Compare(item, current.Value);

                    if (compareResult < 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new Node<T>(item);
                            break;
                        }
                        current = current.Left;
                    }
                    else if (compareResult > 0)
                    {
                        if (current.Right == null)
                        {
                            current.Right = new Node<T>(item);
                            break;
                        }
                        current = current.Right;
                    }
                    else
                    {
                        return; 
                    }
                }
            }
            count++;

        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex + Count > array.Length)
                throw new ArgumentException("Недостаточно места в массиве");

            int index = arrayIndex;
            foreach (var item in TraverseInOrder())
            {
                array[index++] = item;
            }
        }

        public bool Remove(T item)
        {
            Console.WriteLine("В разработке");
            return false;
        }
        public void Clear()
        {
            ClearNode(root);
            root = null;
            Count = 0;
        }
        private void ClearNode(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            // Рекурсивно очищаем левые и правые поддеревья
            ClearNode(node.Left);
            ClearNode(node.Right);

            // Очищаем ссылки на узлы
            node.Left = null;
            node.Right = null;
            node.Value = default(T);
        }
        public bool Contains(T item)
        {
            Node<T> current = root;

            while (current != null)
            {
                int compareResult = comparer.Compare(item, current.Value);

                if (compareResult == 0)
                {
                    return true;
                }
                else if (compareResult < 0) 
                {
                    current = current.Left;
                }
                else 
                {
                    current = current.Right;
                }
            }

            return false; 
        }


        private class Numerator<T>: IEnumerator<T>
        {
            Node<T> begin;
            Node<T> current;
            Stack<Node<T>> DFS;

            public Numerator(Node<T> root)
            {
                begin = root;
                current = begin;
                DFS = new Stack<Node<T>>();
            }
            public T Current
            {
                get { return current.Value; }
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public bool MoveNext()
            {
                if (current == null && DFS.Count == 0)
                {
                    return false;
                }
                if (current != null)
                {
                    DFS.Push(current);
                    current = null;
                }

                if (DFS.Count > 0)
                {
                    current = DFS.Pop();

                    if (current.Right != null)
                    {
                        DFS.Push(current.Right);
                    }
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = null;
                    }

                    return true;
                }

                return false;
            }

            public void Dispose() { }
            public void Reset()
            {
                DFS.Clear();
                current = begin;
            }

        }
    }
}
