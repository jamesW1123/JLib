using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLib
{
    class RBNode<T>
    {
        private bool color; //red == true  black == false
        private RBNode<T> parent, left, right;
        private T value;

        public RBNode(T value)
        {

            parent = left = right = null;
            color = true;
            this.value = value;
        }

        public void setParent(RBNode<T> node)
        {
            this.parent = node;
        }

        public RBNode<T> getParent()
        {
            return this.parent;
        }

        public void setLeft(RBNode<T> node)
        {
            this.left = node;
        }

        public RBNode<T> getLeft()
        {
            return this.left;
        }

        public void setRight(RBNode<T> node)
        {
            this.right = node;
        }

        public RBNode<T> getRight()
        {
            return this.right;
        }

        public void changeColor()
        {
            this.color = !this.color;
        }

        public bool isRed()
        {
            return this.color;
        }

        public T getValue()
        {
            return value;
        }
    }
}
