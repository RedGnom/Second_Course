using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB10_lib;
using Lab12;

namespace Lab14
{
    static public class Extensions
    {
        public static IEnumerable<City> GetCitiesByCountry(this List<SortedDictionary<Region, City>> list, string country)
        {
            return list.SelectMany(dict => dict.Values) 
                       .Where(city => city.Country == country);
        }
        public static IEnumerable<City> GetCitiesMoreThan(this List<SortedDictionary<Region, City>> list, int population)
        {
            return list.SelectMany(dict => dict.Values)
                       .Where(city => city.Population > population);
        }
        public static int GetMaxPopulation(this List<SortedDictionary<Region, City>> list)
        {
            return list.Max(dict => dict.Values.Max(city => city.Population));

        }
        public static IEnumerable<IGrouping<string, City>> GroupByCountry(this List<SortedDictionary<Region, City>> list)
        {
            return list.SelectMany(dict => dict.Values)
                .GroupBy(city => city.Country);
        }

        public static IEnumerable<City> GetCitiesByCondition(this BinaryTree<City> tree, Func<City, bool> condition)
        {
            
            return tree
                .Where(city => condition(city));  
        }



    }
}
