using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Text.RegularExpressions;

namespace COMP1202_S20_Assg2_theAchievers
{
    class MethodClass
    {
        //Question 1: This function checks the student's information input format
        public static bool CheckDate(string date)  // checking the birthday format
        {
            try
            {
                DateTime check = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool CheckInt(string num)//checking whether the user input is an integer or not
        {
            try
            {
                int checkint = Int32.Parse(num);

                return true;
            }
            catch
            {
                return false;
            }

        }


        public static bool CheckDouble(string num)//checking whether user input is double or not 
        {
            try
            {
                double checkdou = Double.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static string CheckLength(string input, int num)// checking the length of the phone string 
        {
            int count = 0;
            do
            {

                for (int i = 0; i < input.Length; i++)
                {
                    count++;
                }
                if (count != num)
                {
                    Write("Please enter {0} digits: ", num);
                    input = ReadLine();
                    count = 0;
                }
                else
                {
                    break;
                }
            } while (count != num);
            return (input);
        }


        // Question 3: This function prints the students' information

        public static void PrintList(Student[] students)
        {

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    if (students[i].IdGenerator == "")
                    {
                        break;
                    }
                }

            }
            foreach (Student student in students)
            {

                if (student == null)
                {
                    break;
                }
                Write(student);

            }
        }






        // Question 4: Sorting by LastName, FirstName, or GPA
        //sorting by first name A-Z
        public static void SortListByFirstNameAZ(Student[] output)
        {
            Student temp;
            for (int i = 0; i < output.Length - 1; i++)
            {
                for (int j = i + 1; j < output.Length; j++)
                {
                    if (output[j] != null)
                    {
                        if (output[i].FirstName.CompareTo(output[j].FirstName) > 0)
                        {
                            temp = output[i];
                            output[i] = output[j];
                            output[j] = temp;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }


        //sorting by first name Z-A
        public static void SortListByFirstNameZA(Student[] output)
        {
            Student temp;
            for (int i = 0; i < output.Length - 1; i++)
            {
                for (int j = i + 1; j < output.Length; j++)
                {
                    if (output[j] != null)
                    {
                        if (output[i].FirstName.CompareTo(output[j].FirstName) < 0)
                        {
                            temp = output[i];
                            output[i] = output[j];
                            output[j] = temp;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }

        //sorting by last name A-Z
        public static void SortListByLastNameAZ(Student[] output)
        {
            Student temp;
            for (int i = 0; i < output.Length - 1; i++)
            {
                for (int j = i + 1; j < output.Length; j++)
                {
                    if (output[j] != null)
                    {
                        if (output[i].LastName.CompareTo(output[j].LastName) > 0)
                        {
                            temp = output[i];
                            output[i] = output[j];
                            output[j] = temp;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }


        //sorting by Last name Z-A
        public static void SortListByLastNameZA(Student[] output)
        {
            Student temp;
            for (int i = 0; i < output.Length - 1; i++)
            {
                for (int j = i + 1; j < output.Length; j++)
                {
                    if (output[j] != null)
                    {
                        if (output[i].LastName.CompareTo(output[j].LastName) < 0)
                        {
                            temp = output[i];
                            output[i] = output[j];
                            output[j] = temp;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }


        //sorting by Gpa, ascending order
        public static void SortArrayGPAASC(Student[] students)
        {
            Student temp;
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (students[j] != null)
                    {
                        if (students[i].Gpa < students[j].Gpa)
                        {
                            temp = students[i];
                            students[i] = students[j];
                            students[j] = temp;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        //sorting by Gpa, descending order
        public static void SortArrayGPADSC(Student[] students)
        {
            Student temp;
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (students[j] != null)
                    {
                        if (students[i].Gpa > students[j].Gpa)
                        {
                            temp = students[i];
                            students[i] = students[j];
                            students[j] = temp;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }


        //Question 5: Search by StudentID, Major, GPA (returns a list of student with higer or lower than the entered Gpa)

        public static Student SearchByID(Student[] students, string input)
        {
            bool found = false;
            int index = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] == null)
                {
                    break;
                }
                else if (students[i].StudentID.Equals(input))
                {
                    found = true;
                    index = i;
                }

            }
            if (found == true)
            {
                return students[index];
            }
            else
            {
                return null;
            }

        }


        //searching by major
        public static Student[] SearchByMajor(Student[] students, string input)
        {
            Student[] foundList = new Student[students.Length];
            int foundIndex = -1;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    if (students[i].Major.Equals(input))
                    {
                        ++foundIndex;
                        foundList[foundIndex] = students[i];
                    }

                }
                else
                {
                    break;
                }

            }
            if (foundIndex != -1)
            {
                return foundList;
            }
            else
            {
                return null;
            }

        }


        //searching by Gpa(returns a list of students who have a Gpa equal to or greater than the one that is entered)
        public static Student[] SearchLargerGPA(Student[] students, double input)
        {
            Student[] foundList = new Student[students.Length];
            int foundIndex = -1;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    if (students[i].Gpa >= input)
                    {
                        ++foundIndex;
                        foundList[foundIndex] = students[i];
                    }
                }
                else
                {
                    break;
                }

            }
            if (foundIndex != -1)
            {
                return foundList;
            }
            else
            {
                return null;
            }


        }


        //searching by Gpa(returns a list of students who have a Gpa equal to or less than the one that is entered)
        public static Student[] SearchLowerGPA(Student[] students, double input)
        {
            Student[] foundList = new Student[students.Length];
            int foundIndex = -1;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    if (students[i].Gpa < input)
                    {
                        ++foundIndex;
                        foundList[foundIndex] = students[i];
                    }
                }
                else
                {
                    break;
                }

            }
            if (foundIndex != -1) { return foundList; } else { return null; }
        }


        //Question 6: Write data to a text file

        public static void WriteStudent(Student s) // write to the file Student.txt
        {

            StreamWriter fileOutput;

            String studentData = s.StudentID + ":" + s.FirstName + ":" + s.LastName + ":" + s.Major + ":" + s.Phone + ":" + s.Gpa + ":" + s.Birthday;

            try
            {
                using (fileOutput = new StreamWriter(@"Student.txt", true))
                {
                    fileOutput.WriteLine(studentData);

                }

            }
            catch (IOException exc)
            {
                WriteLine("Cannot write to file\n " + exc.Message);
            }

        }

        public static void WriteIDGenerator(string IdGenerator) // Write to the file IdGenerator.txt
        {

            StreamWriter fileOutput;


            try
            {
                using (fileOutput = new StreamWriter(@"Generator.txt", true))
                {
                    fileOutput.WriteLine(IdGenerator);

                }

            }
            catch (IOException exc)
            {
                WriteLine("Cannot write to file\n " + exc.Message);
            }

        }

        // checking for duplicates, if a StudentID already exists in Student.txt file, it will not write it again
        public static void CheckDuplicateFile(Student[] output, Student[] studentList)
        {

            studentList = MethodClass.GetStudents();

            for (int i = 0; i < output.Length; i++)
            {
                
                if (studentList[i] == null)
                {
                    MethodClass.WriteStudent(output[i]);
                    MethodClass.WriteIDGenerator(output[i].IdGenerator);
                    break;
                }
                else if (MethodClass.SearchByID(studentList, output[i].StudentID) == null)
                {
                    MethodClass.WriteStudent(output[i]);
                    MethodClass.WriteIDGenerator(output[i].IdGenerator);
                }
                else
                {
                    break;
                }

            }
        }


        public static Student[] GetStudents() // reading students' information from Student.txt
        {
            Student[] studentList;
            int studentCount = 0;
            StreamReader fileInput;
            String studentData;
            String[] studentDataArray = new string[7];
            if (File.Exists(@"Student.txt"))
            {
                try
                {
                    using (fileInput = new StreamReader(@"Student.txt"))
                    {
                        while ((studentData = fileInput.ReadLine()) != null)
                        {
                            ++studentCount;
                        }
                    }
                    studentList = new Student[studentCount];

                    using (fileInput = new StreamReader(@"Student.txt"))
                    {
                        for (int i = 0; i < studentCount; i++)
                        {
                            studentData = fileInput.ReadLine();
                            studentList[i] = new Student();

                            studentDataArray = studentData.Split(':');
                            studentList[i].StudentID = studentDataArray[0];
                            studentList[i].FirstName = studentDataArray[1];
                            studentList[i].LastName = studentDataArray[2];
                            studentList[i].Major = studentDataArray[3];
                            studentList[i].Phone = studentDataArray[4];
                            studentList[i].Gpa = Convert.ToDouble(studentDataArray[5]);
                            studentList[i].Birthday = studentDataArray[6];

                        }
                    }
                    return studentList;

                }
                catch (IOException exc)
                {
                    WriteLine("Cannot write to file\n " + exc.Message);
                    return null;
                }
            }
            else
            {

                return null;
            }
        }

        // Question 6: Edit infotmation and writing to Student.txt

        public static void LineChanger(Student s, string line_to_edit)
        {
            String outputData = s.StudentID + ":" + s.FirstName + ":" + s.LastName + ":" + s.Major + ":" + s.Phone + ":" + s.Gpa + ":" + s.Birthday;
            string[] arrLine = File.ReadAllLines(@"Student.txt");
            arrLine[Int32.Parse(line_to_edit) - 10001] = outputData;
            File.WriteAllLines(@"Student.txt", arrLine);
        }

    }

}
