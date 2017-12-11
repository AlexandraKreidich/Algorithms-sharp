using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Runner
    {
        public static void Menu(HashTable table)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите 1, чтобы вставить значение");
                Console.WriteLine("Введите 2, чтобы удалить значение");
                Console.WriteLine("Введите 3, чтобы извлечь значение");
                Console.WriteLine("Введите 4, чтобы вывести таблицу");
                Console.WriteLine("Введите 5, чтобы выйти");
                var choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1: 
                        Console.WriteLine("Введите число");
                        KeyedItem inputItem = new KeyedItem(int.Parse(Console.ReadLine()));
                        table.TableInsert(inputItem);
                        table.ShowHashTable();
                        break;
                    case 2:
                        Console.WriteLine("Введите число, которое хотите удалить");
                        long itemToDelete = long.Parse(Console.ReadLine());
                        table.TableDelete(itemToDelete);
                        Console.Write("Удаление элемента -> ");
                        Console.WriteLine(itemToDelete);
                        table.ShowHashTable();
                        break;
                    case 3:
                        Console.WriteLine("Введите число, которое хотите извлечь");
                        long key = long.Parse(Console.ReadLine());
                        KeyedItem item = table.TableRetrieve(key);
                        Console.Write("Извлечение элемента -> ");
                        Console.WriteLine(item.GetKey());
                        table.ShowHashTable();
                        break;
                    case 4:
                        table.ShowHashTable();
                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Wrong enter!");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            //Random rng = new Random();
            //bool flag = true;
            //HashTable table = new HashTable();
            //while (flag)
            //{
            //    KeyedItem item = new KeyedItem(rng.Next(0, 1000000000));
            //    flag = table.TableInsert(item);
            //}
            //table.ShowHashTable();
            //Console.ReadKey();
            KeyedItem item_1 = new KeyedItem(200);
            KeyedItem item_2 = new KeyedItem(300);
            KeyedItem item_3 = new KeyedItem(1);
            KeyedItem item_4 = new KeyedItem(2);
            HashTable table = new HashTable();
            table.TableInsert(item_1);
            table.TableInsert(item_2);
            table.TableInsert(item_3);
            table.TableInsert(item_4);
            Menu(table);
        }
    }
}
