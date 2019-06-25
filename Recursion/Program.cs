using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(args[0]);

            int factorial = Factorial(number);

            Console.WriteLine($"!{number} is {factorial}");
            Console.ReadLine(); 
        }

        static int Factorial(int number)
        {
            if (number > 1)
            {
                return number * Factorial(number - 1);
            }
            else
            {
                return 1;
            }
        }
    }
}
