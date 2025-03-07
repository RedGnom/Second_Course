using LAB10_lib;
using Lab12;
using Lab14;
namespace TestLab14
{
    [TestClass]
    public class UnitTest1
    {
        IComparer<Place> placeComparer = new Comparer();
        [TestMethod]
        public void TestWhereForListOfCities()
        {
            
            // Подготовка тестовых данных
            var cities = new List<SortedDictionary<Region, City>>()
            {
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region { Name = "Region1" }, new City { Name = "City1", Country = "Country1", Population = 1000000} },
                    { new Region { Name = "Region2" }, new City { Name = "City2", Country = "Country2", Population = 2000000} }
                }
            };

            
            var result = cities.Where(city => city.Population > 1500000);

            // Проверяем результат
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("City2", result.First().Name);
        }
        [TestMethod]
        public void TestAggregatePopulation()
        {
            // Подготовка тестовых данных
            var cities = new List<SortedDictionary<Region, City>>()
            {
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region { Name = "Region1" }, new City { Name = "City1", Country = "Country1", Population = 1000000} },
                    { new Region { Name = "Region2" }, new City { Name = "City2", Country = "Country2", Population = 2000000} }
                }
            };

            // Применяем метод AggregatePopulation
            var result = cities.AggregatePopulation(populations => populations.Sum());

            // Проверяем результат
            Assert.AreEqual(3000000, result);
        }

        
        [TestMethod]
        public void TestGroupByCondition()
        {
            // Подготовка тестовых данных
            var cities = new List<SortedDictionary<Region, City>>()
            {
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region { Name = "Region1" }, new City { Name = "City1", Country = "Country1", Population = 1000000 } },
                    { new Region { Name = "Region2" }, new City { Name = "City2", Country = "Country2", Population = 2000000} }
                }
            };

            // Применяем метод GroupByCondition
            var result = cities.GroupByCondition(city => city.Country);

            // Проверяем результат
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(group => group.Key == "Country1" && group.Count() == 1));
            Assert.IsTrue(result.Any(group => group.Key == "Country2" && group.Count() == 1));
        }
        [TestMethod]
        public void TestUnionWith()
        {
            var list1 = new List<City>
            {
                new City("Франция", "Иль-де-Франс", "Париж", 2148327),
                new City("Италия", "Ломбардия", "Милан", 1378689)
            };
            var list2 = new List<City>
            {
                new City("Испания", "Каталония", "Барселона", 1664182),
                new City("США", "Флорида", "Майами", 467963)
            };

            var result = list1.UnionWith(list2, (l1, l2) => l1.Concat(l2));
            Assert.AreEqual(4, result.Count);
        }
        [TestMethod]
        public void TestWhereForBinaryTree()
        {
            BinaryTree<City> tree = new BinaryTree<City>();
            tree.Add(new City("США", "Нью-Йорк", "Нью-Йорк", 20000000));
            tree.Add(new City("Германия", "Берлин", "Берлин", 3769495));
            tree.Add(new City("Китай", "Пекин", "Пекин", 21540000));

            var result = tree.Where(city => city.Population > 5000000);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void TestAggregateData()
        {
            BinaryTree<City> tree = new BinaryTree<City>();
            tree.Add(new City("США", "Флорида", "Майами", 467963));
            tree.Add(new City("Канада", "Онтарио", "Торонто", 2731571));
            tree.Add(new City("Германия", "Берлин", "Берлин", 3769495));

            var result = tree.AggregateData(city => city.Population, (total, pop) => total + pop);
            Assert.AreEqual(6969029, result);
        }
        [TestMethod]
        public void TestSortBy()
        {
            BinaryTree<City> tree = new BinaryTree<City>();
            tree.Add(new City("Канада", "Квебек", "Монреаль", 1780000));
            tree.Add(new City("Великобритания", "Англия", "Лондон", 8982000));
            tree.Add(new City("Япония", "Хоккайдо", "Саппоро", 1952356));

            var result = tree.SortBy(city => city.Population);
            Assert.AreEqual("Монреаль", result.First().CityName);
            Assert.AreEqual("Лондон", result.Last().CityName);
        }
    }
}