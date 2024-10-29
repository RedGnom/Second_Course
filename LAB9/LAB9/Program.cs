using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time time = new Time();
            Interface.Read(out time);
            Interface.Write(time);
            Time time2 = new Time();
            Interface.Read(out time2);
            Interface.Write(time2);
            time2.minus(time);
            Interface.Write(time2);


        }
    }
}
