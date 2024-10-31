using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{

    public class TimeArray

    {
        //private int amount = 0;
        Time[] arr;
        public int Length { get { return arr.Length; } }
        public TimeArray()
        {
            arr = new Time[0];
        }
       
        public TimeArray(int size, Random rnd)
        {
            arr = new Time[size];
            for (int i = 0; i < size; i++) {
                arr[i] = new Time(rnd.Next(0, 100), rnd.Next(0, 59));
            }
        }
        public TimeArray(int size, Random rnd, bool byUser)
        {
            arr = new Time[size];
            if (byUser) {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("Ввод элемента номер: " + (i+1));
                    Time time = new Time();
                    Interface.Read(out time);
                    arr[i] = time;
                }
            }
        }

        public Time this[int index] { 
            get 
            { if (index >= 0 && index < arr.Length)
                    
                { 
                    return arr[index]; 
                } 
                else { 
                    throw new ArgumentException("Индекс вне диапазона массива.");
                } 
            } 
            set
            { 
                if (index >= 0 && index < arr.Length)
                { 
                    arr[index] = value; 
                } 
                else 
                { 
                    throw new ArgumentException("Индекс вне диапазона массива."); 
                } 
            } 
        }
        public Time GetMax()
        {
            Time max = arr[0];
            for (int i = 0;i < arr.Length; i++)
            {
                if(max < arr[i])
                {
                    max = arr[i];
                }
            }
            Time.DecreaseAmount();
            return max;

        }

    }
}
