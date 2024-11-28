using System;
using LAB10_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test10lib
{
    [TestClass]
    public class PlaceTest
    {
        [TestMethod]
        public void InitPlace()
        {
            var input = new StringReader("Россия\nМосква\n");
            Console.SetIn(input);
            Place place = new Place();
            place.Init();

            // Assert
            Assert.AreEqual("Россия", place.Country);
            Assert.AreEqual("Москва", place.Name);
        }

        [TestMethod]
        public void RandomInitPlace()
        {
            Place place = new Place();
            place.RandomInit();
            Assert.IsNotNull(place.Country);
            Assert.IsNotNull(place.Name);
        }
        [TestMethod]
        public void DefaultConstructorPlace()
        {
            // Act
            var place = new Place();

            // Assert
            Assert.AreEqual(string.Empty, place.Country);
            Assert.AreEqual(" ", place.Name);
        }

        [TestMethod]
        public void CopyConstructorPlace()
        {
            // Arrange
            var original = new Place("Россия", "Москва");

            // Act
            var copy = new Place(original);

            // Assert
            Assert.AreEqual(original.Country, copy.Country);
            Assert.AreEqual(original.Name, copy.Name);
        }
        [TestMethod]
        public void ConstructorParamPlace()
        {
            // Arrange
            var country = "Россия";
            var name = "Москва";

            // Act
            var place = new Place(country, name);

            // Assert
            Assert.AreEqual(country, place.Country);
            Assert.AreEqual(name, place.Name);
        }
        [TestClass]
        public class PlaceTests
        {
            [TestMethod]
            public void ShowPlace()
            {
                // Arrange
                var place = new Place("Россия", "Пермский край");
                var output = new StringWriter();
                Console.SetOut(output);

                // Act
                place.Show();

                // Assert
                var expectedOutput = "Пермский край\r\nСтрана: Россия\r\n";
                Assert.AreEqual(expectedOutput, output.ToString());
            }


            [TestMethod]
            public void CompareTo()
            {
                // Arrange
                var place1 = new Place("Россия", "Москва");
                var place2 = new Place("Уганда", "Кампала");
                var place3 = new Place("Россия", "Санкт-Петербург");

                // Act & Assert
                Assert.IsTrue(place1.CompareTo(place2) < 0); // "Россия" < "Уганда"
                Assert.IsTrue(place2.CompareTo(place1) > 0); // "Уганда" > "Россия"
                Assert.IsTrue(place1.CompareTo(place3) == 0); // "Россия" == "Россия"
            }

            [TestMethod]
            public void EqualsPlaces()
            {
                // Arrange
                var place1 = new Place("Россия", "Москва");
                var place2 = new Place("Россия", "Москва");

                // Act & Assert
                Assert.IsTrue(place1.Equals(place2));
            }

            [TestMethod]
            public void EqualsFalsePlaces()
            {
                // Arrange
                var place1 = new Place("Россия", "Москва");
                var place2 = new Place("Уганда", "Кампала");

                // Act & Assert
                Assert.IsFalse(place1.Equals(place2));
            }

            [TestMethod]
            public void ShallowCopyPlace()
            {
                // Arrange
                var place = new Place("Россия", "Москва");

                // Act
                var shallowCopy = place.ShallowCopy();

                // Assert
                Assert.AreEqual(place.Country, shallowCopy.Country);
                Assert.AreEqual(place.Name, shallowCopy.Name);
                Assert.IsFalse(ReferenceEquals(place, shallowCopy));
            }

            [TestMethod]
            public void ClonePlace()
            {
                // Arrange
                var place = new Place("Россия", "Москва");

                // Act
                var clone = (Place)place.Clone();

                // Assert
                Assert.AreEqual(place.Country, clone.Country);
                Assert.AreEqual("Москва", clone.Name);
                Assert.IsFalse(ReferenceEquals(place, clone));
            }




        }
    }
}
