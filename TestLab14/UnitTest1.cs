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

        // ���� ��� ������ GroupByCondition ��� List<SortedDictionary<Region, City>>
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
    }
}