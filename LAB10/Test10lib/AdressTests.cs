using System;
using System.IO;
using LAB10_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test10lib
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void InitAddress()
        {
            var input = new StringReader("Россия\nАрхангельская область\nАрхангельск\n500000\n12\n34\nЛенина\n");
            Console.SetIn(input);
            Address address = new Address();
            address.Init();

            // Assert
            Assert.AreEqual("Россия", address.Country);
            Assert.AreEqual("Архангельская область", address.Name);
            Assert.AreEqual("Архангельск", address.CityName);
            Assert.AreEqual(12, address.House);
            Assert.AreEqual(34, address.Flat);
            Assert.AreEqual("Ленина", address.Street);
        }

        [TestMethod]
        public void RandomInitAddress()
        {
            Address address = new Address();
            address.RandomInit();
            Assert.IsNotNull(address.Country);
            Assert.IsNotNull(address.Name);
            Assert.IsNotNull(address.CityName);
            Assert.IsTrue(address.House >= 1 && address.House <= 200);
            Assert.IsTrue(address.Flat >= 1 && address.Flat <= 110);
            Assert.IsNotNull(address.Street);
        }

        [TestMethod]
        public void DefaultConstructorAddress()
        {
            // Act
            var address = new Address();

            // Assert
            Assert.AreEqual(string.Empty, address.Country);
            Assert.AreEqual(" ", address.Name);
            Assert.AreEqual(" ", address.CityName);
            Assert.AreEqual(0, address.House);
            Assert.AreEqual(0, address.Flat);
            Assert.AreEqual(" ", address.Street);
        }

        [TestMethod]
        public void CopyConstructorAddress()
        {
            // Arrange
            var original = new Address("Россия", "Московская область", "Москва", 123456, 12, 34, "Ленина");

            // Act
            var copy = new Address(original);

            // Assert
            Assert.AreEqual(original.Country, copy.Country);
            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.CityName, copy.CityName);
            Assert.AreEqual(original.House, copy.House);
            Assert.AreEqual(original.Flat, copy.Flat);
            Assert.AreEqual(original.Street, copy.Street);
        }

        [TestMethod]
        public void ConstructorParamAddress()
        {
            // Arrange
            var country = "Россия";
            var name = "Московская область";
            var cityName = "Москва";
            var house = 12;
            var flat = 34;
            var street = "Ленина";

            // Act
            var address = new Address(country, name, cityName, 0, house, flat, street);

            // Assert
            Assert.AreEqual(country, address.Country);
            Assert.AreEqual(name, address.Name);
            Assert.AreEqual(cityName, address.CityName);
            Assert.AreEqual(house, address.House);
            Assert.AreEqual(flat, address.Flat);
            Assert.AreEqual(street, address.Street);
        }

        [TestMethod]
        public void ShowAddress()
        {
            // Arrange
            var address = new Address("Россия", "Пермский край", "Пермь", 654321, 12, 34, "Ленина");
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            address.Show();

            // Assert
            var expectedOutput = "Название области: Пермский край\r\nСтрана: Россия\r\nГород: Пермь\r\nНаселение: 654321\r\nУлица: Ленина\r\nДом: 12\r\nКвартира 34\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestMethod]
        public void EqualsAddresses()
        {
            // Arrange
            var address1 = new Address("Россия", "Московская область", "Москва", 123456, 12, 34, "Ленина");
            var address2 = new Address("Россия", "Московская область", "Москва", 123456, 12, 34, "Ленина");

            // Act & Assert
            Assert.IsTrue(address1.Equals(address2));
        }

        [TestMethod]
        public void EqualsFalseAddresses()
        {
            // Arrange
            var address1 = new Address("Россия", "Московская область", "Москва", 123456, 12, 34, "Ленина");
            var address2 = new Address("Уганда", "Кампала", "Кампала", 654321, 56, 78, "Советская");

            // Act & Assert
            Assert.IsFalse(address1.Equals(address2));
        }

        [TestMethod]
        public void ShallowCopyAddress()
        {
            // Arrange
            Address address = new Address("Россия", "Московская область", "Москва", 123456, 12, 34, "Ленина");

            // Act
            Place shallowCopy = address.ShallowCopy();

            // Assert
            Assert.AreEqual(address.Country, ((Address)shallowCopy).Country);
            Assert.AreEqual(address.Name, ((Address)shallowCopy).Name);
            Assert.AreEqual(address.CityName, ((Address)shallowCopy).CityName);
            Assert.AreEqual(address.House, ((Address)shallowCopy).House);
            Assert.AreEqual(address.Flat, ((Address)shallowCopy).Flat);
            Assert.AreEqual(address.Street, ((Address)shallowCopy).Street);
            Assert.IsFalse(ReferenceEquals(address, shallowCopy));
        }

        [TestMethod]
        public void CloneAddress()
        {
            // Arrange
            var address = new Address("Россия", "Московская область", "Москва", 123456, 12, 34, "Ленина");

            // Act
            var clone = (Address)address.Clone();

            // Assert
            Assert.AreEqual(address.Country, clone.Country);
            Assert.AreEqual(address.Name, clone.Name);
            Assert.AreEqual(address.CityName, clone.CityName);
            Assert.AreEqual(address.House, clone.House);
            Assert.AreEqual(address.Flat, clone.Flat);
            Assert.AreEqual(address.Street, clone.Street);
            Assert.IsFalse(ReferenceEquals(address, clone));
        }

        [TestMethod]
        public void HouseTrue()
        {
            // Arrange
            var address = new Address();
            var expectedHouse = 12;

            // Act
            address.House = expectedHouse;

            // Assert
            Assert.AreEqual(expectedHouse, address.House);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Номер дома не может быть меньше 0")]
        public void HouseException()
        {
            
            var address = new Address();

            address.House = -1;

        }

        [TestMethod]
        public void FlatTrue()
        {
            var address = new Address();
            var expectedFlat = 34;
            address.Flat = expectedFlat;
            Assert.AreEqual(expectedFlat, address.Flat);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Номер квартиры не может быть меньше 0")]
        public void FlatException()
        {

            var address = new Address();
            address.Flat = -1;

        }
    }
}
