using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB10_lib;
using Lab12;
using Lab14;

namespace Lab14
{
    static public class Extensions
    {
        public static IEnumerable<City> Where(this List<SortedDictionary<Region, City>> list, Func<City, bool> predicate)
        {
            return list.SelectMany(dict => dict.Values)
                       .Where(predicate);
        }

        public static int AggregatePopulation(this List<SortedDictionary<Region, City>> list, Func<IEnumerable<int>, int> aggregationFunc)
        {
            return aggregationFunc(list.SelectMany(dict => dict.Values).Select(city => city.Population));
        }


        public static IEnumerable<IGrouping<TKey, City>> GroupByCondition<TKey>(this List<SortedDictionary<Region, City>> list,
        Func<City, TKey> keySelector)
        {
            return list.SelectMany(dict => dict.Values)
                       .GroupBy(keySelector);
        }

        public static List<T> UnionWith<T>(this List<T> firstList, List<T> secondList,
        Func<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>> unionFunc) 
            {
                return unionFunc(firstList, secondList).ToList(); 
            }


        public static IEnumerable<T> Where<T>(this BinaryTree<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        
        public static TResult AggregateData<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> selector, Func<TResult, TResult, TResult> aggregator)
        {
            TResult result = default(TResult);

            foreach (var item in collection)
            {
                var value = selector(item);
                result = aggregator(result, value);
            }

            return result;
        }

        
        public static IEnumerable<T> SortBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector, bool ascending = true)
            where TKey : IComparable<TKey>
        {
            return ascending ? collection.OrderBy(keySelector) : collection.OrderByDescending(keySelector);
        }

        //public static int Sum<T>(this IEnumerable<T> collection, Func<T, int> selector)
        //{
        //    int sum = 0;
        //    foreach (var item in collection)
        //    {
        //        sum += selector(item);
        //    }
        //    return sum;
        //}



    }
}
