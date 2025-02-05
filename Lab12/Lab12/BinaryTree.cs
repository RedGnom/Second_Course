using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class BinaryTree<T> : ICollection<T>
    {
        Node<T> root;
        int count;
        private readonly IComparer<T> comparer;
        public int Count { get; private set; }
        public bool IsReadOnly => false;
        public BinaryTree() {
            comparer = comparer ?? Comparer<T>.Default;
            root = null;
            count = 0;
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
            Count++;

        }
        public bool Remove(T item)
        {
            Console.WriteLine("В разработке");
            return false;
        }
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        public bool Contains(T item)
        {
            Node<T> current = root;

            while (current != null)
            {
                int compareResult = comparer.Compare(item, current.Value);

                if (compareResult == 0) // Найден элемент
                {
                    return true;
                }
                else if (compareResult < 0) // Ищем в левом поддереве
                {
                    current = current.Left;
                }
                else // Ищем в правом поддереве
                {
                    current = current.Right;
                }
            }

            return false; // Элемент не найден
        }



    }
}
