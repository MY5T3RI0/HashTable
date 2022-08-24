using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.Model
{
    /// <summary>
    /// Хеш таблица.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TValue">Тип Значения.</typeparam>
    class HashTable<TKey, TValue>
    {
        /// <summary>
        /// Массив элементов хеш таблицы.
        /// </summary>
        private List<Item<TKey, TValue>>[] Items = new List<Item<TKey, TValue>>[100];

        /// <summary>
        /// Список ключей.
        /// </summary>
        private List<TKey> keys = new List<TKey>();

        /// <summary>
        /// Добавить новый элемент.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="value">Значение.</param>
        public void Add(TKey key, TValue value)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

            if (value.Equals(default(TValue)))
            {
                throw new ArgumentNullException(nameof(value), "Значение не может быть нулевым");
            }

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

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="key">Ключ.</param>
        public void Delete(TKey key)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

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

        /// <summary>
        /// Найти элемент.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Искомый элемент.</returns>
        public Item<TKey, TValue> Search(TKey key)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

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

        /// <summary>
        /// Хеширование ключа.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Хеш ключа.</returns>
        private int GetHash(TKey key)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

            return key.GetHashCode() % Items.Length;
        }

    }
}
