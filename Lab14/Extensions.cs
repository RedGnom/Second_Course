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
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (string.IsNullOrEmpty(country)) throw new ArgumentException("Country cannot be null or empty", nameof(country));

            return list.SelectMany(dict => dict.Values) 
                       .Where(city => city.Country == country);
        }

    }
}
