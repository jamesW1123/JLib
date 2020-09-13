using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLib
{
    public class BinaryTree<T, V>
    {
        private Node root;
        private static readonly bool RED = true;
        private static readonly bool BLACK = false;


        private class Node
        {
            T key;
            V value;
            Node left, right;
            int N;
            bool color;

            Node(T key, V value, int N, bool color)
            {
                this.key = key;
                this.value = value;
                this.N = N;
                this.color = color;
            }
        }
    }
}
