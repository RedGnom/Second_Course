using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    internal class Program
    {
        static Time minus(Time timeOne, Time timeTwo)
        {
            int total_minutes = (timeOne.Minutes + (timeOne.Hours * 60)) - (timeTwo.Minutes + (timeTwo.Hours * 60));
            Time time = new Time();
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
        static void Main(string[] args)
        {
            Time time = new Time();
            Time time2 = new Time();
            Time time3 = new Time();

            Interface.Read(out time);
            Interface.Write(time);
            
            Interface.Read(out time2);
            Interface.Write(time2);

            Console.WriteLine("Вычитание времени через функцию");
            time3 = minus(time2, time);
            Console.WriteLine("Вычитание времени через метод");
            time2.minus(time);

            Interface.Write(time2);
            Interface.Write(time3);




        }
    }
}
