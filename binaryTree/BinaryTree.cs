using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    using TNode = System.Int32; 

    class BinaryTree
    {
        public int Height { get; set; } = 0; //количество узлов в дереве
        public BinaryNode Root { get; set; } = null; //корневой элемент

        public BinaryTree(BinaryNode root = null)
        {
            //Height = (root != null) ? 1 : 0;
            Root = root;
        }
        
        // Функция для создания нового узла AVL-дерева
        public static BinaryNode NewNode(TNode item)
        {
            BinaryNode node = new BinaryNode(item);
            return node;
        }

        // Функция для вставки узла в AVL-дерево (рекурсивная)
    
        public static BinaryNode AddTo(BinaryNode node, BinaryNode item)
        {
            if (node == null)
            {
                //Console.WriteLine("AddTo -> newBinaryNode");
                return new BinaryNode(item);
            }
            if (item.Key < node.Key)
            {
                //Console.WriteLine("AddTo -> item < node.key");
                node.Left = AddTo(node.Left, item);
            }
            else
            {
                //Console.WriteLine("AddTo -> item > node.key");
                node.Right = AddTo(node.Right, item);
            }

            //Console.WriteLine("AddTo -> return Balance");
            return Balance(node); // балансировка
        }

        public static String FindNode(BinaryNode root, int k)
        {
            while (root != null)
            {
                if (k <= root.Key || k>=root.Key)
                {
                    if (k == root.Key)
                        return root.Value;
                    else if (k < root.Key)
                        root = root.Left;
                    else root = root.Right;
                }
            }
            return null;
        }

        public static BinaryNode Findmin(BinaryNode node) // поиск узла с минимальным ключом в дереве p 
        {
            if(node.Left != null)
            {
                return Findmin(node.Left);
            }else
            {
                //Console.Write("findmin -> ");
                //Console.WriteLine(node.Key);
                return node;
            }
        }

        public static BinaryNode Removemin(BinaryNode node) // удаление узла с минимальным ключом из дерева p
        {
            if (node.Left == null)
                return node.Right;
            node.Left = Removemin(node.Left);
            return Balance(node);
        }

        public static BinaryNode Remove(BinaryNode node, int k) // удаление ключа k из дерева p
        {
            if (node == null)
            {
                return node;
            }
            if (k < node.Key)
            {
                node.Left = Remove(node.Left, k);
            }
            else if (k > node.Key)
            {
                node.Right = Remove(node.Right, k);
            }
            else //k == node.Key 
            {
                BinaryNode l = node.Left;
                BinaryNode r = node.Right;
                if (r == null) return l;
                BinaryNode min = Findmin(r);
                min.Right = Removemin(r);
                min.Left = l;
                return Balance(min);
            }
	        return Balance(node);
        }

        public static BinaryNode RotateRight(BinaryNode node) // правый поворот вокруг node
        {
            BinaryNode tmp = node.Left;
            node.Left = tmp.Right;
            tmp.Right = node;
            BinaryNode.FixHeight(node);
            BinaryNode.FixHeight(tmp);
            return tmp;

        }

        public static BinaryNode RotateLeft(BinaryNode node) // левый поворот вокруг node
        {
            BinaryNode tmp = node.Right;
            node.Right = tmp.Left;
            tmp.Left = node;
            BinaryNode.FixHeight(node);
            BinaryNode.FixHeight(tmp);
            return tmp;
            
        }

        public static BinaryNode Balance(BinaryNode node) // балансировка узла node
        {
            BinaryNode.FixHeight(node);
            
            if (BinaryNode.BFactor(node) == 2)
            {
                //Console.WriteLine("Balance -> BinaryNode.BFactor(node) == 2");
                if (BinaryNode.BFactor(node.Right) < 0)
                {
                   // Console.WriteLine("RotateRight");
                    node.Right = RotateRight(node.Right);
                }
                //Console.WriteLine("RotateLeft");
                return RotateLeft(node);
            }
            if (BinaryNode.BFactor(node) == -2)
            {
                //Console.WriteLine("Balance -> BinaryNode.BFactor(node) == -2");
                if (BinaryNode.BFactor(node.Left) > 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            //Console.WriteLine("Balance -> return node");
            return node; // балансировка не нужна
        }

        public void Print()
        {
            Root.PrintPretty("", NodePosition.center, true, false);
        }
    }
}
