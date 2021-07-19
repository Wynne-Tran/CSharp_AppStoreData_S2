using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace COMP1202_S20_Assg2_theAchievers
{
    class Student
    {

        private String idGenerator;
        private String studentID;
        private String firstName;
        private String lastName;
        private String major;
        private String phone;
        private double gpa;
        private String birthday;

        public String IdGenerator { get; set; }
        public String StudentID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Major { get; set; }
        public String Phone { get; set; }
        public double Gpa { get; set; }
        public String Birthday { get; set; }



        public Student()
        {

        }

        public Student(String SID, String FName, String LName, String Maj, String Fone, double GPA, String Birth)
        {

            StudentID = SID;
            FirstName = FName;
            LastName = LName;
            Major = Maj;
            Phone = Fone;
            Gpa = GPA;
            Birthday = Birth;

        }
        public Student(String GID, String SID, String FName, String LName, String Maj, String Fone, double GPA, String Birth)
        {
            IdGenerator = GID;
            StudentID = SID;
            FirstName = FName;
            LastName = LName;
            Major = Maj;
            Phone = Fone;
            Gpa = GPA;
            Birthday = Birth;

        }

        public override string ToString()
        {
            //converts the data obtained into the readable format user will see;

            String data = StudentID + "\n";
            data += FirstName + "\n";
            data += LastName + "\n";
            data += Major + "\n";
            data += Phone + "\n";
            data += Gpa + "\n";
            data += Birthday + "\n";
            WriteLine("------------------------------------");

            return data;

        }
    }
}
