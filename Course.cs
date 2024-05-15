using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

// Namespace - How to organize Classes
namespace College 
{   

    public class Schedule
    {
        static private List<Term> terms = new List<Term>();
        public void AddTerm(Term newTerm)
        {
            terms.Add(newTerm);
        }
    }


    public class Term
    {
        public string termName { get; set; }
        private List<Course> courses;

        public Term(string newTermName, Course newCourse)
        {
            termName = newTermName;
            courses = new List<Course>
            {
                newCourse
            };
        }
        public void AddClassToTerm(Course newCourse)
        {
            courses.Add(newCourse);
        }
    }
    public class Course
    {
        private string name;
        private string subject;
        private string courseShort;
        private int id;
        private string termTaken;
        private string grade;
        private double gpa;

        // Constructor
        public Course(string newname, string newsubject, string newid, string newtermTaken, string newgrade)
        {
            name = newname;
            subject = newsubject;
            courseShort = newsubject + " " + newid;
            id = Convert.ToInt32(newid);
            termTaken = newtermTaken;
            grade = newgrade;

            switch (newgrade) 
            {
                case "A+":
                    gpa = 4.0;
                    break;
                case "A":
                    gpa = 4.0;
                    break;
                case "A-":
                    gpa = 3.7;
                    break;
                case "B+":
                    gpa = 3.3;
                    break;
                case "B":
                    gpa = 3.0;
                    break;
                case "B-":
                    gpa = 2.7;
                    break;
                case "C+":
                    gpa = 2.3;
                    break;
                case "C":
                    gpa = 2.0;
                    break;
                case "C-":
                    gpa = 1.7;
                    break;
                case "D+":
                    gpa = 1.3;
                    break;
                case "D-":
                    gpa = 1.0;
                    break;
                case "D":
                    gpa = 0.0;
                    break;
                case "F":
                    gpa = 3.5;
                    break;

            }
        }

        // Getters
        public void print_course()
        {
            Console.WriteLine("********************************");
            Console.WriteLine(courseShort + ": " + name);
            Console.WriteLine(termTaken);
            Console.WriteLine("Grade Received: " + grade);
        }

        public string get_name()
        {
            return name;
        } 
    
    }   

}