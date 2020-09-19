using System;
using System.Collections;
using System.Collections.Generic;

namespace JLib
{
    public class BinaryTree<E> where E : IComparable<E>
    {

        protected TreeNode<E> root;
        protected int size = 0;

        /** Create a default binary tree */
        public BinaryTree()
        {
        }

        /** Create a binary tree from an array of objects */
        public BinaryTree(IList<E> objects)
        {
            for (int i = 0; i < objects.Count; i++)
                insert(objects[i]);
        }

        /** Returns true if the element is in the tree */
        public bool search(E e)
        {
            TreeNode<E> current = root; // Start from the root

            while (current != null)
            {
                if (e.CompareTo(current.element) < 0)
                {
                    current = current.left;
                }
                else if (e.CompareTo(current.element) > 0)
                {
                    current = current.right;
                }
                else // element matches current.element
                    return true; // Element is found
            }

            return false;
        }

        /** Insert element o into the binary tree
    * Return true if the element is inserted successfully */
        public bool insert(E e)
        {
            if (root == null)
                root = createNewNode(e); // Create a new root
            else
            {
                // Locate the parent node
                TreeNode<E> parent = null;
                TreeNode<E> current = root;
                while (current != null)
                    if (e.CompareTo(current.element) < 0)
                    {
                        parent = current;
                        current = current.left;
                    }
                    else if (e.CompareTo(current.element) > 0)
                    {
                        parent = current;
                        current = current.right;
                    }
                    else
                        return false; // Duplicate node not inserted

                // Create the new node and attach it to the parent node
                if (e.CompareTo(parent.element) < 0)
                    parent.left = createNewNode(e);
                else
                    parent.right = createNewNode(e);
            }

            size++;
            return true; // Element inserted successfully
        }

        /** Delete an element from the binary tree.
       * Return true if the element is deleted successfully
       * Return false if the element is not in the tree */
        public bool delete(E e)
        {
            // Locate the node to be deleted and also locate its parent node
            TreeNode<E> parent = null;
            TreeNode<E> current = root;
            while (current != null)
            {
                if (e.CompareTo(current.element) < 0)
                {
                    parent = current;
                    current = current.left;
                }
                else if (e.CompareTo(current.element) > 0)
                {
                    parent = current;
                    current = current.right;
                }
                else
                    break; // Element is in the tree pointed at by current
            }

            if (current == null)
                return false; // Element is not in the tree

            // Case 1: current has no left child
            if (current.left == null)
            {
                // Connect the parent with the right child of the current node
                if (parent == null)
                {
                    root = current.right;
                }
                else
                {
                    if (e.CompareTo(parent.element) < 0)
                        parent.left = current.right;
                    else
                        parent.right = current.right;
                }
            }
            else
            {
                // Case 2: The current node has a left child
                // Locate the rightmost node in the left subtree of
                // the current node and also its parent
                TreeNode<E> parentOfRightMost = current;
                TreeNode<E> rightMost = current.left;

                while (rightMost.right != null)
                {
                    parentOfRightMost = rightMost;
                    rightMost = rightMost.right; // Keep going to the right
                }

                // Replace the element in current by the element in rightMost
                current.element = rightMost.element;

                // Eliminate rightmost node
                if (parentOfRightMost.right == rightMost)
                    parentOfRightMost.right = rightMost.left;
                else
                    // Special case: parentOfRightMost == current
                    parentOfRightMost.left = rightMost.left;
            }

            size--;
            return true; // Element deleted successfully
        }


        protected TreeNode<E> createNewNode(E e)
        {
            return new TreeNode<E>(e);
        }

        /** Remove all elements from the tree */
        public void clear()
        {
            root = null;
            size = 0;
        }

        /** Get the number of nodes in the tree */
        public int getSize()
        {
            return size;
        }

        /** Returns the root of the tree */
        public TreeNode<E> getRoot()
        {
            return root;
        }

        /** Inorder traversal from the root */
        public List<E> inorder()
        {
            List<E> result = new List<E>();
            inorder(root, ref result);
            return result;
        }

