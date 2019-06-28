using ProofOfConcept.Lessons;
using System;

namespace ProofOfConcept
{
    class Program
    {
        static bool exitLesson = false;
        static void Main(string[] args)
        {
            while (!exitLesson)
            {
                InvokeMenu();
            }
        }

        private static void InvokeMenu()
        {
            var menu = "Choose an option to explore:\n"
                     + "****************************\n"
                     + "[1] Binary Search\n"
                     + "[x] Exit";
                     

            Console.WriteLine(menu);
            int result = 0;
            var input = Console.ReadKey().KeyChar;
            if (input == 'x')
            {
                exitLesson = true;
                return;
            }

            int.TryParse(input.ToString(), out result);

            

            if(result == default)
            {
                Console.WriteLine("Oops, couldn't understand that.  Try again please! \n");
                InvokeMenu();
            }
            else
            {
                LessonFactory(result);
            }
        }

        private static void LessonFactory(int lessonSelection)
        {
            switch (lessonSelection)
            {
                case 1:
                    var binarySearch = new BinarySearch();
                    binarySearch.InvokeLesson();
                    break;
                default:
                    break;
            }
        }
    }
}
