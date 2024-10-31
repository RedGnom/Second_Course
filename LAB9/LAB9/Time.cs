using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            get { return hours;}
            set {
                hours = value;
            }
        }
        public int Minutes
        {
            get {return minutes; }
            set
            {
                minutes = value;
            }
        }
        public Time()
        {
            Hours = 0;
            Minutes = 0;
            counts++;
        }
        public Time(int hours, int minutes) {
            int total_minutes = (minutes + (hours * 60));
            Hours = total_minutes / 60;
            Minutes = total_minutes % 60;
            counts++;
        }
        public static void DecreaseAmount()
        {
            counts--;
        }
        public static int GetAmount()
        {
            return counts;
        }
        public Time minus(Time other) {
            int total_minutes = (Minutes+(Hours*60))-(other.Minutes+(other.Hours*60));
            if (total_minutes > 0)
            {
                Hours = total_minutes / 60;
                Minutes = total_minutes % 60;
                return this;
            }
            else
            {
                Hours = 0;
                Minutes = 0;
                return this;
            }


        }
        public static Time operator ++(Time time)
        {
            if (time.Minutes == 59)
            {
                time.Hours++;
                time.Minutes = -1;
            }
            time.Minutes++;
            return time;
        }
        public static Time operator --(Time time)
        {
            if ((time.minutes==0) && (time.Hours>0))
            {
                time.Minutes = 60;
                time.Hours--;
            }
            if (time.Hours==0 && time.Minutes==0)
            {
                throw new InvalidOperationException("Невозможно уменьшить время");
            }
            time.Minutes--;
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

        public static bool operator >(Time time1, Time time2) { 
            int munites_One = time1.Minutes + (time1.Hours * 60);
            int munites_Two = time2.Minutes + (time2.Hours * 60);
            return munites_One > munites_Two;
        }
        public static bool operator <(Time time1, Time time2) { 
            int munites_One = time1.Minutes + (time1.Hours * 60);
            int munites_Two = time2.Minutes + (time2.Hours * 60);
            return munites_One < munites_Two;
        }
    }
}
