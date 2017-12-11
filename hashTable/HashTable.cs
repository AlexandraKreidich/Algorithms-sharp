using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    using TableItemType = KeyedItem; //тип хранимого элемента

    using HashTableType = ChainNode; //тип элементов хеш-таблицы

    class HashTable
    {
        public HashTable()
        {
            this.table = new HashTableType[(int)HashTableSize.size];
        }

        public HashTable(HashTable table){}

        //public bool TableIsEmpty() { }
    
        public bool TableInsert(TableItemType _newItem)
        {
           
                ChainNode node = new ChainNode(_newItem);
                int key = this.HashIndex(_newItem.GetKey());
                if (this.table[key] != null)
                {
                    ChainNode tmp = this.table[key];
                    node.SetNextChainNode(tmp);
                    this.table[key] = node;
                }
                else
                {
                    this.table[key] = node;
                }
                this.NumberOfElements++;
                return true;
            
        }

        public void ShowHashTable()
        {
            int length = (int)HashTableSize.size;
            for(int i=0; i<length; i++)
            {
                if(this.table[i] != null)
                {
                    Console.Write("Номер элемента массива: " );
                    Console.Write(i);
                    ChainNode p = this.table[i];
                    while (p != null)
                    {
                        Console.Write(" -> ");
                        Console.Write(p.GetItem().GetKey());
                        p = p.GetNext();
                    }
                    Console.WriteLine();
                }
            }
        }

        //удаление элемента
        public bool TableDelete(long searchKey)
        {
            int key = this.HashIndex(searchKey);
            ChainNode currNode = this.table[key];
            ChainNode beforeCurrentNode = null;
 
            while (currNode != null && currNode.GetItem().GetKey() != searchKey)
            {
                beforeCurrentNode = currNode;
                currNode = currNode.GetNext();
            }
            if (currNode == null)
            {
                Console.WriteLine("Error, no such Item");
                return false;
            }
            else
            {
                if (beforeCurrentNode == null)
                {
                    this.table[key] = null;
                }
                else
                {
                    beforeCurrentNode.SetNextChainNode(currNode.GetNext());
                }
                this.NumberOfElements--;
                return true;
            }
            
        }

        //tableItem - то, куда извлечём данные из хеш-таблицы
        public TableItemType TableRetrieve(long searchKey)
        {
            TableItemType tableItem = null;
            int key = this.HashIndex(searchKey);
            ChainNode p = this.table[key];
            while (p!=null && p.GetItem().GetKey() != searchKey)
            {
                p = p.GetNext();
            }
            if(p == null)
            {
                Console.WriteLine("Error, no such Item");
            }else
            {
                tableItem = p.GetItem();
            }
            return tableItem;
        } 

        //возвращает номер в массиве, где хранить данные
        private int HashIndex(long searchKey)
        {
            return (int)(searchKey % (int)HashIndexNumber.number);
        } 

        private enum HashTableSize { size = 97 }

        private enum HashIndexNumber { number = 97}

        private HashTableType[] table;

        private int NumberOfElements = 0;
    }
}
