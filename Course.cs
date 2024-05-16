using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

// Namespace - How to organize Classes
namespace College 
{   
    public class Course
    {
        public string name { get; private set; }
        public string subject { get; private set; }
        public string courseShort { get; private set; }
        private int id;
        private string term;

        private int year;
        private string grade;
        public double gpa {get; private set;}

        // Constructor
        public Course(string newname, string newsubject, string newid, string newyear, string newterm, string newgrade)
        {
            name = newname;
            subject = newsubject;
            courseShort = newsubject + " " + newid;
            id = Convert.ToInt32(newid);
            term = newterm;
            year = Convert.ToInt32(newyear);
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

        public int get_year()
        {
            return year;
        }
        public int orderbyterm()
        {
            switch (term)
            {
                case "Winter": return 1;
                case "Spring": return 2;
                case "Summer": return 3;
                case "Fall": return 4;
                default: return 0;
            }
        }
        
        public string print_course()
        {
           return courseShort + ": " + name + ": " + term + " " + year + "  " + grade;
        }

        public string write_course()
        {
            return subject + "," + Convert.ToString(id) + "," + name + "," + term + ',' + year + ',' + grade + ',' + gpa + "\n";
        }
    }   

}