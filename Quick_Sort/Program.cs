using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToSort = new int[args.Length];

            Console.WriteLine("Original Array");

            for (int index = 0; index < args.Length;index++)
            {
                arrayToSort[index] = Convert.ToInt32(args[index]);
                Console.Write("{0} ", args[index]);
            }

            Console.WriteLine();

            int[] sortedArray = QuickSort(arrayToSort);

            Console.WriteLine("Sorted Array");

            for (int index = 0; index < sortedArray.Length; index++)
            {
                Console.Write("{0} ", sortedArray[index]);
            }

            Console.ReadLine();
        }

        static int[] QuickSort(int[] arrayToSort)
        {
            if (arrayToSort.Length < 2)
                return arrayToSort;
            else
            {
                // Find a pivot
                int pivot = arrayToSort.Length / 2;

                int[] less = new int[arrayToSort.Where(i => i < arrayToSort[pivot]).Count()]; // not sure how to size these more efficiently
                int[] more = new int[arrayToSort.Where(i => i > arrayToSort[pivot]).Count()];

                int lessCount = 0;
                int moreCount = 0;

                for (int index = 0; index < arrayToSort.Length; index++)
                {
                    if (arrayToSort[index] < arrayToSort[pivot])
                    {
                        less[lessCount] = arrayToSort[index];
                        lessCount++;
                    }

                    if (arrayToSort[index] > arrayToSort[pivot])
                    {
                        more[moreCount] = arrayToSort[index];
                        moreCount++;
                    }
                }

                int[] finalLesser = QuickSort(less);
                int[] finalGreater = QuickSort(more);

                int[] finalSortedArray = new int[finalGreater.Length + finalLesser.Length + 1];

                int finalCount = 0;

                foreach (int number in finalLesser)
                {
                    finalSortedArray[finalCount++] = number;
                }

                finalSortedArray[finalCount++] = arrayToSort[pivot];

                foreach (int number in finalGreater)
                {
                    finalSortedArray[finalCount++] = number;
                }

                return finalSortedArray;
            }
        }
    }
}
