using System;
using System.Collections.Immutable;
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


        bool isFinal = false;
        while (!isFinal) {
            Console.WriteLine("1 - Объекты всех классов и сортировка, 2 - Запросы, клоны и бинарный поиск" +
                ", 3 - Обьекты интрефейса iinit, 4 - Выход");
            int choice = ReadElem();
            
            switch (choice) {
                case 1:
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

                    Console.WriteLine("Вывод невиртуально");
                    foreach (var p in arr)
                    {
                        // Проверка типа объекта
                        if (p is Region r)
                        {
                            r.ShowNonVirtual();
                        }
                        else if (p is City c)
                        {
                            c.ShowNonVirtual();
                        }

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
                    Console.WriteLine("Сортировка через comparer области");
                    Array.Sort(arr, new Comparer());
                    Console.WriteLine("Отсортированный: ");
                    foreach (Place p in arr)
                    {
                        p.Show();
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    //Console.WriteLine("Введите область из которой нужно получить города: ");
                    Console.WriteLine("Область в которой будут браться города: ");
                    Region region = new Region();
                    region.RandomInit();
                    region.Show();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Вывод всех городов и мегаполисов: ");
                    Place[] arr2 = new Place[10];
                    i = 0;
                    for (; i < arr2.Length / 2; i++)
                    {
                        arr2[i] = new City(); 
                        arr2[i].RandomInit();
                        region.AddCity((City)arr2[i]);
                    }
                    for (; i < arr2.Length; i++)
                    {
                        arr2[i] = new Megalopolis();
                        arr2[i].RandomInit();
                        region.AddCity((City)arr2[i]);
                    }
                    Array.Sort(arr2, new Comparer());
                    foreach (City obj in arr2)
                    {
                        obj.Show();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Города в области");
                    region.ShowCities();
                    Console.WriteLine("Общее население");
                    region.ShowPopulation();
                    Console.WriteLine("Количество городов");
                    region.ShowAmount();
                    Region clone = (Region)region.ShallowCopy();
                    Region clone2 = (Region)region.Clone();
                    Console.WriteLine("Вывод клонов объекта, 1 - поверхностный");
                    clone.Show();
                    clone.ShowCities();
                    Console.WriteLine("Глубокое копирование");
                    clone2.Show();
                    clone2.ShowCities();
                    City test = new City(" ", region.Name, "Петропавловск", 10090);
                    region.AddCity(test);
                    Console.WriteLine("Добавился город в область");
                    test.Show();
                    Console.WriteLine("Вывод городов первого клона: ");
                    clone.ShowCities();
                    Console.WriteLine("Второй клон: ");
                    clone2.ShowCities();

                    Console.WriteLine("Поиск города по области, : (Пермский край)  ");

                    //arr2[2] = new City("", "Белгородская область", "Белгород", 350000);
                    Place targetPlace = new City("", "Пермский край", "", 0); ;
                    int index = Array.BinarySearch(arr2, targetPlace, new Comparer());

                    if (index >= 0)
                    {
                        // Сдвигаемся влево до первого элемента с таким же названием области
                        while (index > 0 && arr2[index - 1].Name == targetPlace.Name)
                        {
                            index--;
                        }

                        Console.WriteLine($"Элемент найден на номере: {index+1}");
                        arr2[index].Show();
                    }
                    else
                    {
                        Console.WriteLine("Элемент не найден.");
                    }

                    break;
                case 3:
                    Console.WriteLine("Ввод элементов интерфейса iinit");

                    IInit[] arr3 = new IInit[5];
                    arr3[0] = new Vehicle();
                    arr3[0].Init();
                    arr3[1] = new Region();
                    arr3[1].Init();
                    arr3[2] = new City();
                    arr3[3] = new Megalopolis();
                    arr3[4] = new Address();
                    arr3[2].RandomInit();
                    arr3[3].RandomInit();
                    arr3[4].RandomInit();

                    foreach (IInit obj in arr3)
                    {
                        if (obj is Place placeObj)
                        {
                            placeObj.Show();
                        }
                        else if (obj is Vehicle vehicleObj)
                        {
                            vehicleObj.Show();
                        }


                    }
                    break ;
                case 4:
                    isFinal = true;
                    break ;
                default:
                    Console.WriteLine("Неверный ввод");
                    break ;



            }
        }


        //int i = 0;
        //Place[] arr = new Place[4];

        //for (; i < arr.Length / 4; i++)
        //{
        //    arr[i] = new Region();
        //    arr[i].RandomInit();
        //    arr[i].Show();
        //    Console.WriteLine();
        //}

        //for (; i < arr.Length / 2; i++) // Заполняем вторую четверть массива City
        //{
        //    arr[i] = new City();
        //    arr[i].RandomInit();
        //    arr[i].Show();
        //    Console.WriteLine();
        //}


        //for (; i < (arr.Length * 3) / 4; i++) // Заполняем третью четверть массива Megalopolis
        //{
        //    arr[i] = new Megalopolis();
        //    arr[i].RandomInit();
        //    arr[i].Show();
        //    Console.WriteLine();
        //}


        //for (; i < arr.Length; i++) // Заполняем оставшуюся часть массива Address
        //{
        //    arr[i] = new Address();
        //    arr[i].RandomInit();
        //    arr[i].Show();
        //    Console.WriteLine();
        //}
        //Console.WriteLine("Сортировка массива через comparable страны: ");
        //Array.Sort(arr);
        //Console.WriteLine("Отсортированный: ");
        //foreach (Place p in arr)
        //{

        //    p.Show();
        //    Console.WriteLine();
        //}
        //Console.WriteLine("Сортировка через compare области");
        //Array.Sort(arr, new Comparer());
        //Console.WriteLine("Отсортированный: ");
        //foreach (Place p in arr)
        //{
        //    p.Show();
        //    Console.WriteLine();
        //}

        //Console.WriteLine("\n\n\n\n\n\n");

        //Console.WriteLine("Введите область из которой нужно получить города: ");
        //Region region = new Region();
        //region.Init();
        //region.Show();
        //Console.WriteLine("\n\n");
        //Console.WriteLine("Вывод всех городов и мегаполисов: ");
        //Place[] arr2 = new Place[10];
        //i = 0;
        //for (; i < arr2.Length / 2; i++)
        //{
        //    arr2[i] = new City();
        //    arr2[i].RandomInit();
        //    arr2[i].Show();
        //    region.AddCity((City)arr2[i]);
        //    Console.WriteLine();
        //}


        //for (; i < arr2.Length; i++)
        //{
        //    arr2[i] = new Megalopolis();
        //    arr2[i].RandomInit();
        //    arr2[i].Show();
        //    region.AddCity((City)arr2[i]);
        //    Console.WriteLine();
        //}
        //Console.WriteLine("Города в области");
        //region.ShowCities();
        //Console.WriteLine("Общее население");
        //region.ShowPopulation();
        //Console.WriteLine("Количество городов");
        //region.ShowAmount();
        //Region clone = (Region)region.ShallowCopy();
        //Region clone2 = (Region)region.Clone();
        //Console.WriteLine("Вывод клонов объекта");
        //clone.Show();
        //clone.ShowCities();
        //clone2.Show();
        //clone2.ShowCities();
        //City test = new City(" ", region.Name, "Петропавловск", 10090);
        //region.AddCity(test);
        //Console.WriteLine("Добавился город в область");
        //test.Show();
        //Console.WriteLine("Первый клон: ");
        //clone.ShowCities();
        //Console.WriteLine("Второй клон: ");
        //clone2.ShowCities();






        //Console.WriteLine("Поиск города по области, : ");
        ////arr2[4] = new City("", "Белгородская область", "Белгород", 350000);
        //Place targetPlace = new City("", "Белгородская область", "", 0); ;
        //int index = Array.BinarySearch(arr2, targetPlace, new Comparer());

        //if (index >= 0)
        //{
        //    Console.WriteLine($"Элемент найден на индексе: {index}");
        //    arr2[index].Show();
        //}
        //else
        //{
        //    Console.WriteLine("Элемент не найден.");
        //}


        //    Console.WriteLine("\n\n\n\n");
        //    Console.WriteLine("Ввод элементов интерфейса iinit");

        //    IInit[] arr3 = new IInit[5];
        //    arr3[0] = new Vehicle();
        //    arr3[0].Init();
        //    arr3[1] = new Region();
        //    arr3[1].Init();
        //    arr3[2] = new City();
        //    arr3[3] = new Megalopolis();
        //    arr3[4] = new Address();
        //    arr3[2].RandomInit();
        //    arr3[3].RandomInit();
        //    arr3[4].RandomInit();

        //    foreach (IInit obj in arr3) {
        //       obj.Show();
        //    }





    }
}
