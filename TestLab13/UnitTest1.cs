using Lab13;
using LAB10_lib;
namespace TestLab13
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_ShouldTriggerTreeCountChanged()
        {
            // Arrange
            TreeEvent<int> tree = new TreeEvent<int>("TestTree");
            bool eventTriggered = false;
            tree.TreeCountChanged += (sender, args) => eventTriggered = true;

            // Act
            tree.Add(1);

            // Assert
            Assert.IsTrue(eventTriggered);
        }
        [TestMethod]
        
        public void Remove_ShouldTriggerTreeCountChanged()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("Россия", "Белгородская область");
            Place second = new Region("Бангладеш", "Новгородская область");

            tree.Add(first);
            tree.Add(second);
            bool eventTriggered = false;
            tree.TreeCountChanged += (sender, args) => eventTriggered = true;

            // Act
            tree.Remove(second);

            // Assert
            Assert.IsTrue(eventTriggered);
        }
        [TestMethod]
        public void RemoveAtIndex()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("Россия", "Белгородская область");
            Place second = new Region("Бангладеш", "Новгородская область");

            tree.Add(first);
            tree.Add(second);
            bool eventTriggered = false;
            tree.TreeCountChanged += (sender, args) => eventTriggered = true;

            // Act
            tree.Remove(1);

            // Assert
            Assert.IsTrue(eventTriggered);
        }

        [TestMethod]
        public void Change_ShouldTriggerTreeReferenceChanged()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("Россия", "Белгородская область");
            Place change = new Region("Россия", "Белая область");
            tree.Add(first);
            bool eventTriggered = false;

            tree.TreeReferenceChanged += (sender, args) => eventTriggered = true;

            // Act
            tree[0] = change;

            // Assert
            Assert.IsTrue(eventTriggered);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexOutOfRange()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("Россия", "Белгородская область");
            Place change = new Region("Россия", "Белая область");
            tree.Add(first);
            bool eventTriggered = false;
            tree.TreeCountChanged += (sender, args) => eventTriggered = true;

            // Act
            tree[2] = change;

            // Assert
            Assert.IsTrue(eventTriggered);
        }
        [TestMethod]
        public void TestPrintJournal()
        {
           
            TreeEvent<Place> tree = new TreeEvent<Place>("BinaryTree");
            Place first = new Region("Россия", "Белгородская область");

            Journal journal = new Journal();
            tree.TreeCountChanged += journal.WriteRecord;

            
            tree.Add(first);

           
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                
                journal.PrintJournal();

               
                string result = sw.ToString().Trim();

              
                string expectedString = "Коллекция: BinaryTree, Изменение:  был добавлен элемент , Предмет: Россия-Белгородская область";

                
                Assert.AreEqual(expectedString, result, "Вывод журнала не соответствует ожидаемой строке.");
            }
        }

        [TestMethod]
        public void TestChangeJournal()
        {

            TreeEvent<Place> tree = new TreeEvent<Place>("BinaryTree");
            Place first = new Region("Россия", "Белгородская область");
            Place change = new Region("Россия", "Белая область");


            Journal journal = new Journal();
            tree.TreeReferenceChanged += journal.WriteRecord;


            tree.Add(first);
            tree[0] = change;



            // Перенаправляем вывод консоли в строку
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Вызываем метод PrintJournal
                journal.PrintJournal();

                // Получаем результат вывода
                string result = sw.ToString().Trim();

                // Ожидаемые строки
                
                string expectedString2 = "Коллекция: BinaryTree, Изменение:  был удален элемент , Предмет: Россия-Белгородская область";
                string expectedString3 = "Коллекция: BinaryTree, Изменение:  был изменен на , Предмет: Россия-Белая область";

                // Проверяем наличие обеих строк в результате вывода
                
                bool containsExpectedString2 = result.Contains(expectedString2);
                bool containsExpectedString3 = result.Contains(expectedString3);

                // Утверждаем, что обе строки существуют
                
                Assert.IsTrue(containsExpectedString2, "Журнал не содержит вторую ожидаемую строку.");
                Assert.IsTrue(containsExpectedString3, "Журнал не содержит третью ожидаемую строку.");
            }
        }

        [TestMethod]

        public void GetIndex()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("Россия", "Белгородская область");
            Place second = new Region("Бангладеш", "Новгородская область");

            tree.Add(first);
            tree.Add(second);

            Assert.AreEqual(tree[0], first);
        }

        [TestMethod]
        public void RemoveError()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("Россия", "Белгородская область");
            Place second = new Region("Бангладеш", "Новгородская область");

            bool isDeleted = tree.Remove(first);

            // Assert
            Assert.IsFalse(isDeleted);
        }



    }
}