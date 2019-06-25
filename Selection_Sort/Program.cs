using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int item in SelectionSort(args))
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static int[] SelectionSort(string[] unsortedArray)
        {
            int[] sortedArray = new int[unsortedArray.Length];
            int length = unsortedArray.Length;

            for (int index = 0; index < length; index++)
            {
                int smallestindex = FindSmallest(unsortedArray);

                sortedArray[index] = Convert.ToInt32(unsortedArray[smallestindex]);

                unsortedArray = RemoveIndex(unsortedArray, smallestindex);
            }

            return sortedArray;
        }

        static string[] RemoveIndex(string[] unsortedArray, int indexToRemove)
        {
            string[] filteredUnsortedArray = new string[unsortedArray.Length - 1];

            for (int index = 0; index < filteredUnsortedArray.Length; index++)
            {
                if (index < indexToRemove)
                {
                    filteredUnsortedArray[index] = unsortedArray[index];
                }
                else
                {
                    filteredUnsortedArray[index] = unsortedArray[index + 1];
                }
            }

            return filteredUnsortedArray;
        }

        static int FindSmallest(string[] unsortedArray)
        {
            int smallest = int.MaxValue;
            int smallestIndex = 0;

            for (int index = 0; index < unsortedArray.Length;index++)
            {
                int num = Convert.ToInt32(unsortedArray[index]);

                if (num < smallest)
                {
                    smallest = num;
                    smallestIndex = index;
                }
            }

            return smallestIndex;
        }
    }
}
