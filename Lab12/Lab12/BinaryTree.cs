using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    [Serializable]
    public class BinaryTree<T> : ICollection<T>, IEnumerable<T>, ICloneable
    {
        private Node<T> root;
        int count;
        private  IComparer<T> comparer;
        public int Count
        {
            get { return count; } 
            private set { count = value; }
        }


        public Node<T> Root
        {
            get { return root; }
            private set { root = value; }
        }

        public bool IsReadOnly => false;
        public BinaryTree() {
            comparer = new LAB10_lib.Comparer() as IComparer<T>;
            root = null;
            count = 0;
        }
        public BinaryTree(BinaryTree<T> tree)
        {
            comparer = new LAB10_lib.Comparer() as IComparer<T>;
            root = null;
            count = tree.Count;
            foreach (var item in tree.TraversePreOrder())
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
            return TraversePreOrder().GetEnumerator();
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private IEnumerable<T> TraversePreOrder()
        {
            if (root == null)
            {
                yield break;
            }

            var enumerator = new Numerator<T>(root);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        //private IEnumerable<T> TraversePreOrder()
        //{

        //    //if (root == null) yield break;

        //    //Stack<Node<T>> stack = new Stack<Node<T>>();
        //    //stack.Push(root);

        //    //while (stack.Count > 0)
        //    //{
        //    //    Node<T> current = stack.Pop();
        //    //    yield return current.Value; 

        //    //    if (current.Right != null) stack.Push(current.Right); 
        //    //    if (current.Left != null) stack.Push(current.Left);  
        //    //}
        //}


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
            foreach (var item in TraversePreOrder())
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


        private class Numerator<T> : IEnumerator<T>
        {
            private Node<T> root;
            private Stack<Node<T>> stack;
            private Node<T> current;

            public Numerator(Node<T> root)
            {
                this.root = root;
                stack = new Stack<Node<T>>();
                Reset();
            }

            public T Current
            {
                get
                {
                    if (current == null)
                        throw new InvalidOperationException("Нумератор не на корне или достиг конца.");
                    return current.Value;
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (stack.Count == 0)
                    return false;

                current = stack.Pop();

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }

                return true;
            }

            public void Reset()
            {
                stack.Clear();
                current = null;
                if (root != null)
                {
                    stack.Push(root);
                }
            }

            public void Dispose() { }
        }



    }
}
