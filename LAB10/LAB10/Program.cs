using System;
using System.Numerics;
using LAB10_lib;

class Program
{
    static void Main(string[] args)
    {
        static int ReadElem()
        {
            int n;
            bool isCorrect = true;
            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out n);
                if (!isCorrect || n < 0)
                {
                    Console.WriteLine("Неверные данные, повторите попытку ввода");
                    isCorrect = false;
                }
            }
            while (!isCorrect);
            return n;
        }
        
        Console.WriteLine("Вывод объектов из всех классов");


        int i = 0;
        Place[] arr = new Place[4];

        for (; i < arr.Length / 4; i++)
        {
            arr[i] = new Region();
            arr[i].RandomInit();
            arr[i].Show();
            Console.WriteLine();
        }

        for (; i < arr.Length / 2; i++) // Заполняем вторую четверть массива City
        {
            arr[i] = new City();
            arr[i].RandomInit();
            arr[i].Show();
            Console.WriteLine();
        }


        for (; i < (arr.Length * 3) / 4; i++) // Заполняем третью четверть массива Megalopolis
        {
            arr[i] = new Megalopolis();
            arr[i].RandomInit();
            arr[i].Show();
            Console.WriteLine();
        }


        for (; i < arr.Length; i++) // Заполняем оставшуюся часть массива Address
        {
            arr[i] = new Address();
            arr[i].RandomInit();
            arr[i].Show();
            Console.WriteLine();
        }
        Console.WriteLine("Сортировка массива через comparable страны: ");
        Array.Sort(arr);
        Console.WriteLine("Отсортированный: ");
        foreach (Place p in arr)
        {

            p.Show();
            Console.WriteLine();
        }
        Console.WriteLine("Сортировка через compare области");
        Array.Sort(arr, new Comparer());
        Console.WriteLine("Отсортированный: ");
        foreach (Place p in arr)
        {
            p.Show();
            Console.WriteLine();
        }

        Console.WriteLine("\n\n\n\n\n\n");

        Console.WriteLine("Введите область из которой нужно получить города: ");
        Region region = new Region();
        region.Init();
        region.Show();
        Console.WriteLine("\n\n");
        Console.WriteLine("Вывод всех городов и мегаполисов: ");
        Place[] arr2 = new Place[10];
        i = 0;
        for (; i < arr2.Length / 2; i++)
        {
            arr2[i] = new City();
            arr2[i].RandomInit();
            arr2[i].Show();
            region.AddCity((City)arr2[i]);
            Console.WriteLine();
        }


        for (; i < arr2.Length; i++)
        {
            arr2[i] = new Megalopolis();
            arr2[i].RandomInit();
            arr2[i].Show();
            region.AddCity((City)arr2[i]);
            Console.WriteLine();
        }
        Console.WriteLine("Города в области");
        region.ShowCities();
        Console.WriteLine("Общее население");
        region.ShowPopulation();
        Console.WriteLine("Количество городов");
        region.ShowAmount();

        Console.WriteLine("Поиск города по области, : ");
        arr2[4] = new City("Россия","Белгородская область", "Белгород", 350000);
        Place targetPlace = new City("Россия", "Белгородская область", "Белгород", 0); ;
        int index = Array.BinarySearch(arr2, targetPlace, new Comparer());

        if (index >= 0)
        {
            Console.WriteLine($"Элемент найден на индексе: {index}");
            arr2[index].Show();
        }
        else
        {
            Console.WriteLine("Элемент не найден.");
        }








        //City city = new City();
        //city.RandomInit();
        //city.Show();
        //City city2 = new City(city);
        //city2.Show();
        //Console.WriteLine(city.Equals(region1));

        //Megalopolis megalopolis = new Megalopolis();
        //megalopolis.Init();
        //megalopolis.Show();

        //Address address = new Address();
        //address.RandomInit();
        //address.Show();
        //Console.WriteLine();
        //Address address1 = new Address();
        //address1.RandomInit();
        //address1.Show();
        //Console.WriteLine(address.Equals(address1));


    }
}
