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
            Place first = new Region("������", "������������ �������");
            Place second = new Region("���������", "������������ �������");

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
            Place first = new Region("������", "������������ �������");
            Place second = new Region("���������", "������������ �������");

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
            Place first = new Region("������", "������������ �������");
            Place change = new Region("������", "����� �������");
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
            Place first = new Region("������", "������������ �������");
            Place change = new Region("������", "����� �������");
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
            Place first = new Region("������", "������������ �������");

            Journal journal = new Journal();
            tree.TreeCountChanged += journal.WriteRecord;

            
            tree.Add(first);

           
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                
                journal.PrintJournal();

               
                string result = sw.ToString().Trim();

              
                string expectedString = "���������: BinaryTree, ���������:  ��� �������� ������� , �������: ������-������������ �������";

                
                Assert.AreEqual(expectedString, result, "����� ������� �� ������������� ��������� ������.");
            }
        }

        [TestMethod]
        public void TestChangeJournal()
        {

            TreeEvent<Place> tree = new TreeEvent<Place>("BinaryTree");
            Place first = new Region("������", "������������ �������");
            Place change = new Region("������", "����� �������");


            Journal journal = new Journal();
            tree.TreeReferenceChanged += journal.WriteRecord;


            tree.Add(first);
            tree[0] = change;



            // �������������� ����� ������� � ������
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // �������� ����� PrintJournal
                journal.PrintJournal();

                // �������� ��������� ������
                string result = sw.ToString().Trim();

                // ��������� ������
                
                string expectedString2 = "���������: BinaryTree, ���������:  ��� ������ ������� , �������: ������-������������ �������";
                string expectedString3 = "���������: BinaryTree, ���������:  ��� ������� �� , �������: ������-����� �������";

                // ��������� ������� ����� ����� � ���������� ������
                
                bool containsExpectedString2 = result.Contains(expectedString2);
                bool containsExpectedString3 = result.Contains(expectedString3);

                // ����������, ��� ��� ������ ����������
                
                Assert.IsTrue(containsExpectedString2, "������ �� �������� ������ ��������� ������.");
                Assert.IsTrue(containsExpectedString3, "������ �� �������� ������ ��������� ������.");
            }
        }

        [TestMethod]

        public void GetIndex()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("������", "������������ �������");
            Place second = new Region("���������", "������������ �������");

            tree.Add(first);
            tree.Add(second);

            Assert.AreEqual(tree[0], first);
        }

        [TestMethod]
        public void RemoveError()
        {
            // Arrange
            TreeEvent<Place> tree = new TreeEvent<Place>("TestTree");
            Place first = new Region("������", "������������ �������");
            Place second = new Region("���������", "������������ �������");

            bool isDeleted = tree.Remove(first);

            // Assert
            Assert.IsFalse(isDeleted);
        }



    }
}