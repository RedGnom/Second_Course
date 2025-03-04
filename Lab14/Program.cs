using Lab12;
using LAB10_lib;
using Lab14;
namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IComparer<Place> placeComparer = new Comparer();

            
            List<SortedDictionary<Region, City>> listOfCountries = new List<SortedDictionary<Region, City>>
            {
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region("Россия", "Пермский край"), new City("Россия", "Пермский край", "Пермь", 1000000) },
                    { new Region("Россия", "Свердловская область"), new City("Россия", "Свердловская область", "Екатеринбург", 1500000) },
                    { new Region("Россия", "Республика Татарстан"), new City("Россия", "Республика Татарстан", "Казань", 1250000) }
                },
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region("США", "Нью-Йорк"), new City("США", "Нью-Йорк", "Нью-Йорк", 20000000) },
                    { new Region("США", "Массачусетс"), new City("США", "Массачусетс", "Бостон", 7400000) },
                    { new Region("США", "Калифорния"), new City("США", "Калифорния", "Лос-Анджелес", 12800000) }
                },
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region("Германия", "Бавария"), new City("Германия", "Бавария", "Мюнхен", 1488202) },
                    { new Region("Германия", "Северный Рейн-Вестфалия"), new City("Германия", "Северный Рейн-Вестфалия", "Кёльн", 1085664) },
                    { new Region("Германия", "Гамбург"), new City("Германия", "Гамбург", "Гамбург", 1835878) }
                },
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region("Япония", "Токио"), new City("Япония", "Токио", "Токио", 13929286) },
                    { new Region("Япония", "Киото"), new City("Япония", "Киото", "Киото", 1474570) },
                    { new Region("Япония", "Осака"), new City("Япония", "Осака", "Осака", 2735146) }
                }
            };
            var Cities = listOfCountries.GetCitiesByCountry("Россия");
            foreach(var city in Cities)
            {
                city.Show();
            }

            var CitiesLinq = from country in listOfCountries
                         from city in country.Values
                         where city.Country == "Россия"
                         select city;

            foreach (var city in CitiesLinq)
            {
                city.Show();
            }









        }

    }
}
