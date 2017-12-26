using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    interface IPriorityQueue
    {
        BinaryNode GetValue(int priority); // достать без удаления, если нету то вернет null
        void Add(BinaryNode node);
        void Delete(int priority);
        void Update(int oldPriority, int newPriority); // обновит приоритет
        BinaryNode ExtractMin(); // сразу и удаляет этот ключ
    }

    static class PriorityKeyExtension
    {
        // если есть, то обновить(только если цена новая меньше), если нету - добавить
        public static bool UpdateOrAdd(this IPriorityQueue queue, BinaryNode node, int newPriority)
        {
            var nodeInQueue = queue.GetValue(node.Priority);

            if (nodeInQueue == null)
            {
                queue.Add(new BinaryNode(node.Node, newPriority));
                return true;
            }
            else if (node.Priority > newPriority)
            {
                queue.Update(node.Priority, newPriority);
                return true;
            }
            return false;
        }
    }
}
