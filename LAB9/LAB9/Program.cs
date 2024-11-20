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
                throw new InvalidOperationException("Невозможно уменьшить время");

            }
            
        }
        static void CaseOne()
        {
            Time time = new Time();
            Time time2 = new Time();
            Time time3 = new Time();
            Console.WriteLine("Вычитаемый элемент");
            Interface.Read(out time);
            Interface.Write(time);
            Console.WriteLine("Элемент из которого вычитают");
            Interface.Read(out time2);
            Interface.Write(time2);

            try
            {
                time3 = Minus(time2, time);
                time2.Minus(time);
                Console.WriteLine("Вычитание времени через функцию");
                Interface.Write(time2);
                Console.WriteLine("Вычитание времени через метод");
                Interface.Write(time3);
            }
            catch (Exception ex) {
                Console.WriteLine("Ошибка при вычитании: " + ex.Message);
            }

            int count = Time.GetAmount();
            Console.WriteLine("Количество объектов в сессии:" + count);
            bool isFinal = false;
            while (!isFinal)
            {
                Console.WriteLine("Хотите ли вы продолжить действия с элементом. 1 - Да, Другая цифра - нет ");
                int choice = Interface.ReadElem();

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Введите элемент для вычитания");
                            Interface.Read(out time);
                            Console.WriteLine("Результат вычитания:  ");
                            Interface.Write(time2.Minus(time));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при вычитании: " + ex.Message);
                        }
                        break;
                    default:
                        isFinal = true;
                        break;
                }
            }
            Time.AmountToNull();
        }
        static void CaseTwo()
        {
            Time time = new Time();
            Interface.Read(out time);
            bool isFinal = false;
            while (!isFinal)
            {
                Console.WriteLine("Выберите действия. 1 - Добавить 1, 2 - Вычесть 1, 3 - Получить кол-во минут,\n" +
                    " 4 - Равно ли 0, 5 - Сравнение с другим врменем, 6 - Выход ");
                int choice = Interface.ReadElem();

                switch (choice)
                {
                    case 1:
                        time++;
                        Interface.Write(time);
                        break;
                    case 2:
                        try
                        {
                            time--;
                            Interface.Write(time);
                        }
                        catch (Exception ex) {
                            Console.WriteLine("Ошибка при вычитании: " + ex.Message);
                        }
                        break;
                    case 3:
                        int minutes = time.ToInt();
                        Console.WriteLine("Всего минут:" +  minutes);
                        break;
                    case 4:
                        Console.WriteLine("Часы и минуты не 0 " + time.IsNull());
                        break;
                    case 5:
                        Console.WriteLine("Время для сравнения");
                        Time timeCompar = new Time();
                        Interface.Read(out timeCompar);
                        Console.WriteLine("Изначальное время больше введненого: " + (time>timeCompar));
                        Console.WriteLine("Изначальное время меньше введненого: " + (time < timeCompar));
                        break;

                    case 6:
                        isFinal = true;
                        break;
                    default:
                        Console.WriteLine("Повторите попытку");
                        break;

                }
            }
            Time.AmountToNull();
            
        }
       
        static void CaseThree()
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
                        Console.WriteLine("Введите размер: ");
                        size = Interface.ReadElem();
                        TimeArray array = new TimeArray(size, rnd);
                        Interface.Write(array);
                        Console.WriteLine("Количество элементов в классе:" + size);
                        Console.Write("Максимальный элемент: ");
                        try { Interface.Write(array.GetMax()); }
                        catch(ArgumentException ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                        break;
                    case 2:
                        Console.WriteLine("Введите размер: ");
                        size = Interface.ReadElem();
                        TimeArray arrayTwo = new TimeArray(size, true);
                        Console.WriteLine("Количество элементов в классе:" + size);
                        Interface.Write(arrayTwo);
                        Console.Write("Максимальный элемент: ");
                        try { Interface.Write(arrayTwo.GetMax()); }
                        catch (ArgumentException ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                        break;
                    case 3:
                        isFinal = true;
                        //Console.WriteLine("Количество созданных объектов arr: " + TimeArray.GetAmount());
                        break;
                    default:
                        Console.WriteLine("Повторите попытку");
                        break;

                }

            }
        }
        static void Main(string[] args)
        {
            bool isFinal = false;
            while (!isFinal)
            {
                Console.WriteLine("Выберите часть: 1 - Первая часть, 2 - Вторая часть, 3 - Третья часть, 4 - Выход");
                int choice = Interface.ReadElem();

                switch (choice)
                {
                    case 1:
                        CaseOne();
                        break;
                    case 2:
                        CaseTwo();
                        break;
                    case 3:
                        CaseThree();
                        break;
                    case 4:
                        isFinal= true;
                        break;
                    default:
                        Console.WriteLine("Повторите попытку");
                        break;

                }

            }

        }
    }
}
