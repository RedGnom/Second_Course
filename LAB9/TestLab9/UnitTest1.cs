using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using LAB9;
namespace TestLab9
{
    [TestClass]
    public class UnitTest1
    {
        static Random rnd = new Random();
        [TestMethod]
        public void ReadCase1()
        { // Arrange;
            var input = new StringReader("180\n2\n");
            Console.SetIn(input);
            // Act
            Time time;
            Interface.Read(out time);
            // Assert
            Assert.AreEqual(5, time.Hours);
            Assert.AreEqual(0, time.Minutes);
        }
        [TestMethod]
        public void TestReadElemValidInput()
        {
            // Arrange
            var input = "5\n";
            var expectedOutput = 5;
            var inputStream = new StringReader(input);
            Console.SetIn(inputStream);

            // Act
            var result = Interface.ReadElem();

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void TestReadElemInvalidInputRetryUntilValid()
        {
            // Arrange
            var input = "abc\n-2\n10\n1,25\n";
            var expectedOutput = 10;
            var inputStream = new StringReader(input);
            var outputStream = new StringWriter();
            Console.SetIn(inputStream);
            Console.SetOut(outputStream);

            // Act
            var result = Interface.ReadElem();

            // Assert
            Assert.AreEqual(expectedOutput, result);
            var outputLines = outputStream.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            CollectionAssert.Contains(outputLines, "Неверные данные, повторите попытку ввода");
        }
        [TestMethod]
        public void TestWriteSingleTime()
        {
            // Arrange
            Time time = new Time { Hours = 2, Minutes = 30 };
            var outputStream = new StringWriter();
            Console.SetOut(outputStream);

            // Act
            Interface.Write(time);

            // Assert
            var expectedOutput = "Количество часов: 2  Количество минут: 30" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, outputStream.ToString());
        }

