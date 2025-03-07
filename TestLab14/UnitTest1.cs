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
            
            // ���������� �������� ������
            var cities = new List<SortedDictionary<Region, City>>()
            {
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region { Name = "Region1" }, new City { Name = "City1", Country = "Country1", Population = 1000000} },
                    { new Region { Name = "Region2" }, new City { Name = "City2", Country = "Country2", Population = 2000000} }
                }
            };

            
            var result = cities.Where(city => city.Population > 1500000);

            // ��������� ���������
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("City2", result.First().Name);
        }
        [TestMethod]
        public void TestAggregatePopulation()
        {
            // ���������� �������� ������
            var cities = new List<SortedDictionary<Region, City>>()
            {
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region { Name = "Region1" }, new City { Name = "City1", Country = "Country1", Population = 1000000} },
                    { new Region { Name = "Region2" }, new City { Name = "City2", Country = "Country2", Population = 2000000} }
                }
            };

            // ��������� ����� AggregatePopulation
            var result = cities.AggregatePopulation(populations => populations.Sum());

            // ��������� ���������
            Assert.AreEqual(3000000, result);
        }

        
        [TestMethod]
        public void TestGroupByCondition()
        {
            // ���������� �������� ������
            var cities = new List<SortedDictionary<Region, City>>()
            {
                new SortedDictionary<Region, City>(placeComparer)
                {
                    { new Region { Name = "Region1" }, new City { Name = "City1", Country = "Country1", Population = 1000000 } },
                    { new Region { Name = "Region2" }, new City { Name = "City2", Country = "Country2", Population = 2000000} }
                }
            };

            // ��������� ����� GroupByCondition
            var result = cities.GroupByCondition(city => city.Country);

            // ��������� ���������
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(group => group.Key == "Country1" && group.Count() == 1));
            Assert.IsTrue(result.Any(group => group.Key == "Country2" && group.Count() == 1));
        }
        [TestMethod]
        public void TestUnionWith()
        {
            var list1 = new List<City>
            {
                new City("�������", "���-��-�����", "�����", 2148327),
                new City("������", "���������", "�����", 1378689)
            };
            var list2 = new List<City>
            {
                new City("�������", "���������", "���������", 1664182),
                new City("���", "�������", "������", 467963)
            };

            var result = list1.UnionWith(list2, (l1, l2) => l1.Concat(l2));
            Assert.AreEqual(4, result.Count);
        }
        [TestMethod]
        public void TestWhereForBinaryTree()
        {
            BinaryTree<City> tree = new BinaryTree<City>();
            tree.Add(new City("���", "���-����", "���-����", 20000000));
            tree.Add(new City("��������", "������", "������", 3769495));
            tree.Add(new City("�����", "�����", "�����", 21540000));

            var result = tree.Where(city => city.Population > 5000000);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void TestAggregateData()
        {
            BinaryTree<City> tree = new BinaryTree<City>();
            tree.Add(new City("���", "�������", "������", 467963));
            tree.Add(new City("������", "�������", "�������", 2731571));
            tree.Add(new City("��������", "������", "������", 3769495));

            var result = tree.AggregateData(city => city.Population, (total, pop) => total + pop);
            Assert.AreEqual(6969029, result);
        }
        [TestMethod]
        public void TestSortBy()
        {
            BinaryTree<City> tree = new BinaryTree<City>();
            tree.Add(new City("������", "������", "��������", 1780000));
            tree.Add(new City("��������������", "������", "������", 8982000));
            tree.Add(new City("������", "��������", "�������", 1952356));

            var result = tree.SortBy(city => city.Population);
            Assert.AreEqual("��������", result.First().CityName);
            Assert.AreEqual("������", result.Last().CityName);
        }
    }
}