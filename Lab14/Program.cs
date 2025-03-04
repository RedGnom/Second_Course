using Lab12;
using LAB10_lib;
namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SortedDictionary<Region, City>> listOfDictionaries = new List<SortedDictionary<Region, City>>
        {
            new SortedDictionary<Region, City>
            {
                { new Region("Россия", "Пермский край"), new City("Россия", "Пермский край", "Пермь", 1000000) },
                { new Region("Россия", "Свердловская область"), new City("Россия", "Свердловская область", "Екатеринбург", 1500000) },
                { new Region("Россия", "Республика Татарстан"), new City("Россия", "Свердловская область", "Екатеринбург", 1500000) }

            },
            new SortedDictionary<Region, City>
            {
                { new Region("США", "Нью-Йорк"), new City("США", "Нью-Йорк", "Нью-Йорк", 20000000) },
                { new Region("США", "Массачусетс"), new City("США", "Массачусетс", "Бостон", 7400000) },
                { new Region("США", "Калифорния"), new City("США", "Калифорния", "Лос-Анджелес", 12800000) },
            },
            
        };
        }
    }
}
