using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    internal class Program
    {
        static Random rnd = new Random();
        static Time Minus(Time timeOne, Time timeTwo)
        {
            int total_minutes = (timeOne.Minutes + (timeOne.Hours * 60)) - (timeTwo.Minutes + (timeTwo.Hours * 60));
            Time time = new Time();
            Time.DecreaseAmount();
            if (total_minutes > 0)
            {
                
                time.Hours = total_minutes / 60;
                time.Minutes = total_minutes % 60;
                return time;
            }
            else
            {
                time.Hours = 0;
                time.Minutes = 0;
                return time;
                
            }
            
        }
        static void CaseOne()
        {
            Time time = new Time();
            Time time2 = new Time();
            Time time3 = new Time();

            Interface.Read(out time);
            Interface.Write(time);

            Interface.Read(out time2);
            Interface.Write(time2);


            time3 = Minus(time2, time);
            time2.Minus(time);

            Console.WriteLine("Вычитание времени через функцию");
            Interface.Write(time2);
            Console.WriteLine("Вычитание времени через метод");
            Interface.Write(time3);


            int count = Time.GetAmount();
            Console.WriteLine("Количество объектов в классе:" + count);
        }
        static void CaseTwo()
        {
            Time time = new Time();
            Time time2 = new Time();
            Interface.Read(out time);
            Interface.Write(time);
            Console.WriteLine("Добавление 1");
            time++;
            Interface.Write(time);
            Console.WriteLine("Вычитание 1");
            time--;
            Interface.Write(time);


            Interface.Read(out time2);
            Interface.Write(time2);
            
            int minutes = time.ToInt();
            bool IsNull = time.IsNull();
            Console.WriteLine("Количество минут: " + minutes + "  Проверка: " + IsNull);
            Console.WriteLine("Первое больше второго: " + (time > time2));
        }
        static void Main(string[] args)
        {
            bool isFinal = false;
            int size;
            while (!isFinal)
            {
                Console.WriteLine("Как заполнить массив: 1 - Автоматически, 2 - Вручную, 3 - Выход");
                int choice = Interface.ReadElem();

                switch (choice)
                {
                    
                    case 1:
                        Console.WriteLine("Введите разрмер: ");
                        size = Interface.ReadElem();
                        TimeArray array = new TimeArray(size, rnd);
                        Interface.Write(array);
                        Console.Write("Максимальный элемент: ");
                        Interface.Write(array.GetMax());
                        break;
                    case 2:
                        Console.WriteLine("Введите разрмер: ");
                        size = Interface.ReadElem();
                        TimeArray arrayTwo = new TimeArray(size, rnd);
                        Interface.Write(arrayTwo);
                        Console.Write("Максимальный элемент: ");
                        Interface.Write(arrayTwo.GetMax());
                        break;
                    case 3:
                        isFinal = true;
                        break;
                    case 4:
                        Console.WriteLine("Повторите попытку");
                        break;

                }

            }

        }
    }
}
