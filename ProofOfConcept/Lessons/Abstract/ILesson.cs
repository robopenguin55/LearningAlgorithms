using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Lessons.Abstract
{
    public interface ILesson
    {
        void InvokeLesson();
        void DisplayMenu();
        void ExitLesson();
        void MenuOperator();
    }
}
