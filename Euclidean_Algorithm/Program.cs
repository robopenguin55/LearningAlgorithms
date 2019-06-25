using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidean_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Finding GCD between {args[0]} and {args[1]}");
            int gcd = GCD(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]));
            Console.WriteLine($"GCD is {gcd}");
            Console.ReadLine();
        }

        /// <summary>
        /// Returns the greatest common divisor (GCD) between the given numbers
        /// </summary>
        /// <returns>greatest common divisor</returns>
        static int GCD(int a, int b)
        {
            if (a % b > 0)
            {
                b = a % b;
                return GCD(a, b);
            }
            else
                return b;
        }
    }
}
