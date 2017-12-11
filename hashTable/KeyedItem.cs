using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    using KeyType = System.Int64; //тип ключа

    class KeyedItem
    {
        public KeyedItem(KeyType _searchKey)
        {
            this.searchKey = _searchKey;
        }

        public KeyType GetKey()
        {
            return this.searchKey;
        }

        private KeyType searchKey; //генерируется рандомно в диапазоне от 0 до 10^10
    }
}
