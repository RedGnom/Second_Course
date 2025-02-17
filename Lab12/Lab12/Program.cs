using LAB10_lib;
using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool isFinal = false;
            //int choice = 0;
            Console.WriteLine("Генерируем коллекцию(какой набор подается в коллекцию)");
            BinaryTree<Place> tree = new BinaryTree<Place>();
            for (int i = 0; i < 4; i++)
            {
                Place place;
                if (i < 2)
                {
                    place = new City();
                }
                else
                {
                    place = new Megalopolis();
                }
                place.RandomInit();
                place.Show();
                tree.Add(place);
            }
            Console.WriteLine();
            Console.WriteLine("Обьект для поиска");
            Place findThis = new Address("Россия", "Приморский край", "Владивосток", 600000, 5, 64, "Морская");
            findThis.Show();
            Console.WriteLine("\n");
            tree.Add(findThis);
            Place checkFind = new Address("Россия", "Приморский край", "", 6, 5, 6, "Морская");
            //Place first = new Region("Россия", "Белгородская область");
            //Place second = new Region("Бангладеш", "Новгородская область");
            //Place third = new Region("Великая страна", "Пермский край");

            //tree.Add(first);
            //tree.Add(second);
            //tree.Add(third);
            Console.WriteLine("Вывод сгенерированной коллекции");

            foreach (Place place in tree) {
                place.Show();
            }
            Console.WriteLine($"Дерево содержит объект для поиска {tree.Contains(checkFind)}\n\n");

            Console.WriteLine("Делаем поверхностную копию");
            BinaryTree<Place> shallow = (BinaryTree<Place>)tree.Clone();
            Console.WriteLine("Делаем глубокую копию\n\n");
            var deep = new BinaryTree<Place>(tree);

            Console.WriteLine("Создаем нумератор по коллекции");
            IEnumerator<Place> enumerator = tree.GetEnumerator();

            Console.WriteLine($"Смотрим есть ли первый элемент. {enumerator.MoveNext()} Получаем элемент {enumerator.Current}");

            tree.Clear();
            Console.WriteLine("Дерево после очистки\n");

            Console.WriteLine("Проверка на то, осталось ли поверхностная копия\n\n");
            foreach (Place place in shallow) {
                if (place != null)
                {
                    place.Show();
                }
                else
                {
                    Console.WriteLine("Поверностная копия пуста");
                }
            }

            Console.WriteLine("Проверка на то, осталось ли полная копия\n\n");
            foreach (Place place in deep) {
                place.Show();
            }

            



        }
    }
}
