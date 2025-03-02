using LAB10_lib;
using Lab12;
namespace Lab13

{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeEvent<Place> tree = new TreeEvent<Place>("BinaryTree");
            TreeEvent<Place> tree2 = new TreeEvent<Place>("BinaryTree2");
            Journal journal = new Journal();
            Journal journal2 = new Journal();

            tree.TreeCountChanged += journal.WriteRecord;
            tree.TreeReferenceChanged += journal.WriteRecord;

            tree.TreeReferenceChanged += journal2.WriteRecord;
            tree2.TreeReferenceChanged += journal2.WriteRecord;

            Place first = new Region("Россия", "Белгородская область");
            Place second = new Region("Бангладеш", "Новгородская область");
            Place third = new Region("Великая страна", "Пермский край");
            Place change = new Region("Россия", "Белая область");

            tree.Add(first);
            tree.Add(second);
            tree.Add(third);

            Place additional = new Region("Россия", "Свердловская область");
            tree2.Add(additional);

            Console.WriteLine("Вывод сгенерированной коллекции");

            foreach (Place place in tree)
            {
                place.Show();
            }
            Console.WriteLine("Замена элемента в первой коллекции");
            tree[0] = change;
            Console.WriteLine("Замена элемента во второй коллекции");
            tree2[0] = change;

            Console.WriteLine("Вывод первого журнала действий");
            journal.PrintJournal();
            Console.WriteLine("Вывод второго журнала действий");
            journal2.PrintJournal();


            Console.WriteLine("Вывод коллекции");

            foreach (Place place in tree)
            {
                place.Show();
            }



        }
    }
}
