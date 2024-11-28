using System;
using System.IO;
using LAB10_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test10lib
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void InitCity()
        {
            var input = new StringReader("Россия\nАрхангельская область\nАрхангельск\n500000\n");
            Console.SetIn(input);
            City city = new City();
            city.Init();

            // Assert
            Assert.AreEqual("Россия", city.Country);
            Assert.AreEqual("Архангельская область", city.Name);
            Assert.AreEqual("Архангельск", city.CityName);
            Assert.AreEqual(500000, city.Population);
        }

        [TestMethod]
        public void RandomInitCity()
        {
            City city = new City();
            city.RandomInit();
            Assert.IsNotNull(city.Country);
            Assert.IsNotNull(city.Name);
            Assert.IsNotNull(city.CityName);
            Assert.IsTrue(city.Population >= 1 && city.Population <= 10000000);
        }

        [TestMethod]
        public void DefaultConstructorCity()
        {
            // Act
            var city = new City();

            // Assert
            Assert.AreEqual(string.Empty, city.Country);
            Assert.AreEqual(" ", city.Name);
            Assert.AreEqual(" ", city.CityName);
            Assert.AreEqual(0, city.Population);
        }

        [TestMethod]
        public void CopyConstructorCity()
        {
            // Arrange
            var original = new City("Россия", "Московская область", "Москва", 123456);

            // Act
            var copy = new City(original);

            // Assert
            Assert.AreEqual(original.Country, copy.Country);
            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.CityName, copy.CityName);
            Assert.AreEqual(original.Population, copy.Population);
        }

        [TestMethod]
        public void ConstructorParamCity()
        {
            // Arrange
            var country = "Россия";
            var name = "Московская область";
            var cityName = "Москва";
            var population = 123456;

            // Act
            var city = new City(country, name, cityName, population);

            // Assert
            Assert.AreEqual(country, city.Country);
            Assert.AreEqual(name, city.Name);
            Assert.AreEqual(cityName, city.CityName);
            Assert.AreEqual(population, city.Population);
        }

        [TestMethod]
        public void ShowCity()
        {
            // Arrange
            var city = new City("Россия", "Пермский край", "Пермь", 654321);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            city.Show();

            // Assert
            var expectedOutput = "Название области: Пермский край\r\nСтрана: Россия\r\nГород: Пермь\r\nНаселение: 654321\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestMethod]
        public void EqualsCities()
        {
            // Arrange
            var city1 = new City("Россия", "Московская область", "Москва", 123456);
            var city2 = new City("Россия", "Московская область", "Москва", 123456);

            // Act & Assert
            Assert.IsTrue(city1.Equals(city2));
        }

        [TestMethod]
        public void EqualsFalseCities()
        {
            // Arrange
            var city1 = new City("Россия", "Московская область", "Москва", 123456);
            var city2 = new City("Уганда", "Кампала", "Кампала", 654321);

            // Act & Assert
            Assert.IsFalse(city1.Equals(city2));
        }

        [TestMethod]
        public void ShallowCopyCity()
        {
            // Arrange
            City city = new City("Россия", "Московская область", "Москва", 123456);

            // Act
            Place shallowCopy = city.ShallowCopy();

            // Assert
            Assert.AreEqual(city.Country, ((City)shallowCopy).Country);
            Assert.AreEqual(city.Name, ((City)shallowCopy).Name);
            Assert.AreEqual(city.CityName, ((City)shallowCopy).CityName);
            Assert.AreEqual(city.Population, ((City)shallowCopy).Population);
            Assert.IsFalse(ReferenceEquals(city, shallowCopy));
        }

        [TestMethod]
        public void CloneCity()
        {
            // Arrange
            var city = new City("Россия", "Московская область", "Москва", 123456);

            // Act
            var clone = (City)city.Clone();

            // Assert
            Assert.AreEqual(city.Country, clone.Country);
            Assert.AreEqual(city.Name, clone.Name);
            Assert.AreEqual(city.CityName, clone.CityName);
            Assert.AreEqual(city.Population, clone.Population);
            Assert.IsFalse(ReferenceEquals(city, clone));
        }
        [TestMethod]
        public void SetPopulation_ShouldUpdatePopulation()
        {
            // Arrange
            var city = new City();
            var expectedPopulation = 500000;

            // Act
            city.Population = expectedPopulation;

            // Assert
            Assert.AreEqual(expectedPopulation, city.Population);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Население не может быть меньше 0")]
        public void SetPopulation_ShouldThrowException_WhenNegativeValue()
        {
            // Arrange
            var city = new City();

            // Act
            city.Population = -1;

        }
    }
}
