using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.Model
{
    class HashTable<TKey, TValue>
    {
        private List<Item<TKey, TValue>>[] Items = new List<Item<TKey, TValue>>[100];

        private List<TKey> keys = new List<TKey>();

        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key))
            {
                throw new ArgumentException("Элемент с таким ключом уже существует", nameof(key));
            }
            var item = new Item<TKey, TValue>(key, value);
            if (Items[GetHash(key)] == null)
            {
                Items[GetHash(key)] = new List<Item<TKey, TValue>>();
                Items[GetHash(key)].Add(item);
                keys.Add(key);
                return;
            }            
            Items[GetHash(key)].Add(item);
            keys.Add(key);
        }

        public void Delete(TKey key)
        {

            if (keys.Contains(key))
            {
                foreach (Item<TKey, TValue> item in Items[GetHash(key)])
                {
                    if (item.Key.Equals(key))
                    {
                        Items[GetHash(key)].Remove(item);
                        keys.Remove(key);
                        return;
                    }
                } 
            }
        }

        public Item<TKey, TValue> Search(TKey key)
        {
            if (keys.Contains(key))
            {
                foreach (Item<TKey, TValue> item in Items[GetHash(key)])
                {
                    if (item.Key.Equals(key))
                    {
                        return item;
                    }
                }
                throw new Exception("Указанный ключ существует, но элемента с таким ключом нет");
            }
            else
            {
                return default;
            }
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % Items.Length;
        }

    }
}
