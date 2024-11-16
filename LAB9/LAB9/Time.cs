using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    public class Time
    {
        private int hours;
        private int minutes;
        private static int counts;
        public int Hours
        {
            get { return hours; }
            set
            {
                if (value >= 0)
                {
                    hours = value;
                }
                else
                {
                    throw new Exception("Время не может быть меньше 0");
                }
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value >= 0)
                {
                    hours += value / 60;
                    minutes = value % 60;
                }
                else
                {
                    throw new Exception("Время не может быть меньше 0");
                }
            }
        }
        public Time()
        {
            Hours = 0;
            Minutes = 0;
            counts++;
        }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            counts++;
        }
        //public Time(int minutes) {
        //    Minutes = minutes;
        //}
        public static void AmountToNull()
        {
            counts = 0;
        }
        public static void DecreaseAmount()
        {
            counts--;
        }
        public static int GetAmount()
        {
            return counts;
        }
        public Time Minus(Time other)
        {
            int total_minutes = this.ToInt() - other.ToInt();
            if (total_minutes >= 0)
            {
                this.Minutes = 0;
                this.Hours = 0;
                this.Minutes = total_minutes;
                return this;
            }
            else
            {
                throw new InvalidOperationException("Невозможно уменьшить время");
            }
        }

        public static Time operator ++(Time time)
        {
            time.Minutes++;
            return time;
        }
        public static Time operator --(Time time)
        {
            if (time.Hours == 0 && time.Minutes == 0)
            {
                throw new InvalidOperationException("Невозможно уменьшить время");
            }
            //if (time.Minutes == 0)
            //{
            //    time.Minutes = 0;
            //    time.Hours = 0;
            //    int total = time.ToInt();
            //    total--;
            //    time.Minutes = total;
            //}

            if (time.Minutes == 0)
            {
                if (time.Hours > 0)
                {
                    time.Hours--;
                    time.Minutes = 59;
                }
            }
            else
            {
                time.Minutes--;
            }
            return time;
        }

        public int ToInt()
        {
            int total_minutes = (Minutes + (Hours * 60));
            return total_minutes;
        }
        public bool IsNull()
        {
            if (Hours != 0 && Minutes != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Time time1, Time time2)
        {
            int munites_One = time1.ToInt();
            int munites_Two = time2.ToInt();
            return munites_One > munites_Two;
        }
        public static bool operator <(Time time1, Time time2)
        {
            int munites_One = time1.ToInt();
            int munites_Two = time2.ToInt();
            return munites_One < munites_Two;
        }
    }
}
