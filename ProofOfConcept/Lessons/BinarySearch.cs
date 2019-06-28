using ProofOfConcept.Lessons.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Lessons
{
    public class BinarySearch : ILesson
    {
        private bool exitLesson = false;
        private int lowValue = 0;
        private int highValue = 0;
        private string defErrMessage;
        public BinarySearch()
        {
            defErrMessage = "Sorry, couldn't understand that input.  Try again please.";
        }

        public void InvokeLesson()
        {
            Console.Clear();
            while (!exitLesson)
            { 
                DisplayMenu();
                MenuOperator();
                InvokeLesson();
            }
        }

        private void GetTrySet(string message, string failMessage, ref int valRef, bool repeat = true)
        {
            Console.Write(message);
            var input = Console.ReadLine();
            if (input == "exit")
            {
                ExitLesson();
            }
            else
            {
                int.TryParse(input, out valRef);
                if (valRef == 0)
                {
                    GetTrySet(message, failMessage, ref valRef, repeat);
                }
            }
        }

        private void CalcMaxSteps()
        {
            Console.WriteLine("\nEnter a high and low (greater than 0) value range.");
            GetTrySet("Low Value: ", defErrMessage, ref lowValue, true);
            GetTrySet("High Value: ", defErrMessage, ref highValue, true);

            //calculate the log of the values.
            //var maxSearchCount = (int)Math.Floor(Math.Log(highValue-lowValue, 2));
            var maxSearchCount = (int)Math.Ceiling(Math.Log(highValue - lowValue, 2));
            Console.WriteLine($"Binary search maximum attempts is {maxSearchCount}");

            Console.Write("Try another? [y]/[n]");
            char input = Console.ReadKey().KeyChar;

            if(input == 'y')
            {
                CalcMaxSteps();
            }
            else
            {
                return;
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Binary Search \n"
                + "**************\n"
                + "Select an option: \n"
                + "[1] Calculate max search steps \n"
                + "[x] Exit the lesson \n"
                );
        }

        public void ExitLesson()
        {
            return;
        }

        public void MenuOperator()
        {
            var input = Console.ReadKey().KeyChar;
            int option;

            if(input == 'x')
            {
                exitLesson = true;
                return;
            }
            else
            {
                int.TryParse(input.ToString(), out option);
                switch (option)
                {
                    case 1:
                        CalcMaxSteps();
                        break;
                    default:
                        Console.WriteLine("Couldn't work with that option.  Try again please.");
                        DisplayMenu();
                        break;
                }
            }
        }
    }
}