        [TestMethod]
        public void TestTimeArrayUserInputInitialization()
        {
            // Arrange
            var size = 2;
            var input = "30\n1\n45\n2\n"; // Сначала вводим минуты, потом часы
            var inputStream = new StringReader(input);
            var outputStream = new StringWriter();
            Console.SetIn(inputStream);
            Console.SetOut(outputStream);

            // Act
            TimeArray timeArray = new TimeArray(size, true);

            // Assert
            Assert.AreEqual(size, timeArray.Length);
            Assert.AreEqual(30, timeArray[0].Minutes);
            Assert.AreEqual(1, timeArray[0].Hours);
            Assert.AreEqual(45, timeArray[1].Minutes);
            Assert.AreEqual(2, timeArray[1].Hours);
        }
        [TestMethod]
        public void TestMaxElem()
        {
            int size = 4;
            var input = "37\n60\n11\n25\n31\n78\n54\n29\n";
            var inputStream = new StringReader(input);
            var outputStream = new StringWriter();
            Console.SetIn(inputStream);
            Console.SetOut(outputStream);
            TimeArray timeArray = new TimeArray(size, true);
            Time expectedMax = timeArray.GetMax();
            Assert.AreEqual(31, expectedMax.Minutes);
            Assert.AreEqual(78, expectedMax.Hours);
        }
        [TestMethod]
        public void IndexOutArray1()
        {
            int size = 4;
            TimeArray timeArray = new TimeArray(size, rnd);

            try { timeArray[5].Minutes = 7; }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Индекс вне диапазона массива.", ex.Message);

            }
        }
        [TestMethod]
        public void IndexOutArray2()
        {
            int size = 4;
            TimeArray timeArray = new TimeArray(size, rnd);

            try { Time testTime = timeArray[5]; }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Индекс вне диапазона массива.", ex.Message);

            }
        }
        [TestMethod]
        public void TestMinus()
        {
            Time time1 = new Time(2, 30); 
            Time time2 = new Time(1, 15);
            Time result = time1.Minus(time2);

            Assert.AreEqual(1, result.Hours);
            Assert.AreEqual(15, result.Minutes);
        }
        [TestMethod]
        public void TestMinusException()
        {
            Time time1 = new Time(2, 30);
            Time time2 = new Time(3, 15);
            try
            {
                var result = time1.Minus(time2);
            }
            catch(InvalidOperationException ex)
            {
                Assert.AreEqual("Невозможно уменьшить время", ex.Message);
            }
        }
        [TestMethod]
        public void TestIsNullTrue()
        {
            Time time = new Time(0, 0);
            Assert.IsFalse(time.IsNull());
        }

        [TestMethod]
        public void TestIsNullFalse()
        {
            Time time = new Time(1, 30);
            Assert.IsTrue(time.IsNull());
        }
        [TestMethod]
        public void TestToInt()
        {
            Time time = new Time(1, 30);
            int totalMinutes = time.ToInt();

            Assert.AreEqual(90, totalMinutes);
        }
        [TestMethod]
        public void TestDecrement()
        {
            Time time = new Time(2, 0);
            time--;

            Assert.AreEqual(1, time.Hours);
            Assert.AreEqual(59, time.Minutes);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDecrementInvalid()
        {
            Time time = new Time(0, 0);
            time--;
        }

        [TestMethod]
        public void TestIncrement1()
        {
            Time time = new Time(1, 59);
            time++;

            Assert.AreEqual(2, time.Hours);
            Assert.AreEqual(0, time.Minutes);
        }
        [TestMethod]
        public void TestIncrement2()
        {
            Time time = new Time(1, 45);
            time++;

            Assert.AreEqual(1, time.Hours);
            Assert.AreEqual(46, time.Minutes);
        }

        [TestMethod]
        public void TestMoreThan()
        {
            var time1 = new Time(3, 15); 
            var time2 = new Time(2, 30); 

            Assert.IsTrue(time1 > time2);
        }

        [TestMethod]
        public void TestLessThan()
        {
            var time1 = new Time(1, 45); 
            var time2 = new Time(2, 30); 

            Assert.IsTrue(time1 < time2);
        }

        [TestMethod]
        public void TestMoreOperatorEqual()
        {
            var time1 = new Time(2, 30); 
            var time2 = new Time(2, 30); 

            Assert.IsFalse(time1 > time2);
        }

        [TestMethod]
        public void TestLessOperatorEqual()
        {
            var time1 = new Time(2, 30);
            var time2 = new Time(2, 30);

            Assert.IsFalse(time1 < time2);
        }
        [TestMethod]
        public void TestWriteArray()
        {
            // Arrange
            var size = 2;
            var input = "30\n1\n45\n2\n"; // Сначала вводим минуты, потом часы
            var inputStream = new StringReader(input);
            var outputStream = new StringWriter();
            Console.SetIn(inputStream);
            Console.SetOut(outputStream);

            // Act
            TimeArray timeArray = new TimeArray(size);
            timeArray[0] = new Time(1, 30);
            timeArray[1] = new Time(2, 45);
            Interface.Write(timeArray);
            //Assert
            StringAssert.Contains(outputStream.ToString(), "Количество часов: 1  Количество минут: 30");
            StringAssert.Contains(outputStream.ToString(), "Количество часов: 2  Количество минут: 45");
        }

        [TestMethod]
        public void HoursTest()
        {
            var time = new Time();
            int expectedHours = 5;
            time.Hours = expectedHours;
            Assert.AreEqual(expectedHours, time.Hours);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Время не может быть меньше 0")]
        public void HoursException()
        {
            var time = new Time();
            time.Hours = -1;
        }

        [TestMethod]
        public void MinutesTest()
        {
            var time = new Time();
            int expectedMinutes = 30;
            time.Minutes = expectedMinutes;
            Assert.AreEqual(expectedMinutes, time.Minutes);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Время не может быть меньше 0")]
        public void MinutesException()
        {
            var time = new Time();
            time.Minutes = -1;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Невозможно получиить наименьший.")]
        public void GetMaxException()
        {
            TimeArray timeArray = new TimeArray(0);
            Time Time = timeArray.GetMax();
        }
        [TestMethod]
        public void WriteArrayNull()
        {
            TimeArray timeArray = new TimeArray();
            var outputStream = new StringWriter();
            Console.SetOut(outputStream);

            Interface.Write(timeArray);
            var expectedOutput = "Массив пустой" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, outputStream.ToString());
        }






    }
}
