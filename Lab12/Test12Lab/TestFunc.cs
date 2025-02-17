using Lab12;
using LAB10_lib;
namespace Test12Lab
{
    [TestClass]
    public class TestFunc
    {
        [TestMethod]
        public void TestConstructor()
        {
            BinaryTree<Place> tree = new BinaryTree<Place>();

            Assert.AreEqual(0, tree.Count);
            Assert.AreEqual(null, tree.Root);
        }
        [TestMethod]
        public void TestAddFunc()
        {
            BinaryTree<Place> tree = new BinaryTree<Place>();

            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������"); 
            Place third = new Region("������", "�������� ����");

            tree.Add(first);
            tree.Add(second);
            tree.Add(third);

            Assert.IsTrue(first.Equals(tree.Root.Value));
            Assert.IsTrue(second.Equals(tree.Root.Left.Value));
            Assert.IsTrue(third.Equals(tree.Root.Right.Value));
        }
        [TestMethod]
        public void TestDeepCopyConstructor() {
            BinaryTree<Place> tree = new BinaryTree<Place>();

            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");

            tree.Add(first);
            tree.Add(second);
            tree.Add(third);

            var deepCopy = new BinaryTree<Place>(tree);
            Assert.IsTrue(first.Equals(deepCopy.Root.Value));
            Assert.IsTrue(second.Equals(deepCopy.Root.Left.Value));
            Assert.IsTrue(third.Equals(deepCopy.Root.Right.Value));
        }
        [TestMethod]
        public void TestShalowCopy()
        {
            BinaryTree<Place> tree = new BinaryTree<Place>();
            

            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");

            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            BinaryTree<Place> shallow = (BinaryTree<Place>)tree.Clone();


            Assert.IsTrue(first.Equals(shallow.Root.Value));
            Assert.IsTrue(second.Equals(shallow.Root.Left.Value));
            Assert.IsTrue(third.Equals(shallow.Root.Right.Value));
        }
        [TestMethod]
        public void ClearTreeFunc()
        {
            BinaryTree<Place> tree = new BinaryTree<Place>();


            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");

            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            BinaryTree<Place> shallow = (BinaryTree<Place>)tree.Clone();
            tree.Clear();

            Assert.IsNull(tree.Root);
            Assert.IsNull(shallow.Root.Value);
        }
        [TestMethod]
        public void TestContainsFunc()
        {
            BinaryTree<Place> tree = new BinaryTree<Place>();


            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");
            Place four = new City("������", "������������� ����", "������", 20000000);

            Place find = new City("", "������������� ����", "", 20);
            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            tree.Add(four);

            Assert.IsTrue(tree.Contains(find));
        }
        [TestMethod]
        public void TestNotContains()
        {
            BinaryTree<Place> tree = new BinaryTree<Place>();


            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");
            Place four = new City("������", "������������� ����", "������", 20000000);

            Place find = new City("", "����", "", 20);
            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            tree.Add(four);

            Assert.IsFalse(tree.Contains(find));
        }
        [TestMethod]
        public void TestCopyToFunc()
        {
            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");
            Place four = new City("������", "������������� ����", "������", 20000000);

            BinaryTree<Place> tree = new BinaryTree<Place>();
            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            tree.Add(four);

            Place[] array = new Place[4];
            tree.CopyTo(array, 0);
            foreach (Place place in array) {
                place.Show();
            }
            
            CollectionAssert.AreEqual(new Place[] { first, second, four, third }, array);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCopyToException()
        {
            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");
            Place four = new City("������", "������������� ����", "������", 20000000);

            BinaryTree<Place> tree = new BinaryTree<Place>();
            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            tree.Add(four);

            Place[] array = Array.Empty<Place>();
            tree.CopyTo(array, 0);
        }
        [TestMethod]
        public void TestNumeratorConstructor()
        {
            // Arrange
            Place first = new Region("������", "������������ �������");
            Place second = new Region("������", "������������ �������");
            Place third = new Region("������", "�������� ����");
            Place four = new City("������", "������������� ����", "������", 20000000);

            BinaryTree<Place> tree = new BinaryTree<Place>();
            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            tree.Add(four);

            IEnumerator<Place> enumerator = tree.GetEnumerator();

            // Act & Assert
            Assert.IsTrue(enumerator.MoveNext(), "������ ����� MoveNext ������ ���������� true");
            Console.WriteLine($"������� �������: {enumerator.Current}");
            Assert.AreEqual(first, enumerator.Current, "������ ������� ������ ���� 'first'");

            Assert.IsTrue(enumerator.MoveNext(), "������ ����� MoveNext ������ ���������� true");
            Console.WriteLine($"������� �������: {enumerator.Current}");
            Assert.AreEqual(second, enumerator.Current, "������ ������� ������ ���� 'second'");

            Assert.IsTrue(enumerator.MoveNext(), "������ ����� MoveNext ������ ���������� true");
            Console.WriteLine($"������� �������: {enumerator.Current}");
            Assert.AreEqual(four, enumerator.Current, "������ ������� ������ ���� 'four'");

            Assert.IsTrue(enumerator.MoveNext(), "��������� ����� MoveNext ������ ���������� true");
            Console.WriteLine($"������� �������: {enumerator.Current}");
            Assert.AreEqual(third, enumerator.Current, "��������� ������� ������ ���� 'third'");

            Assert.IsFalse(enumerator.MoveNext(), "����� ����� MoveNext ������ ���������� false, ��� ��� ��������� ������ ���");
        }
      
        [TestMethod]
        public void EmptyTree_ShouldHaveCountZero()
        {
            var tree = new BinaryTree<int>();
            Assert.AreEqual(0, tree.Count);
        }


    }
}