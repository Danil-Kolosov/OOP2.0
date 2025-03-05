using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollectionLibrary
{
    public static class MyCollectionExtensions
    {               
        public static IEnumerable<KeyValuePair<TKey, TVal>> SelectionOnCondition<TKey, TVal>(
            this MyCollection<TKey, TVal> hashTable, Func<KeyValuePair<TKey, TVal>, bool> predicate)
        {
            foreach (KeyValuePair<TKey, TVal> item in hashTable)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static double MyAggregate<TKey, TVal>
            (this MyCollection<TKey, TVal> hashTable, Func<KeyValuePair<TKey, TVal>, double> itemToDouble,
            Func<double, double, double> agregateOperation) 
        {
            double result = 0;
            foreach (KeyValuePair<TKey, TVal> item in hashTable)
            {
                result = agregateOperation(itemToDouble(item), result);
            }
            return result;
        }

        public static double MyAverage<TKey, TVal>
            (this MyCollection<TKey, TVal> hashTable, Func<KeyValuePair<TKey, TVal>, double> itemToDouble)
        {
            double result = 0;
            foreach (KeyValuePair<TKey, TVal> item in hashTable)
            {
                result += (itemToDouble(item));
            }
            return result/hashTable.Count;
        }

        
        public static IEnumerable<KeyValuePair<TKey, TValue>> Order<TKey, TValue>(
            this MyCollection<TKey, TValue> hashTable,
            Func<KeyValuePair<TKey, TValue>, object> keySelector,
            bool descending = false)
        {
            var items = hashTable.ToList();

            if (descending)
                return items.OrderByDescending(keySelector);
            return items.OrderBy(keySelector);
        }

        // Преобразование MyCollection в List для сортировки
        private static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this MyCollection<TKey, TValue> collection)
        {
            var list = new List<KeyValuePair<TKey, TValue>>();
            foreach (var item in collection)
            {
                list.Add(item);
            }
            return list;
        }


        //public static IEnumerable<KeyValuePair<TKey, TValue>> Order<TKey, TValue>(
        //    this MyCollection<TKey, TValue> hashTable, Func<KeyValuePair<TKey, TValue>, object> keySelector, bool descending = false)
        //{
        //    if (descending)
        //        return hashTable.OrderByDescending(keySelector);
        //    return hashTable.OrderBy(keySelector);
        //}
    }
}



//тут вот товрищь предлагал
/*
 
    public class MyHashTable<TKey, TValue>
{
    private Dictionary<TKey, TValue> items = new Dictionary<TKey, TValue>();

    public void Add(TKey key, TValue value)
    {
        items.Add(key, value);
    }

    // Доступ к внутреннему словарю
    public Dictionary<TKey, TValue> Items => items;
}

public static class MyHashTableExtensions
{
    // a) Метод расширения для выборки данных по условию
    public static IEnumerable<KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
        this MyHashTable<TKey, TValue> hashTable, Func<KeyValuePair<TKey, TValue>, bool> predicate)
    {
        foreach (var item in hashTable.Items)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    // b) Метод расширения для агрегирования данных
    public static double Average(this MyHashTable<int, double> hashTable)
    {
        return hashTable.Items.Values.Average();
    }

    public static double Sum(this MyHashTable<int, double> hashTable)
    {
        return hashTable.Items.Values.Sum();
    }

    public static double Max(this MyHashTable<int, double> hashTable)
    {
        return hashTable.Items.Values.Max();
    }

    public static double Min(this MyHashTable<int, double> hashTable)
    {
        return hashTable.Items.Values.Min();
    }

    // c) Метод расширения для сортировки коллекции
    public static IEnumerable<KeyValuePair<TKey, TValue>> OrderBy<TKey, TValue>(
        this MyHashTable<TKey, TValue> hashTable, Func<KeyValuePair<TKey, TValue>, object> keySelector)
    {
        return hashTable.Items.OrderBy(keySelector);
    }

    public static IEnumerable<KeyValuePair<TKey, TValue>> OrderByDescending<TKey, TValue>(
        this MyHashTable<TKey, TValue> hashTable, Func<KeyValuePair<TKey, TValue>, object> keySelector)
    {
        return hashTable.Items.OrderByDescending(keySelector);
    }
}

class Program
{
    static void Main()
    {
        MyHashTable<int, double> myHashTable = new MyHashTable<int, double>();
        myHashTable.Add(1, 10.5);
        myHashTable.Add(2, 20.0);
        myHashTable.Add(3, 15.5);
        myHashTable.Add(4, 25.0);

        // a) Выборка данных по условию
        var filteredItems = myHashTable.Where(item => item.Value > 15);
        Console.WriteLine("Элементы, значение которых больше 15:");
        foreach (var item in filteredItems)
        {
            Console.WriteLine($"Ключ: {item.Key}, Значение: {item.Value}");
        }

        // b) Агрегирование данных
        Console.WriteLine($"Среднее значение: {myHashTable.Average()}");
        Console.WriteLine($"Сумма значений: {myHashTable.Sum()}");
        Console.WriteLine($"Максимальное значение: {myHashTable.Max()}");
        Console.WriteLine($"Минимальное значение: {myHashTable.Min()}");

        // c) Сортировка коллекции
        var sortedItems = myHashTable.OrderBy(item => item.Value);
        Console.WriteLine("Элементы, отсортированные по возрастанию:");
        foreach (var item in sortedItems)
        {
            Console.WriteLine($"Ключ: {item.Key}, Значение: {item.Value}");
        }
    }
}
 
 */
