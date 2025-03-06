using Lab12;
using LAB10_lib;
using Lab14;
using System.Linq;
namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            IComparer<Place> placeComparer = new Comparer();


            //            List<SortedDictionary<Region, City>> listOfCountries = new List<SortedDictionary<Region, City>>
            //            {
            //                new SortedDictionary<Region, City>(placeComparer)
            //                {
            //                    { new Region("Япония", "Токио"), new City("Япония", "Токио", "Токио", 13929286) },
            //                    { new Region("Россия", "Свердловская область"), new City("Россия", "Свердловская область", "Екатеринбург", 1500000) },
            //                    { new Region("Россия", "Республика Татарстан"), new City("Россия", "Республика Татарстан", "Казань", 1250000) }
            //                },
            //                new SortedDictionary<Region, City>(placeComparer)
            //                {
            //                    { new Region("Германия", "Бавария"), new City("Германия", "Бавария", "Мюнхен", 1488202) },
            //                    { new Region("США", "Массачусетс"), new City("США", "Массачусетс", "Бостон", 7400000) },
            //                    { new Region("США", "Калифорния"), new City("США", "Калифорния", "Лос-Анджелес", 12800000) }

            //                },
            //                new SortedDictionary<Region, City>(placeComparer)
            //                {
            //                    { new Region("США", "Нью-Йорк"), new City("США", "Нью-Йорк", "Нью-Йорк", 20000000) },
            //                    { new Region("Германия", "Северный Рейн-Вестфалия"), new City("Германия", "Северный Рейн-Вестфалия", "Кёльн", 1085664) },
            //                    { new Region("Германия", "Гамбург"), new City("Германия", "Гамбург", "Гамбург", 1835878) }
            //                },
            //                new SortedDictionary<Region, City>(placeComparer)
            //                {
            //                    { new Region("Россия", "Пермский край"), new City("Россия", "Пермский край", "Пермь", 1000000) },
            //                    { new Region("Япония", "Киото"), new City("Япония", "Киото", "Киото", 1474570) },
            //                    { new Region("Япония", "Осака"), new City("Япония", "Осака", "Осака", 2735146) }
            //                }
            //            };
            //            List<SortedDictionary<Region, City>> anotherListOfCountries = new List<SortedDictionary<Region, City>>
            //{
            //    new SortedDictionary<Region, City>(placeComparer)
            //    {
            //        { new Region("Франция", "Иль-де-Франс"), new City("Франция", "Иль-де-Франс", "Париж", 2148327) },
            //        { new Region("Италия", "Ломбардия"), new City("Италия", "Ломбардия", "Милан", 1378689) },
            //        { new Region("Испания", "Каталония"), new City("Испания", "Каталония", "Барселона", 1664182) }
            //    },
            //    new SortedDictionary<Region, City>(placeComparer)
            //    {
            //        { new Region("США", "Флорида"), new City("США", "Флорида", "Майами", 467963) },
            //        { new Region("Канада", "Онтарио"), new City("Канада", "Онтарио", "Торонто", 2731571) },
            //        { new Region("Канада", "Квебек"), new City("Канада", "Квебек", "Монреаль", 1780000) }
            //    },
            //    new SortedDictionary<Region, City>(placeComparer)
            //    {
            //        { new Region("Германия", "Берлин"), new City("Германия", "Берлин", "Берлин", 3769495) },
            //        { new Region("Великобритания", "Англия"), new City("Великобритания", "Англия", "Лондон", 8982000) },
            //        { new Region("Австралия", "Новый Южный Уэльс"), new City("Австралия", "Новый Южный Уэльс", "Сидней", 5312163) }
            //    },
            //    new SortedDictionary<Region, City>(placeComparer)
            //    {
            //        { new Region("Япония", "Хоккайдо"), new City("Япония", "Хоккайдо", "Саппоро", 1952356) },
            //        { new Region("Южная Корея", "Сеул"), new City("Южная Корея", "Сеул", "Сеул", 9733509) },
            //        { new Region("Китай", "Пекин"), new City("Китай", "Пекин", "Пекин", 21540000) }
            //    }
            //};
            //            Console.WriteLine("Запросы на выборку по стране");
            //            Console.WriteLine("Методы расширения");
            //            var Cities = listOfCountries.GetCitiesByCountry("Россия");
            //            foreach (var city in Cities)
            //            {
            //                city.Show();
            //            }
            //            Console.WriteLine();
            //            Console.WriteLine("Linq запрос");
            //            var CitiesLinq = from country in listOfCountries
            //                             from city in country.Values
            //                             where city.Country == "Россия"
            //                             select city;

            //            foreach (var city in CitiesLinq)
            //            {
            //                city.Show();
            //            }

            //            Console.WriteLine("Запросы на получение максимального населения");

            //            var maxAge = listOfCountries.GetMaxPopulation();
            //            Console.WriteLine($"Максимальное население через расширение {maxAge}");

            //            var maxAgeLinq = (from country in listOfCountries
            //                              from city in country.Values
            //                              select city.Population).Max();
            //            Console.WriteLine($"Максимальное население через Linq {maxAgeLinq}" );
            //            Console.WriteLine("\n\n\n");


            //            Console.WriteLine("Города с населением больше 5000000");
            //            var moreThanCities = listOfCountries.GetCitiesMoreThan(5000000);
            //            var moreThanCitiesLinq = from country in listOfCountries
            //                                     from cities in country.Values
            //                                     where cities.Population > 5000000
            //                                     select cities;
            //            Console.WriteLine("Метод расширения");
            //            foreach (var city in moreThanCities)
            //            {
            //                city.Show();
            //            }
            //            Console.WriteLine("Linq");
            //            foreach(var city in moreThanCitiesLinq)
            //            {
            //                city.Show();
            //            }
            //            Console.WriteLine("\n\n\n");

            //            Console.WriteLine("Запросы на группировку");
            //            var groupOfCountries = listOfCountries.GroupByCountry();
            //            foreach (var country in groupOfCountries)
            //            {
            //                Console.WriteLine(country.Key);
            //                foreach (var city in country)
            //                {
            //                    city.Show();
            //                }
            //            }
            //            Console.WriteLine("\n\n\n");
            //            var groupOfCountriesLinq = from country in listOfCountries
            //                                       from city in country.Values
            //                                       group city by city.Country;
            //            foreach(var country in groupOfCountriesLinq)
            //            {
            //                Console.WriteLine(country.Key);
            //                foreach (var city in country)
            //                {
            //                    city.Show();
            //                }
            //            }
            //            Console.WriteLine("\n\n\n");
            //            var combinedList = listOfCountries.Union(anotherListOfCountries).ToList();
            //            Console.WriteLine($"Найдем максимальный город после объединения двух листов расширением {combinedList.GetMaxPopulation()}");
            //            var combinedListLinq =
            //            (from country in listOfCountries
            //             from another in anotherListOfCountries
            //             from dict in new[] { country.Union(another) }  // объединяем словари
            //             from pair in dict  // извлекаем пары ключ-значение (Region, City)
            //             select pair.Value)  // извлекаем объект City
            //            .Max(city => city.Population);  // находим максимальную популяцию среди городов



            //            Console.WriteLine($"Найдем максимальный город после объединения двух листов Linq {combinedListLinq}");





            
            List<City> cities = new List<City>
            {
                new City("Франция", "Иль-де-Франс", "Париж", 2148327),
                new City("Италия", "Ломбардия", "Милан", 1378689),
                new City("Испания", "Каталония", "Барселона", 1664182),
                new City("США", "Флорида", "Майами", 467963),
                new City("Канада", "Онтарио", "Торонто", 2731571),
                new City("Канада", "Квебек", "Монреаль", 1780000),
                new City("Германия", "Берлин", "Берлин", 3769495),
                new City("Великобритания", "Англия", "Лондон", 8982000),
                new City("Австралия", "Новый Южный Уэльс", "Сидней", 5312163),
                new City("Япония", "Хоккайдо", "Саппоро", 1952356),
                new City("Южная Корея", "Сеул", "Сеул", 9733509),
                new City("Китай", "Пекин", "Пекин", 21540000)
            };

            
            BinaryTree<City> tree = new BinaryTree<City>();

            
            foreach (var city in cities)
            {
                tree.Add(city);
                city.Show();
            }
            Console.WriteLine("\n\n\n");
            var filteredCities = tree.Where(city => city.Population > 5000000);
            foreach (var city in filteredCities)
            {
                city.Show();
            }
            Console.WriteLine("\n\n\n");
            var totalPopulation = cities.Sum(city => city.Population);
            Console.WriteLine($"Все население городов равно {totalPopulation} ");
            Console.WriteLine("\n\n\n");
            var maxPopulationCity = tree.Aggregate((City)null, (max, city) => max == null || city.Population > max.Population ? city : max);
            Console.WriteLine($"Максимальное население города равно {maxPopulationCity}");
            Console.WriteLine("\n\n\n");
            var sortedCities = tree.OrderByDescending(city => city.Population);
            foreach(var city in sortedCities)
            {
                city.Show();
            }

        }

    }
}
