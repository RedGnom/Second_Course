using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LAB10_lib;

namespace LAB11
{
    
    class TestCollections
    {
        LinkedList<City> col1 = new LinkedList<City>();
        LinkedList<string> col2 = new LinkedList<string>();
        Dictionary<Region, City> col3 = new Dictionary<Region, City>();
        Dictionary<string, City> col4 = new Dictionary<string, City>();
        
        public TestCollections()
        {
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    City city = new City();
                    city.RandomInit();
                    
                    Region region = city.BaseRegion;
                    col3.Add(region, city);
                    col1.AddLast(city);
                    col2.AddLast(city.ToString());

                    col4.Add(region.ToString(), city);
                }
                catch (Exception)
                {
                    
                    i--; // Уменьшаем счетчик, чтобы повторить попытку
                }
            }

        }
        public void ShowCollections()
        {
            Console.WriteLine($"col1.Count: {col1.Count}, col2.Count: {col2.Count}, col3.Count: {col3.Count}, col4.Count: {col4.Count}");
        }
        public void RemoveFirstElement()
        {
            City firstElem = col1.First.Value;
            col1.RemoveFirst();
            col2.RemoveFirst();
            Region key = firstElem.BaseRegion;
            col3.Remove(key);
            col4.Remove(key.ToString());
        }
        public void AddElem(City city)
        {
            Region region = city.BaseRegion;
            if (col3.TryAdd(region, city))
            {
                col4.Add(region.ToString(), city);
                col1.AddLast(city);
                col2.AddLast(city.ToString());
            }

            else
            {
                Console.WriteLine($"Ошибка при добавлении города: Ключ {region.ToString} уже существует.");
            }

        }

        static string FindElemLinkedList<T>(ICollection<T> collection, T item)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool correct = collection.Contains(item);
            stopwatch.Stop();
            if (correct)
            {
                return stopwatch.ElapsedTicks.ToString();
            }
            else { return "Элемент не найден"; }
        }
        public string FindKeyDict<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool contains = dictionary.ContainsKey(key);
            stopwatch.Stop();
            if (contains)
            {
                return stopwatch.ElapsedTicks.ToString();
            }
            else { return "Элемент не найден"; }
        }

        // Метод для измерения времени поиска значения в Коллекция_2
        public string FindValueDict<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TValue value)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool contains = dictionary.Values.Contains(value);
            stopwatch.Stop();
            if (contains)
            {
                return stopwatch.ElapsedTicks.ToString();
            }
            else { return "Элемент не найден"; }
        }
        public void FindTimeCollections()
        {
            City firstElem = col1.First();
            City first = new City(firstElem.Country, firstElem.Name, firstElem.CityName, firstElem.Population);
            Region firstKey = first.BaseRegion;
            City lastElem = col1.Last();
            City last = new City(lastElem.Country, lastElem.Name, lastElem.CityName, lastElem.Population);
            Region lastKey = last.BaseRegion;
            City middleElem = col1.ElementAt(col1.Count/2);
            City middle = new City(middleElem.Country, middleElem.Name, middleElem.CityName, middleElem.Population);
            Region middleKey = middle.BaseRegion;
            City outOfRange = new City("Хасаншин", "Арсен", "Рустамовия", 19);
            Region outOfRangeKey = outOfRange.BaseRegion;

            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"Время поиска первого в связанном списке с обьектами: {FindElemLinkedList(col1, first)} на шаге: {i+1}");
                Console.WriteLine($"Время поиска последнего в связанном списке с обьектами: {FindElemLinkedList(col1, last)}");
                Console.WriteLine($"Время поиска среднего в связанном списке с обьектами: {FindElemLinkedList(col1, middle)}");
                Console.WriteLine($"Время поиска несуществущего обьекта в связанном списке с обьектами: {FindElemLinkedList(col1, outOfRange)}");
            }
        }



    }
}
