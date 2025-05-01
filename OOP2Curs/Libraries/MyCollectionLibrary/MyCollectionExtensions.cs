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
            if (hashTable == null)
                throw new ArgumentNullException(nameof(hashTable));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
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
            Func<double, double, double> agregateOperation, bool calculateAverage = false) 
        {
            if (hashTable == null)
                throw new ArgumentNullException(nameof(hashTable));
            if (itemToDouble == null)
                throw new ArgumentNullException(nameof(itemToDouble));
            if (agregateOperation == null)
                throw new ArgumentNullException(nameof(agregateOperation));
            double result = 0;
            int count = 0;
            foreach (KeyValuePair<TKey, TVal> item in hashTable)
            {
                result = agregateOperation(itemToDouble(item), result);
                count++;
            }

            if (calculateAverage)
            {
                if (count == 0)
                    throw new InvalidOperationException("Коллекция пуста, невозможно вычислить среднее значение.");
                return result / count;
            }


            return result;
        }

        public static IEnumerable<KeyValuePair<TKey, TVal>> Order<TKey, TVal, TSortCondition>(
            this MyCollection<TKey, TVal> collection,
            Func<KeyValuePair<TKey, TVal>, TSortCondition> keySelector,
            bool ascending = false)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            // Фильтруем элементы, где Value != null
            var filteredCollection = collection.Where(item => item.Value != null);

            if (ascending)
                return filteredCollection.OrderByDescending(keySelector);            
            else
                return filteredCollection.OrderBy(keySelector);
        }
    }
}
