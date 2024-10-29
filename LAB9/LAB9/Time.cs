using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int counts;

        public int Hours
        {
            get { return hours; }
            set {
                if (int.TryParse(Console.ReadLine(), out value) || value >0)
                {
                    hours = value;
                }
                else {
                    throw new ArgumentException("Количество часов меньше 0 или некорректный ввод");
                }
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (int.TryParse(Console.ReadLine(), out value) || value > 0)
                {
                    minutes = value;
                }
                else
                {
                    throw new ArgumentException("Количество минут меньше 0 или некорректный ввод");
                }
            }
        }
        public Time()
        {
            Hours = 0;
            Minutes = 0;

        }
        public Time(int hours, int minutes) {
            Minutes = minutes;
            if (Minutes > 59)
            {
                Hours = hours+1;
                Minutes = -60;
            }
            else
            {
                Hours = hours;
            }
        }
    }
}
