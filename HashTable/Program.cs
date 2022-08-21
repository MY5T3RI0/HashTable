using HashTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable<int, string>();

            hashTable.Add(1, "Женя");
            hashTable.Add(2, "Миша");
            hashTable.Add(3, "Саша");
            hashTable.Add(4, "Люся");
            hashTable.Add(101, "Оля");

            hashTable.Delete(4);

            Console.WriteLine(hashTable.Search(2));

            Console.WriteLine(hashTable.Search(4));

            Console.WriteLine(hashTable.Search(1));

            Console.WriteLine(hashTable.Search(101));

            Console.ReadLine();
        }
    }
}
