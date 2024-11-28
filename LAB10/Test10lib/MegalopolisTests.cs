using System;
using System.IO;
using LAB10_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test10lib
{
    [TestClass]
    public class MegalopolisTests
    {
        [TestMethod]
        public void InitMegalopolis()
        {
            var input = new StringReader("Россия\nАрхангельская область\nАрхангельск\n500000\n75\n");
            Console.SetIn(input);
            Megalopolis megalopolis = new Megalopolis();
            megalopolis.Init();

            // Assert
            Assert.AreEqual("Россия", megalopolis.Country);
            Assert.AreEqual("Архангельская область", megalopolis.Name);
            Assert.AreEqual("Архангельск", megalopolis.CityName);
            Assert.AreEqual(500000, megalopolis.Population);
            Assert.AreEqual(75, megalopolis.Pollution);
        }

        [TestMethod]
        public void RandomInitMegalopolis()
        {
            Megalopolis megalopolis = new Megalopolis();
            megalopolis.RandomInit();
            Assert.IsNotNull(megalopolis.Country);
            Assert.IsNotNull(megalopolis.Name);
            Assert.IsNotNull(megalopolis.CityName);
            Assert.IsTrue(megalopolis.Population >= 1 && megalopolis.Population <= 10000000);
            Assert.IsTrue(megalopolis.Pollution >= 1 && megalopolis.Pollution <= 100);
        }

        [TestMethod]
        public void DefaultConstructorMegalopolis()
        {
            // Act
            var megalopolis = new Megalopolis();

            // Assert
            Assert.AreEqual(string.Empty, megalopolis.Country);
            Assert.AreEqual(" ", megalopolis.Name);
            Assert.AreEqual(" ", megalopolis.CityName);
            Assert.AreEqual(0, megalopolis.Population);
            Assert.AreEqual(0, megalopolis.Pollution);
        }

        [TestMethod]
        public void CopyConstructorMegalopolis()
        {
            // Arrange
            var original = new Megalopolis("Россия", "Московская область", "Москва", 123456, 75);

            // Act
            var copy = new Megalopolis(original);

            // Assert
            Assert.AreEqual(original.Country, copy.Country);
            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.CityName, copy.CityName);
            Assert.AreEqual(original.Population, copy.Population);
            Assert.AreEqual(original.Pollution, copy.Pollution);
        }

        [TestMethod]
        public void ConstructorParamMegalopolis()
        {
            // Arrange
            var country = "Россия";
            var name = "Московская область";
            var cityName = "Москва";
            var population = 123456;
            var pollution = 75;

            // Act
            var megalopolis = new Megalopolis(country, name, cityName, population, pollution);

            // Assert
            Assert.AreEqual(country, megalopolis.Country);
            Assert.AreEqual(name, megalopolis.Name);
            Assert.AreEqual(cityName, megalopolis.CityName);
            Assert.AreEqual(population, megalopolis.Population);
            Assert.AreEqual(pollution, megalopolis.Pollution);
        }

        [TestMethod]
        public void ShowMegalopolis()
        {
            // Arrange
            var megalopolis = new Megalopolis("Россия", "Пермский край", "Пермь", 654321, 50);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            megalopolis.Show();

            // Assert
            var expectedOutput = "Название области: Пермский край\r\nСтрана: Россия\r\nГород: Пермь\r\nНаселение: 654321\r\nЗагрязнение воздуха: 50\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestMethod]
        public void EqualsMegalopolises()
        {
            // Arrange
            var megalopolis1 = new Megalopolis("Россия", "Московская область", "Москва", 123456, 75);
            var megalopolis2 = new Megalopolis("Россия", "Московская область", "Москва", 123456, 75);

            // Act & Assert
            Assert.IsTrue(megalopolis1.Equals(megalopolis2));
        }

        [TestMethod]
        public void EqualsFalseMegalopolises()
        {
            // Arrange
            var megalopolis1 = new Megalopolis("Россия", "Московская область", "Москва", 123456, 75);
            var megalopolis2 = new Megalopolis("Уганда", "Кампала", "Кампала", 654321, 40);

            // Act & Assert
            Assert.IsFalse(megalopolis1.Equals(megalopolis2));
        }

        [TestMethod]
        public void ShallowCopyMegalopolis()
        {
            // Arrange
            Megalopolis megalopolis = new Megalopolis("Россия", "Московская область", "Москва", 123456, 75);

            // Act
            Place shallowCopy = megalopolis.ShallowCopy();

            // Assert
            Assert.AreEqual(megalopolis.Country, ((Megalopolis)shallowCopy).Country);
            Assert.AreEqual(megalopolis.Name, ((Megalopolis)shallowCopy).Name);
            Assert.AreEqual(megalopolis.CityName, ((Megalopolis)shallowCopy).CityName);
            Assert.AreEqual(megalopolis.Population, ((Megalopolis)shallowCopy).Population);
            Assert.AreEqual(megalopolis.Pollution, ((Megalopolis)shallowCopy).Pollution);
            Assert.IsFalse(ReferenceEquals(megalopolis, shallowCopy));
        }

        [TestMethod]
        public void CloneMegalopolis()
        {
            // Arrange
            var megalopolis = new Megalopolis("Россия", "Московская область", "Москва", 123456, 75);

            // Act
            var clone = (Megalopolis)megalopolis.Clone();

            // Assert
            Assert.AreEqual(megalopolis.Country, clone.Country);
            Assert.AreEqual(megalopolis.Name, clone.Name);
            Assert.AreEqual(megalopolis.CityName, clone.CityName);
            Assert.AreEqual(megalopolis.Population, clone.Population);
            Assert.AreEqual(megalopolis.Pollution, clone.Pollution);
            Assert.IsFalse(ReferenceEquals(megalopolis, clone));
        }

        [TestMethod]
        public void PollutionTrue ()
        {
            // Arrange
            var megalopolis = new Megalopolis();
            var expectedPollution = 50;

            // Act
            megalopolis.Pollution = expectedPollution;

            // Assert
            Assert.AreEqual(expectedPollution, megalopolis.Pollution);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Загрязнение не может быть меньше 0")]
        public void PollutionException()
        {
            // Arrange
            var megalopolis = new Megalopolis();

            // Act
            megalopolis.Pollution = -1;
        }
    }
}
