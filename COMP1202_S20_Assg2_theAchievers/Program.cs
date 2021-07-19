using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace COMP1202_S20_Assg2_theAchievers
{
    class Program
    {
        static void Main(string[] args)
        {

            double Gpa = 0;
            string IdGenerator = "", StudentID = "", FirstName = "", LastName = "", Major = "", Phone = "", Birthday = "";
            string input;
            Student output2;
            Student[] output = new Student[100];
            Student[] studentList = MethodClass.GetStudents();

            output[0] = new Student("10001", "10001", "Wynne", "Tran", "T127", "416-871-4141", 2.99, "August 1, 1998");


            output[1] = new Student("10002", "10002", "Thi Hoang Tram", "Tran", "H139", "416-871-2234", 3.4, "August 15, 1988");


            output[2] = new Student("10003", "10003", "Steve", "Job", "T127", "416-871-5232", 3.4, "June 1, 1978");


            output[3] = new Student("10004", "10004", "Bill", "Gate", "T131", "416-871-7662", 3.8, "July 13, 1955");


            output[4] = new Student("10005", "10005", "Albert", "Danison", "T133", "416-871-1101", 3.99, "December 1, 1978");

            // check if @"Student.txt" is empty, write new data
            // if @"Student.txt" has data, prevent overwriting the data
            string path = @"Student.txt";
            string path2 = @"Generator.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        MethodClass.WriteStudent(output[i]);
                    }
                }
                using (StreamWriter sw2 = File.CreateText(path2))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        MethodClass.WriteIDGenerator(output[i].IdGenerator);
                    }
                }
            }

            if (File.ReadAllLines(@"Student.txt").Length == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    MethodClass.WriteStudent(output[i]);
                    MethodClass.WriteIDGenerator(output[i].IdGenerator);
                }

            }
            else
            {
                MethodClass.CheckDuplicateFile(output, studentList);
            }



            // everytime the program runs, IDGenerator add 1 to the student ID number

            do
            {
                Console.Clear();
                WriteLine();

                ForegroundColor = ConsoleColor.Red;

                WriteLine("Press 1 : Enter new student's information");
                WriteLine("Press 2 : Sort by Name or GPA");
                WriteLine("Press 3 : Search StudentID, Major or GPA");
                WriteLine("Press 4 : Print IdGenerator.txt file");
                WriteLine("Press 5 : Print Student.txt file");
                WriteLine("Press 6 : To edit student's information");
                WriteLine("Press anything else to exit!");


                input = ReadLine();

                if (input == "1") // enter new student's information
                {
                    WriteLine();
                    Console.ResetColor();
                    WriteLine("Enter student's information: ");
                    for (int i = 0; i < output.Length; i++)
                    {
                        if (output[i] == null)
                        {
                            int newIdGenerator = 10005 + 1;
                            IdGenerator = newIdGenerator.ToString();
                            output[i] = new Student(IdGenerator, StudentID, FirstName, LastName, Major, Phone, Gpa, Birthday);
                            MethodClass.CheckDuplicateFile(output, studentList);

                            break;

                        }
                    }

                    do
                    {

                        StudentID = IdGenerator;
                        if (MethodClass.SearchByID(studentList, StudentID) == null)
                        {
                            WriteLine("Student ID: {0}", StudentID);
                        }
                        else
                        {
                            StudentID = (Int32.Parse(IdGenerator) + 1).ToString();
                            WriteLine("Student ID: {0}", StudentID);
                        }

                        Write("First Name: ");      // check for a valid name
                        do
                        {
                            input = ReadLine();
                            if (MethodClass.CheckInt(input) == false)
                            {
                                FirstName = input;

                            }

                            else
                            {
                                Write("Please enter a valid first name: ");
                            }
                            if (string.IsNullOrEmpty(input))
                            {
                                Write("Please enter the student's first name: ");

                            }
                        } while (MethodClass.CheckInt(input) == true || string.IsNullOrEmpty(input));



                        Write("Last Name: ");      // check for a valid last name
                        do
                        {
                            input = ReadLine();
                            if (MethodClass.CheckInt(input) == false)
                            {
                                LastName = input;

                            }

                            else
                            {
                                Write("Please enter a valid last name: ");
                            }
                            if (string.IsNullOrEmpty(input))
                            {
                                Write("Please enter the student's last name: ");
                            }
                        } while (MethodClass.CheckInt(input) == true || string.IsNullOrEmpty(input));

                        Write("Major: ");

                        do
                        {
                            Major = ReadLine();
                            if (string.IsNullOrEmpty(Major))
                            {
                                Write("Please enter the Major: ");
                            }
                        }
                        while (string.IsNullOrEmpty(Major));



                        Write("Phone: ");       // check if phone number has 10 digits
                        do
                        {
                            input = ReadLine();

                            if (MethodClass.CheckDouble(input) == true)
                            {
                                // check 10 digits of number and format xxx-xxx-xxxx
                                Phone = MethodClass.CheckLength(input, 10).Insert(6, "-").Insert(3, "-");

                            }
                            else
                            {
                                Write("Please enter the phone number: ");

                            }
                        } while (MethodClass.CheckDouble(input) == false);



                        Write("GPA: ");
                        do
                        {               // check if entered GPA is double
                            input = ReadLine();

                            if (MethodClass.CheckDouble(input) == false)
                            {
                                Write("Please enter the GPA: ");

                            }
                            // check GPA from 0 to 4
                            else if (Double.Parse(input) <= 0 || Double.Parse(input) > 4)
                            {
                                Write("Please enter a valid GPA: ");

                            }
                            else
                            {

                                Gpa = Double.Parse(input);
                            }

                        } while (Gpa <= 0.0);



                        Write("Please enter the Birthday (mm/dd/yyyy): ");
                        do
                        {
                            input = ReadLine();

                            if (MethodClass.CheckDate(input) == false)// check for a  valid Birthday date
                            {
                                Write("Please enter a valid birthday: ");
                            }
                            else
                            {
                                if (input.Length <= 3)
                                {
                                    // Check if user entered a valid birthday format including year.
                                    // entering 1/2 will not return January 2, 2020.
                                    do
                                    {
                                        Write("Please enter a valid birthday (mm/dd/yy): ");
                                        input = ReadLine();
                                    } while (input.Length <= 2);
                                }
                                DateTime check = DateTime.Parse(input);
                                Birthday = check.ToString("MMMM d, yyyy");
                            }
                        } while (MethodClass.CheckDate(input) == false);


                        for (int i = 0; i < 100; i++) // write new input into Student.txt and IdGenerator.txt
                        {
                            if (output[i] == null)
                            {
                                output[i] = new Student(IdGenerator, StudentID, FirstName, LastName, Major, Phone, Gpa, Birthday);
                                MethodClass.WriteStudent(output[i]);
                                MethodClass.WriteIDGenerator(output[i].IdGenerator);
                                break;
                            }


                        }

                        // loop to continue input new student information
                        WriteLine("------------------------------------");
                        WriteLine();
                        Write("New Student, press Y/y to continue!");
                        input = ReadLine();


                        // StudentID will automatically be increased by 1
                        if (input == "Y" || input == "y")
                        {
                            IdGenerator = (Int32.Parse(StudentID) + 1).ToString();
                        }
                    } while (input == "Y" || input == "y");
                }


                if (input == "2") // Press 2 : Sort by Name or GPA
                {
                    WriteLine("------------------------------------");
                    WriteLine();

                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Press 1 : Sort by First Name");
                    WriteLine("Press 2 : Sort by Last Name");
                    WriteLine("Press 3 : Sort by GPA");
                    WriteLine("Press anything else to go back to the main menu!");
                    input = ReadLine();


                    if (input == "1") //Press 1 : Sort by First Name
                    {
                        WriteLine();
                        Console.ResetColor();
                        BackgroundColor = ConsoleColor.Red;
                        WriteLine("Sort by First Name from A to Z: ");
                        Console.ResetColor();
                        MethodClass.SortListByFirstNameAZ(studentList);
                        MethodClass.PrintList(studentList);
                        WriteLine("------------------------------------");
                        WriteLine();

                        BackgroundColor = ConsoleColor.Red;
                        WriteLine("Sort by First Name from Z to A: ");
                        Console.ResetColor();
                        MethodClass.SortListByFirstNameZA(studentList);
                        MethodClass.PrintList(studentList);
                    }

                    else if (input == "2") //Press 2 : Sort by Last Name
                    {
                        WriteLine();
                        Console.ResetColor();
                        BackgroundColor = ConsoleColor.Red;
                        WriteLine("Sort by Last Name(Ascending Order): ");
                        Console.ResetColor();
                        MethodClass.SortListByLastNameAZ(studentList);
                        MethodClass.PrintList(studentList);
                        WriteLine("------------------------------------");


                        WriteLine();
                        BackgroundColor = ConsoleColor.Red;
                        WriteLine("Sort by Last Name(Descending Order): ");
                        Console.ResetColor();
                        MethodClass.SortListByLastNameZA(studentList);
                        MethodClass.PrintList(studentList);
                    }


                    else if (input == "3")//Press 3 : Sort by GPA
                    {
                        WriteLine();
                        Console.ResetColor();
                        BackgroundColor = ConsoleColor.Red;
                        WriteLine("Sort by descending GPA: ");
                        Console.ResetColor();
                        MethodClass.SortArrayGPAASC(studentList);
                        MethodClass.PrintList(studentList);
                        WriteLine("------------------------------------");


                        WriteLine();
                        BackgroundColor = ConsoleColor.Red;
                        WriteLine("Sort by ascending GPA:");
                        Console.ResetColor();
                        MethodClass.SortArrayGPADSC(studentList);
                        MethodClass.PrintList(studentList);
                    }


                    else //Press anything else to go back to the main menu
                    {
                        continue;
                    }

                }
                else if (input == "3") //Search for StudentID, Major or GPA
                {
                    WriteLine("------------------------------------");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Press 1 : Search for StudentID");
                    WriteLine("Press 2 : Search for Major");
                    WriteLine("Press 3 : Search for GPA");
                    WriteLine("Press anything else to go back to the main menu!");
                    Console.ResetColor();
                    input = ReadLine();


                    if (input == "1") //Press 1 : Search StudentID
                    {
                        WriteLine();
                        WriteLine("Enter the StudentID: ");
                        input = ReadLine();
                        while (MethodClass.CheckInt(input) == false)
                        {
                            Write("Please enter a valid StudentID: ");
                            input = ReadLine();
                        }

                        if (Int32.Parse(input) < 10000)
                        {
                            input = (Int32.Parse(input) + 10000).ToString();
                            WriteLine();
                            
                        }
                        ForegroundColor = ConsoleColor.Cyan;
                        output2 = MethodClass.SearchByID(studentList, input);
                        if (output2 != null)
                        {
                            WriteLine(output2);
                        }
                        else
                        {
                            WriteLine("Student ID not found.");
                        }

                    }
                    else if (input == "2") //Press 2 : Search Major
                    {
                        WriteLine();
                        WriteLine("Enter the Major: ");
                        input = ReadLine();

                        WriteLine();
                        ForegroundColor = ConsoleColor.Cyan;

                        if (MethodClass.SearchByMajor(studentList, input) != null)
                        {
                            MethodClass.PrintList(MethodClass.SearchByMajor(studentList, input));

                        }
                        else
                        {
                            WriteLine("Major not found.");
                        }

                    }


                    else if (input == "3") //Press 3 : Search GPA
                    {
                        WriteLine();
                        WriteLine("Enter GPA: ");


                        do
                        {               // check if entered GPA is double
                            input = ReadLine();

                            if (MethodClass.CheckDouble(input) == false)
                            {
                                Write("Please enter the GPA: ");

                            }
                            // check GPA from 0 to 4
                            else if (Double.Parse(input) <= 0 || Double.Parse(input) > 4)
                            {
                                Write("Please enter a valid GPA: ");

                            }
                            else
                            {

                                Gpa = Double.Parse(input);
                            }

                        } while (Gpa <= 0.0);
                        WriteLine();
                        
                        WriteLine("Students have GPA higher than {0:f1}", Double.Parse(input));

                        Console.ResetColor();
                        Student[] output3 = MethodClass.SearchLargerGPA(studentList, Double.Parse(input));
                        if (output3 != null)
                        {
                            MethodClass.PrintList(output3);
                        }
                        else
                        {
                            WriteLine("No student has higher GPA than " + input);
                        }
                        MethodClass.PrintList(output3);
                        WriteLine("------------------------------------");

                        WriteLine();
                        
                        WriteLine("Students have GPA lower than {0:f1}", Double.Parse(input));
                        Console.ResetColor();
                        output3 = MethodClass.SearchLowerGPA(studentList, Double.Parse(input));
                        if (output3 != null)
                        {
                            MethodClass.PrintList(output3);
                        }
                        else
                        {
                            WriteLine("No student has less GPA than " + input);
                        }


                    }
                    else // Press anything else to go back to the control panel!
                    {
                        continue;
                    }
                }


                else if (input == "4") //Press 3 : Print IdGenerator.txt file"
                {
                    Console.ResetColor();
                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;

                    WriteLine(File.ReadAllText(@"Generator.txt"));

                }


                else if (input == "5") //Press 5 : Print Student.txt file"
                {
                    Console.ResetColor();
                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("All Students Information: ");
                    MethodClass.CheckDuplicateFile(output, studentList);
                    MethodClass.PrintList(MethodClass.GetStudents());
                }

                else if (input == "6") //Press 6: edit student's information
                {
                    Console.ResetColor();
                    WriteLine(" Please enter the Student ID to edit the profile: ");
                    input = ReadLine();
                    while (MethodClass.CheckInt(input) == false)
                    {
                        Write("Please enter a valid StudentID: ");
                        input = ReadLine();
                    }

                    if (Int32.Parse(input) < 10000)
                    {
                        input = (Int32.Parse(input) + 10000).ToString();
                    }
                    WriteLine();
                    ForegroundColor = ConsoleColor.Cyan;
                    output2 = MethodClass.SearchByID(studentList, input);
                    if (output2 != null)
                    {
                        do
                        {
                            WriteLine("Would you like to edit the student profile? Press Y/y to continue.");
                            input = ReadLine();
                            if (input == "Y" || input == "y")
                            {
                                StudentID = output2.StudentID;
                                WriteLine("StudentID: {0}", StudentID);
                                Write("First Name: ");
                                do
                                {
                                    input = ReadLine();
                                    if (MethodClass.CheckInt(input) == false)
                                    {
                                        FirstName = input;

                                    }

                                    else
                                    {
                                        Write("Please enter a valid First Name: ");
                                    }
                                    if (string.IsNullOrEmpty(input))
                                    {
                                        Write("Please enter the student's First Name: ");

                                    }
                                } while (MethodClass.CheckInt(input) == true || string.IsNullOrEmpty(input));



                                Write("Last Name: ");
                                do
                                {
                                    input = ReadLine();
                                    if (MethodClass.CheckInt(input) == false)
                                    {
                                        LastName = input;

                                    }

                                    else
                                    {
                                        Write("Please enter a valid Last Name: ");
                                    }
                                    if (string.IsNullOrEmpty(input))
                                    {
                                        Write("Please enter the Last Name: ");
                                    }
                                } while (MethodClass.CheckInt(input) == true || string.IsNullOrEmpty(input));

                                Write("Major: ");

                                do
                                {
                                    Major = ReadLine();
                                    if (string.IsNullOrEmpty(Major))
                                    {
                                        Write("Please enter the Major: ");
                                    }
                                }
                                while (string.IsNullOrEmpty(Major));



                                Write("Phone Number: ");
                                do
                                {
                                    input = ReadLine();
                                    if (MethodClass.CheckDouble(input) == true)
                                    {

                                        Phone = MethodClass.CheckLength(input, 10).Insert(6, "-").Insert(3, "-");

                                    }
                                    else
                                    {
                                        Write("Please enter a Phone Number: ");

                                    }
                                } while (MethodClass.CheckDouble(input) == false);



                                Write("GPA: ");
                                do
                                {
                                    input = ReadLine();

                                    if (MethodClass.CheckDouble(input) == false)
                                    {
                                        Write("Please enter the GPA: ");

                                    }

                                    else if (Double.Parse(input) <= 0 || Double.Parse(input) > 4)
                                    {
                                        Write("Please enter a valid GPA: ");

                                    }
                                    else
                                    {

                                        Gpa = Double.Parse(input);
                                    }

                                } while (Gpa <= 0.0);



                                Write("Birthday (mm/dd/yyyy): ");
                                do
                                {
                                    input = ReadLine();

                                    if (MethodClass.CheckDate(input) == false)
                                    {
                                        Write("Please enter the Date of Birth (mm/dd/yyyy): ");
                                    }
                                    else
                                    {
                                        if (input.Length <= 3)
                                        {
                                            do
                                            {
                                                Write("Please enter a valid Date of Birth (mm/dd/yy): ");
                                                input = ReadLine();
                                            } while (input.Length <= 2);
                                        }
                                        DateTime check = DateTime.Parse(input);
                                        Birthday = check.ToString("MMMM d, yyyy");
                                    }
                                } while (MethodClass.CheckDate(input) == false);


                                for (int i = 0; i < 100; i++)
                                {
                                    if (output[i] == null)
                                    {
                                        output[i] = new Student(IdGenerator, StudentID, FirstName, LastName, Major, Phone, Gpa, Birthday);
                                        MethodClass.LineChanger(output[i], output[i].StudentID);

                                        break;

                                    }

                                }
                            }


                        } while (input == "Y" || input == "y");
                    }

                    else
                    {
                        WriteLine("StudentID not found");
                    }
                }

                WriteLine();
                Console.ResetColor();
                WriteLine("To go back to the main menu, press Y/y");
                WriteLine("Press anything else to exit the program.");
                MethodClass.CheckDuplicateFile(output, studentList);
                studentList = MethodClass.GetStudents();
                input = ReadLine();
                if (input == "Y" || input == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            while (input != "Y" || input != "y");


            ReadLine();
        }
    }
}
