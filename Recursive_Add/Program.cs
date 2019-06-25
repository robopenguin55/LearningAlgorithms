using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Add
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Adding all numbers recursively...");
            int total = RecursiveAdd(Array.ConvertAll(args, int.Parse), args.Length);
            Console.WriteLine($"Total is {total}");
            Console.ReadLine();
        }

        static int RecursiveAdd(int [] numbersToAdd, int length)
        {
            if (length > 0)
                return numbersToAdd[length - 1] + RecursiveAdd(numbersToAdd, length - 1);

            return 0;
        }
    }
}
