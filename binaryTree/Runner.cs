using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Runner
    {

        public static void Menu(BinaryTree tree)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите 1, чтобы вставить элемент в дерево");
                Console.WriteLine("Введите 2, чтобы удалить элемент");
                Console.WriteLine("Введите 3, чтобы найти элемент");
                Console.WriteLine("Введите 4, чтобы вывести дерево");
                Console.WriteLine("Введите 5, чтобы выйти");
                var choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Введите ключ");
                        int key = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите значение");
                        BinaryNode item = new BinaryNode(key, Console.ReadLine());
                        tree.Root = BinaryTree.AddTo(tree.Root, item);
                        break;
                    case 2:
                        Console.WriteLine("Введите ключ для удаления");
                        key = int.Parse(Console.ReadLine());
                        tree.Root = BinaryTree.Remove(tree.Root, key);
                        break;
                    case 3:
                        Console.WriteLine("Введите ключ для поиска");
                        key = int.Parse(Console.ReadLine());
                        String value = BinaryTree.FindNode(tree.Root, key);
                        if (value != null)
                        {
                            Console.Write("value данного элемента -> ");
                            Console.WriteLine(value);
                        }
                        else
                            Console.WriteLine("Такого элемента в дереве нет");
                        break;
                    case 4:
                        tree.Print();
                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree(new BinaryNode(2));
            tree.Root = BinaryTree.AddTo(tree.Root, new BinaryNode(1, "someting"));
            tree.Root = BinaryTree.AddTo(tree.Root, new BinaryNode(3, "someting"));
            tree.Root = BinaryTree.AddTo(tree.Root, new BinaryNode(4, "someting"));
            tree.Root = BinaryTree.AddTo(tree.Root, new BinaryNode(5, "someting"));
            tree.Root = BinaryTree.AddTo(tree.Root, new BinaryNode(6, "someting"));
            tree.Root = BinaryTree.AddTo(tree.Root, new BinaryNode(7, "someting"));
            tree.Root = BinaryTree.AddTo(tree.Root, new BinaryNode(8, "someting"));
            Menu(tree);
        }
    }
}
