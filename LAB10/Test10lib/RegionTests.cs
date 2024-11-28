using System;
using System.IO;
using System.Collections.Generic;
using LAB10_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test10lib
{
    [TestClass]
    public class RegionTests
    {
        [TestMethod]
        public void InitRegion()
        {
            var input = new StringReader("Россия\nАрхангельская область\n");
            Console.SetIn(input);
            Region region = new Region();
            region.Init();

            // Assert
            Assert.AreEqual("Россия", region.Country);
            Assert.AreEqual("Архангельская область", region.Name);
        }

        [TestMethod]
        public void RandomInitRegion()
        {
            Region region = new Region();
            region.RandomInit();
            Assert.IsNotNull(region.Country);
            Assert.IsNotNull(region.Name);
        }

        [TestMethod]
        public void DefaultConstructorRegion()
        {
            var region = new Region();
            Assert.AreEqual(string.Empty, region.Country);
            Assert.AreEqual(" ", region.Name);
        }

        [TestMethod]
        public void CopyConstructorRegion()
        {
            var original = new Region("Россия", "Пермский край");

            var copy = new Region(original);

            Assert.AreEqual(original.Country, copy.Country);
            Assert.AreEqual(original.Name, copy.Name);
        }

        [TestMethod]
        public void ConstructorParamRegion()
        {

            var country = "Россия";
            var name = "Пермский край";

            var region = new Region(country, name);

            Assert.AreEqual(country, region.Country);
            Assert.AreEqual(name, region.Name);
        }

        [TestMethod]
        public void ShowRegion()
        {
 
            var region = new Region("Россия", "Пермский край");
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            region.Show();

            // Assert
            var expectedOutput = "Название области: Пермский край\r\nСтрана: Россия\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestMethod]
        public void EqualsRegions()
        {
            // Arrange
            var region1 = new Region("Россия", "Белгородская область");
            var region2 = new Region("Россия", "Белгородская область");

            // Act & Assert
            Assert.IsTrue(region1.Equals(region2));
        }

        [TestMethod]
        public void EqualsFalseRegions()
        {
            // Arrange
            var region1 = new Region("Россия", "Белгородская область");
            var region2 = new Region("Уганда", "Пермский край");

            // Act & Assert
            Assert.IsFalse(region1.Equals(region2));
        }

        [TestMethod]
        public void ShallowCopyRegion()
        {
            // Arrange
            var region = new Region("Россия", "Белгородская область");
            var city = new City("Россия", "Белгородская область", "Белгород", 350000);
            region.AddCity(city);

            // Act
            var shallowCopy = (Region)region.ShallowCopy();
            var city2 = new City(" ", region.Name, "Петропавловск", 10090);
            region.AddCity(city2);

            // Assert
            Assert.AreEqual(region.Cities.Count, shallowCopy.Cities.Count); 
            Assert.AreEqual(region.Cities[1], shallowCopy.Cities[1]);
        }

        [TestMethod]
        public void CloneRegion()
        {
            // Arrange
            var region = new Region("Россия", "Белгородская область");
            var city = new City("Россия", "Белгородская область", "Белгород", 350000);
            region.AddCity(city);

            // Act
            var deepCopy = (Region)region.Clone();
            var city2 = new City(" ", region.Name, "Петропавловск", 10090);
            region.AddCity(city2);

            // Assert
            Assert.AreNotEqual(region.Cities.Count, deepCopy.Cities.Count);
            Assert.AreEqual(city, deepCopy.Cities[0]);
        }


        [TestMethod]
        public void AddCityToRegion()
        {
            // Arrange
            var region = new Region("Россия", "Белгородская область");
            var city = new City("Россия", "Белгородская область", "Белгород", 350000);

            // Act
            region.AddCity(city);

            // Assert
            Assert.AreEqual(1, region.Cities.Count);
            Assert.AreEqual(city, region.Cities[0]);
        }

        [TestMethod]
        public void ShowCitiesInRegion()
        {
            // Arrange
            var region = new Region("Россия", "Белгородская область");
            var city = new City("Россия", "Белгородская область", "Белгород", 350000);
            region.AddCity(city);
            var output = new StringWriter();
            Console.SetOut(output);

            region.ShowCities();

            var expectedOutput = "Белгород\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestMethod]
        public void ShowPopulationInRegion()
        {

            var region = new Region("Россия", "Белгородская область");
            var city = new City("Россия", "Белгородская область", "Белгород", 350000);
            region.AddCity(city);
            var output = new StringWriter();
            Console.SetOut(output);

  
            region.ShowPopulation();

            var expectedOutput = "350000\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestMethod]
        public void ShowAmountOfCitiesInRegion()
        {
            // Arrange
            var region = new Region("Россия", "Белгородская область");
            var city1 = new City("Россия", "Белгородская область", "Белгород", 350000);
            var city2 = new City("Россия", "Белгородская область", "Старый Оскол", 250000);
            region.AddCity(city1);
            region.AddCity(city2);
            var output = new StringWriter();
            Console.SetOut(output);


            region.ShowAmount();


            var expectedOutput = "2\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }
        [TestMethod]
        public void SortRegionsUsingComparer()
        {
            // Arrange
            var places = new Place[]
            {
                new Place("Россия", "Белгородская область"),
                new Place("Россия", "Архангельская область"),
                new Place("Россия", "Пермский край")
            };

            var expectedOrder = new Place[]
            {
                new Place("Россия", "Архангельская область"),
                new Place("Россия", "Белгородская область"),
                new Place("Россия", "Пермский край")
            };

            // Act
            Array.Sort(places, new Comparer());

            // Assert
            for (int i = 0; i < places.Length; i++)
            {
                Assert.AreEqual(expectedOrder[i].Name, places[i].Name);
            }
        }


    }
}
