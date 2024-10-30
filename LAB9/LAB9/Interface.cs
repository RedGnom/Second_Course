using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    internal class Interface
    {
        private static int Read()
        {
            int n;
            bool isCorrect = true;
            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out n);
                if (!isCorrect || n < -1)
                {
                    Console.WriteLine("Неверные данные, повторите попытку ввода");
                    isCorrect = false;
                }
            }
            while (!isCorrect);
            return n;
        }
        public static void Read(out Time time) {
            Console.WriteLine("Введите количество минут: ");
            int minutes = Read();
            Console.WriteLine("Введите количество часов: ");
            int hours = Read();
            time = new Time(hours, minutes);
        }
        public static void Write(Time time) {
            Console.WriteLine("Количество часов: "+time.Hours+ "  Количество минут: " + time.Minutes);
        }

    }
}
