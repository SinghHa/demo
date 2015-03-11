using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_BST
{
    public class BSTNode
    {
        //private int data;
        //private BSTNode left;
        //private BSTNode right;

        public int Data { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }

        public static BSTNode Find(BSTNode root, int data)
        {
            if (root == null)
                return null;// When data is not found in the tree.

            if (data < root.Data)
                return Find(root.Left, data);
            else if (data > root.Data)
                return Find(root.Right, data);

            return root;
        }

        public static BSTNode FindMin(BSTNode root)
        {
            if (root == null)
                return null;

            else
                if (root.Left == null)
                    return root;
                else
                    return FindMin(root.Left);
        }

        public static BSTNode FindMax(BSTNode root)
        {
            if (root == null)
                return null;

            else
                if (root.Right == null)
                    return root;
                else
                    return FindMax(root.Right);
        }

        public static BSTNode Insert(BSTNode root, int data)
        {
            if (root == null)
            {
                root = new BSTNode();
                root.Data = data;
                root.Left = null;
                root.Right = null;
            }
            else
            {
                if (data < root.Data)
                    root.Left = Insert(root.Left, data);
                else if (data > root.Data)
                    root.Right = Insert(root.Right, data);
            }
            return root;
        }

        public static void PrintTree(BSTNode node)
        {
            BSTNode current = null;

            if (node != null)
            {
                //Print root
                System.Console.WriteLine("\t\t" + node.Data);
                System.Console.WriteLine("\t       / \\");
                System.Console.WriteLine("\t      /   \\");
                System.Console.WriteLine("\t     /     \\");

                while (node.Left != null || node.Right != null)
                {
                    current = node;

                    //Print left child
                    if (current.Left != null)
                        System.Console.WriteLine("\t    " + current.Left.Data);

                    //Print right child
                    if (current.Left != null)
                        System.Console.WriteLine("       " + current.Right.Data);

                    //New line
                    System.Console.WriteLine();

                    //Go to next node
                    if (current.Left != null)
                        node = current.Left;
                    else
                        node = current.Right;
                }
            }
        }

        public static void PrintTreeNormal(BSTNode node)
        {
            BSTNode current = null;

            if (node != null)
            {
                //Print root
                System.Console.WriteLine("(" + node.Data + ")");

                while (node.Left != null || node.Right != null)
                {
                    current = node;

                    //Print left child
                    if (current.Left != null)
                        System.Console.WriteLine("\t    " + current.Left.Data);

                    //Print right child
                    if (current.Left != null)
                        System.Console.WriteLine("       " + current.Right.Data);

                    //New line
                    System.Console.WriteLine();

                    //Go to next node
                    if (current.Left != null)
                        node = current.Left;
                    else
                        node = current.Right;
                }
            }
        }

        public static void LevelOrderTraversal(BSTNode node)
        {
            Queue<BSTNode> queue = new Queue<BSTNode>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                BSTNode n = queue.Dequeue();
                System.Console.Write("( " + n.Data + " )\t");
                if (n.Left != null)
                    queue.Enqueue(n.Left);
                if (n.Right != null)
                    queue.Enqueue(n.Right);
                System.Console.WriteLine("");
            }
        }

        public static void CompleteTheTreeLevelOrderTraversal(BSTNode node)
        {
            Queue<BSTNode> queue = new Queue<BSTNode>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                if (((queue.Count) & (queue.Count-1)) ==0)
                System.Console.WriteLine("");
                
                bool areAllZeroes=true;
                foreach(BSTNode item in queue)
                {
                    if (item.Data != 0)
                        areAllZeroes = false;
                }
                if (areAllZeroes)
                    break;

                BSTNode n = queue.Dequeue();
                System.Console.Write("( " + n.Data + " )\t");
                if (n.Left != null)
                    queue.Enqueue(n.Left);
                else
                {
                    n.Left = new BSTNode();
                    n.Left.Data = 0;
                    queue.Enqueue(n.Left);
                }
                if (n.Right != null)
                    queue.Enqueue(n.Right);
                else
                {
                    n.Right = new BSTNode();
                    n.Right.Data = 0;
                    queue.Enqueue(n.Right);
                }
            }
        }

        public static void IsBST(BSTNode node)
        {

            
        }
    }
}
