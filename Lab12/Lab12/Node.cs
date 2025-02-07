using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Node<T>
    {
        T value;
        Node<T> left;
        Node<T> right;

        public T Value { get { return value; }
            set { this.value = value; }
        }
        public Node<T> Left { get { return left; }
            set { this.left = value; }

        }
        public Node<T> Right { get { return right; }
            set { this.right = value; }
        }

        public Node(T value, Node<T> left = default, Node<T> right = default)
        {
            Value = value;
            Left = left;
            Right = right;
        }

    }
}
