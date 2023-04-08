using OwnWebApiTest.Algorythms.Interface;
using System.Diagnostics;
using OwnWebApiTest.Models;

namespace OwnWebApiTest.Algorythms
{
    public class TreeSort : ITreeSort
    {
        Node root;
        public TreeSort()
        {
            root = null;
        }
        void insert(int key)
        {
            root = insertRec(root, key);
        }
        Node insertRec(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            if (key < root.key)
                root.left = insertRec(root.left, key);
            else if (key > root.key)
                root.right = insertRec(root.right, key);

            return root;
        }
        void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.Write(root.key + " ");
                inorderRec(root.right);
            }
        }
        void treeins(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                insert(arr[i]);
            }

        }
        public DataSetResponse Sort(int[] numbers)
        {
            long time;
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            TreeSort tree = new TreeSort();

            tree.treeins(numbers);
            watch.Stop();
            time = watch.ElapsedTicks;
            DataSetResponse data = new DataSetResponse() { Name = "Tree Sort", Sorted = numbers, Time = time };
            return data;
            //tree.inorderRec(tree.root); // wyświetlanie
        }
    }
    public class Node
    {
        public int key;
        public Node left, right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }
}
