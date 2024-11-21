using System;
using LAB10_lib;

class Program
{
    static void Main(string[] args)
    {
        int choice = 1;
        switch (choice)
        {
            case 1:
                int i = 0;
                Place[] arr = new Place[4];


                for (; i < arr.Length / 4; i++) // Заполняем первую четверть массива Region
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
                break;

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
