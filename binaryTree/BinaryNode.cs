using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    using TNode = System.Int32;

    public enum NodePosition
    {
        left,
        right,
        center
    }

    class BinaryNode
    {
        public BinaryNode Left { get; set; } = null;
        public BinaryNode Right { get; set; } = null;
        public TNode Key { get; set; } = 0;
        public int Height { get; set; } = 0; //высота поддерева с корнем в данном узле

        public String Value { get; set; } = null;

        public BinaryNode(TNode key, String value = null)
        {
            if(value == null)
            {
                Value = key.ToString() + "value";
            }

            Key = key;
            Left = null;
            Right = null;
        }

        public BinaryNode(BinaryNode node)
        {
            Key = node.Key;
            Left = node.Left;
            Right = node.Right;
            Value = node.Value;
        }

        private void PrintValue(string value, NodePosition nodePostion)
        {
            switch (nodePostion)
            {
                case NodePosition.left:
                    PrintLeftValue(value);
                    break;
                case NodePosition.right:
                    PrintRightValue(value);
                    break;
                case NodePosition.center:
                    Console.WriteLine(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void PrintLeftValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("L:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintRightValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty)
        {

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }

            var stringValue = empty ? "-" : Key.ToString();
            PrintValue(stringValue, nodePosition);

            if (!empty && (this.Left != null || this.Right != null))
            {
                if (this.Left != null)
                    this.Left.PrintPretty(indent, NodePosition.left, false, false);
                else
                    PrintPretty(indent, NodePosition.left, false, true);

                if (this.Right != null)
                    this.Right.PrintPretty(indent, NodePosition.right, true, false);
                else
                    PrintPretty(indent, NodePosition.right, true, true);
            }
        }

        public static int BFactor(BinaryNode node) //вычисляет balance factor заданного узла
        {
            if (node.Right != null && node.Left != null)
            {
                return node.Right.Height - node.Left.Height;
            }
            else if (node.Right != null && node.Left == null)
            {
                return node.Right.Height;
            }
            else if (node.Right == null && node.Left != null)
            {
                return -node.Left.Height;
            }
            else
            {
                //Console.WriteLine("BFactor -> левый и правый потомки нулевые");
                return 0;
            }
            
        }

        public static void FixHeight(BinaryNode node) // восстанавливает корректное значение поля height заданного узла
        {
            //Console.Write("FixHeight for -> ");
            //Console.WriteLine(node.Key);

            int left = (node.Left != null) ? node.Left.Height : 0;
            int right = (node.Right != null) ? node.Right.Height : 0;

            if (node.Left != null || node.Right != null)
            {
                //Console.Write("Height -> ");
                node.Height = ((left > right) ? left : right) + 1;
                //Console.WriteLine(node.Height);
            }
            else
            {
                //Console.WriteLine("FixHeight -> 0");
                node.Height = 0;
            }
        }
    }
}
