using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_lib
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
    }
}
