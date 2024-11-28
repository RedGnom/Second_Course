using System;
using System.IO;
using LAB10_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test10lib
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void InitVehicle()
        {
            var input = new StringReader("Автобус\n100\n");
            Console.SetIn(input);
            Vehicle vehicle = new Vehicle();
            vehicle.Init();

            // Assert
            Assert.AreEqual("Автобус", vehicle.Name);
            Assert.AreEqual(100, vehicle.Speed);
        }

        [TestMethod]
        public void RandomInitVehicle()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.RandomInit();
            Assert.IsNotNull(vehicle.Name);
            Assert.IsTrue(vehicle.Speed >= 60 && vehicle.Speed <= 220);
        }

        [TestMethod]
        public void DefaultConstructorVehicle()
        {
            // Act
            var vehicle = new Vehicle();

            // Assert
            Assert.AreEqual(0, vehicle.Speed);
            Assert.AreEqual(string.Empty, vehicle.Name);
        }

        [TestMethod]
        public void CopyConstructorVehicle()
        {
            // Arrange
            var original = new Vehicle("Легковая машина", 120);

            // Act
            var copy = new Vehicle(original);

            // Assert
            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.Speed, copy.Speed);
        }

        [TestMethod]
        public void ConstructorParamVehicle()
        {
            // Arrange
            var name = "Легковая машина";
            var speed = 120;

            // Act
            var vehicle = new Vehicle(name, speed);

            // Assert
            Assert.AreEqual(name, vehicle.Name);
            Assert.AreEqual(speed, vehicle.Speed);
        }

        [TestMethod]
        public void ShowVehicle()
        {
            // Arrange
            var vehicle = new Vehicle("Экскаватор", 80);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            vehicle.Show();

            // Assert
            var expectedOutput = "Название: Экскаватор\r\nСкорость: 80\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [TestMethod]
        public void ShallowCopyVehicle()
        {
            // Arrange
            Vehicle vehicle = new Vehicle("Трамвай", 60);

            // Act
            Vehicle shallowCopy = vehicle.ShallowCopy();

            // Assert
            Assert.AreEqual(vehicle.Name, shallowCopy.Name);
            Assert.AreEqual(vehicle.Speed, shallowCopy.Speed);
            Assert.IsFalse(ReferenceEquals(vehicle, shallowCopy));
        }

        [TestMethod]
        public void CloneVehicle()
        {
            // Arrange
            var vehicle = new Vehicle("Трактор", 70);

            // Act
            var clone = (Vehicle)vehicle.Clone();

            // Assert
            Assert.AreEqual(vehicle.Name, clone.Name);
            Assert.AreEqual(vehicle.Speed, clone.Speed);
            Assert.IsFalse(ReferenceEquals(vehicle, clone));
        }

        [TestMethod]
        public void SetSpeed_ShouldUpdateSpeed()
        {
            var vehicle = new Vehicle();
            var expectedSpeed = 90;

            vehicle.Speed = expectedSpeed;

            Assert.AreEqual(expectedSpeed, vehicle.Speed);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Скорость не может быть меньше 0")]
        public void SetSpeed_ShouldThrowException_WhenNegativeValue()
        {

            var vehicle = new Vehicle();

            vehicle.Speed = -1;
        }
    }
}
