using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree();
        }

        private static void BinarySearchTree()
        {
            BSTNode root = null;
        RESTARTLABEL:
            Console.Clear();
            System.Console.Write("*********MENU************\n1.Print the BinarySearchTree\n2.Add\n3.Delete\n4.Find\n5.Find Maximum\n6.Find Minimum\n");
            int choice;
            Int32.TryParse(System.Console.ReadLine().Trim(), out choice);

            switch (choice)
            {
                case 1: BSTNode.CompleteTheTreeLevelOrderTraversal(root);
                    System.Console.ReadLine().Trim();
                    break;
                    
                case 2:
                    System.Console.WriteLine("Enter the value to Insert");
                    int data;
                    Int32.TryParse(System.Console.ReadLine().Trim(), out data);
                    root=BSTNode.Insert(root, data);
                    break;
                case 4:
                case 5:
                case 6:
                default: System.Console.WriteLine("Invalid Choice");
                    goto RESTARTLABEL;

            }
            goto RESTARTLABEL;
        }
    }
}
