using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College;

namespace college_course_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            var mySchedule = new List<Term>();

            do
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("*     Welcome to College Course Tracker!    *");
                Console.WriteLine("*            Select a Menu Option:          *");
                Console.WriteLine("*     1. Add a Class                        *");
                Console.WriteLine("*     2. View Classes by Term               *");
                Console.WriteLine("*     3. View Classes by Subject            *");
                Console.WriteLine("*     0. Exit                               *");
                Console.WriteLine("*********************************************");
                input = Convert.ToInt16(Console.ReadLine());

                if (input == 1)
                {
                    MakeClass(mySchedule);
                }
                // else if (input == 1)
                // {
                //     ViewClassesByTerm();
                // }

            } while (input != 0);

            Console.WriteLine("Now Exiting...");
            
        
        }
        static void MakeClass(List<Term> mySchedule)
        {   
            Console.Write("Enter a class name: ");
            string name_input = Console.ReadLine();

            Console.Write("Enter the major of the course (CS, BIO, etc): ");
            string major_input = Console.ReadLine();

            Console.Write("Enter the Course ID: ");
            string id_input = Console.ReadLine();

            Console.Write("Enter the term taken: ");
            string term_input = Console.ReadLine();

            Console.Write("Enter the Grade received in the course: ");
            string grade_input = Console.ReadLine();

            Course newcourse = new Course(name_input, major_input, id_input, term_input, grade_input);
            newcourse.print_course();

            Term newterm = new Term(term_input, newcourse);

            // If a Term already exists in the schedule, make new
            if (!mySchedule.Contains(newterm))
            {
                mySchedule.Add(newterm);
            }
            else
            {
                Term termFound = mySchedule.Find(t => t.termName == term_input);
                termFound.AddClassToTerm(newcourse);
            }
            
        }
        // static void ViewClassesBySubject(List<Term> mySchedule)
        // {
        //     for (int i = 0; i < mySchedule.Count; i++)
        //     {
            
        //     }
        // }
    }
}