        /** Inorder traversal from a subtree */
        protected void inorder(TreeNode<E> root, ref List<E> result)
        {

            if (root == null) return;
            inorder(root.left, ref result);
            result.Add(root.element);
            inorder(root.right, ref result);
        }
        
        /** Postorder traversal from the root */
        public List<E> postorder()
        {
            List<E> result = new List<E>();
            postorder(root, ref result);
            return result;
        }

        /** Postorder traversal from a subtree */
        protected void postorder(TreeNode<E> root, ref List<E> result)
        {
            if (root == null) return;
            postorder(root.left, ref result);
            postorder(root.right, ref result);
            result.Add(root.element);
        }

        /** Preorder traversal from the root */
        public List<E> preorder()
        {
            List<E> result = new List<E>();
            preorder(root, ref result);
            return result;
        }

        /** Preorder traversal from a subtree */
        protected void preorder(TreeNode<E> root, ref List<E> result)
        {
            if (root == null) return;
            result.Add(root.element);
            preorder(root.left, ref result);
            preorder(root.right, ref result);
        }

        /** Breadth-first traversal from the root */
        public List<E> breadthFirst()
        {
            List<E> result = new List<E>();
            breadthFirst(root, ref result);
            return result;
        }

        /** Breadth-first traversal from the root */
        protected void breadthFirst(TreeNode<E> root, ref List<E> result)
        {

            Queue<TreeNode<E>> q = new Queue<TreeNode<E>>();
            if (root == null) return;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode<E> n = (TreeNode<E>)q.Dequeue();
                result.Add(root.element);
                if (n.left != null)
                    q.Enqueue(n.left);
                if (n.right != null)
                    q.Enqueue(n.right);
            }
        }

        /** This inner class is static, because it does not access 
          any instance members defined in its outer class */
        public class TreeNode<E>
        {

            public E element { get; set; }
            public TreeNode<E> left { get; set; }
            public TreeNode<E> right { get; set; }

            public TreeNode(E e)
            {
                element = e;
            }
        }

        /** Returns a path from the root leading to the specified element */
        //public ArrayList<TreeNode<E>> path(E e)
        //{
        //    ArrayList<TreeNode<E>> list = new ArrayList<>();
        //    TreeNode<E> current = root; // Start from the root

        //    while (current != null)
        //    {
        //        list.add(current); // Add the node to the list
        //        if (e.CompareTo(current.element) < 0)
        //        {
        //            current = current.left;
        //        }
        //        else if (e.CompareTo(current.element) > 0)
        //        {
        //            current = current.right;
        //        }
        //        else
        //            break;
        //    }

        //    return list; // Return an array list of nodes
        //}


        /** Obtain an iterator. Use inorder. */
        //public IEnumerator<E> iterator()
        //{
        //    return new InorderIterator();
        //}

        // Inner class InorderIterator
        //class InorderIterator : IEnumerator<E>
        //{
        //    // Store the elements in a list
        //    private List<E> list = new List<E>();
        //    private int current = 0; // Point to the current element in list

        //    public E Current => throw new NotImplementedException();

        //    object IEnumerator.Current => throw new NotImplementedException();

        //    public InorderIterator()
        //    {
        //        inorder(); // Traverse binary tree and store elements in list
        //    }

        //    /** Inorder traversal from the root*/
        //    private void inorder()
        //    {
        //        inorder(root);
        //    }

        //    /** Inorder traversal from a subtree */
        //    private void inorder(TreeNode<E> root)
        //    {
        //        if (root == null) return;
        //        inorder(root.left);
        //        list.Add(root.element);
        //        inorder(root.right);
        //    }

        //    /** More elements for traversing? */
        //    public bool hasNext()
        //    {
        //        if (current < list.Count)
        //            return true;

        //        return false;
        //    }

        //    /** Get the current element and move to the next */
        //    public E next()
        //    {
        //        return list.(current++);
        //    }

        //    /** Remove the current element */
        //    public void remove()
        //    {
        //        delete(list.Find(current)); // Delete the current element
        //        list.clear(); // Clear the list
        //        inorder(); // Rebuild the list
        //    }

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool MoveNext()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Reset()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}


    }
}
