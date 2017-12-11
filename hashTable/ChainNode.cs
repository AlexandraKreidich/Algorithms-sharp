using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class ChainNode
    {
        private KeyedItem item;
        private ChainNode next;

        public ChainNode(KeyedItem _item, ChainNode _next = null)
        {
            this.item = _item;
            this.next = _next;
        }

        public ChainNode(ChainNode _node)
        {
            this.item = _node.GetItem();
            this.next = _node.GetNext();
        }
        
        public void SetNextChainNode(ChainNode _item)
        {
            this.next = _item;
        }

        public KeyedItem GetItem()
        {
            return this.item;
        }

        public ChainNode GetNext()
        {
            return this.next;
        }
    }
}
