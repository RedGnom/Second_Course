using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    public class Interface
    {
        public static int ReadElem()
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
        public static void Read(out Time time)
        {
            Console.WriteLine("Введите количество минут: ");
            int minutes = ReadElem();
            Console.WriteLine("Введите количество часов: ");
            int hours = ReadElem();
            time = new Time(hours, minutes);
            Time.DecreaseAmount();
        }
        public static void Write(Time time) 
        {
            Console.WriteLine("Количество часов: " + time.Hours + "  Количество минут: " + time.Minutes);
        }
        public static void Write(TimeArray arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пустой");
            }
            else {
                for (int i = 0; i < arr.Length; i++)
                {
                    Interface.Write(arr[i]);
                }
            }
        }

    }
}
