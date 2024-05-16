using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using College;
using System.Collections;

namespace college_course_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            var mySchedule = new List<Course>();

            do
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("*     Welcome to College Course Tracker!    *");
                Console.WriteLine("*            Select a Menu Option:          *");
                Console.WriteLine("*     1. Add a Class                        *");
                Console.WriteLine("*     2. View Classes by Year               *");
                Console.WriteLine("*     3. View Classes by Subject            *");
                Console.WriteLine("*     4. View Classes by GPA                *");
                Console.WriteLine("*     5. Import Classes from file           *");
                Console.WriteLine("*     6. Export Classes to file             *");
                Console.WriteLine("*     0. Exit                               *");
                Console.WriteLine("*********************************************");
                try
                {
                    input = Convert.ToInt16(Console.ReadLine());
                }
                catch 
                {   

                    Console.Write("ERROR: ");
                    input = 0;

                }
                if (input == 1)
                {
                    MakeClass(mySchedule);
                }
                else if (input == 2)
                {
                    ViewClassesByYear(mySchedule);
                }
                else if (input == 3)
                {
                    ViewClassesBySubject(mySchedule);
                }
                else if (input == 4)
                {
                    ViewClassesByGPA(mySchedule);
                }
                else if (input == 5)
                {
                    ImportFromFile(mySchedule);
                }
                else if (input == 6)
                {
                    ExportToFile(mySchedule);
                }
            } while (input != 0);

            Console.WriteLine("Now Exiting...");
            
        
        }
        static void MakeClass(List<Course> mySchedule)
        {   
            Console.Write("Enter a class name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the major of the course (CS, BIO, etc): ");
            string major = Console.ReadLine();

            Console.Write("Enter the Course ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter the Year that the course was taken: ");
            string year = Console.ReadLine();

            Console.Write("Enter the term taken: (Fall, Winter, Spring, Summer) ");
            string term = Console.ReadLine();

            Console.Write("Enter the Grade received in the course: ");
            string grade = Console.ReadLine();

            Course newCourse = new Course(name, major, id, year, term, grade);
            newCourse.print_course();

            

            mySchedule.Add(newCourse);
            
        }
        static void ViewClassesBySubject(List<Course> mySchedule)
        {
            Console.WriteLine("************************************************");

            var sortedBySubject = mySchedule.OrderBy(c => c.courseShort);
            foreach (Course c in sortedBySubject)
            {
                Console.WriteLine(c.print_course());
            }    
        }
        static void ViewClassesByGPA(List<Course> mySchedule)
        {
            Console.WriteLine("************************************************");

            var sortedByGPA = mySchedule.OrderBy(c => c.gpa);
            foreach (Course c in sortedByGPA.Reverse())
            {
                
                Console.WriteLine(c.print_course());
            }
        }
        static void ViewClassesByYear(List<Course> mySchedule)
        {
            var sortedByYear = mySchedule.OrderBy(c => c.get_year()).ThenBy(c => c.orderbyterm());
            Console.WriteLine("************************************************");
            foreach (Course c in sortedByYear)
            {
                Console.WriteLine(c.print_course());
            }    
        }

        static void ImportFromFile(List<Course> mySchedule)
        {   
            Console.Write("Enter file path: ");
            string filepath = Console.ReadLine();

            if (File.Exists(filepath))
            {
                using (StreamReader file = new StreamReader(filepath))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] course_contents = line.Split(',');

                        MakeCourse(course_contents, mySchedule);
                    }
                }
            }
            else 
            {
                Console.WriteLine("ERROR: File does not exist!");
            }
           
        }
        static void MakeCourse(string[] contents, List<Course> mySchedule)
        {
            string subject = contents[0];
            string id = contents[1];
            string name = contents[2];
            string term = contents[3];
            string year = contents[4];
            string grade = contents[5];
            
            Course to_add = new Course(name, subject, id, year, term, grade);
            
            mySchedule.Add(to_add);

            
            
        }
        static void ExportToFile(List<Course> mySchedule)
        {
            string date = DateTime.Now.ToString("h_mm_ss");
            string filename = "courses_" + date + ".txt";
            Console.WriteLine(filename);
            StreamWriter file = new StreamWriter(filename);

            foreach (Course course in mySchedule)
            {
                
                file.Write(course.write_course());

            }
            file.Close();

        }
    }
}
