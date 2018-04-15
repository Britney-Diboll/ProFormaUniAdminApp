using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFormaUniAdminApp
{
    class Program
    {

        static void Main(string[] args)
        {
            const string CONNECTION_STRING = @"Server=BDIBOLL01\SQLEXPRESS;Database=ProFormaUni;Trusted_Connection=True;";

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                var running = true;
                while (running == true)
                {
                    Console.WriteLine("Welcome to ProForma University, Professors!");
                    Console.WriteLine("Please choose one of the following options.\n");
                    Console.WriteLine(" 1. Admin\n 2. Student");
                    var Ainput = Console.ReadLine();
                    if (Ainput == "1")
                    {
                        Console.WriteLine("Please choose one of the following options.\n");
                        Console.WriteLine(" 1. Add a new Professor\n 2. Add Course\n 3. View students enrolled in a course\n 4. View all courses, Professor teaching the course and students enrolled");

                        var firstInput = Console.ReadLine();
                        if (firstInput == "1")
                        {
                            //Adding a professor
                            var newProfessor = Creator.CreateProfessor();
                            Creator.InsertProfessor(conn, newProfessor);
                            Console.WriteLine($"You have successfully added {newProfessor.Title} {newProfessor.Name}");
                            Console.WriteLine("Would you like to add another Professor? Type yes or no");
                            var input = Console.ReadLine();
                            if (input == "no")
                            {
                                running = false;

                            }
                        }
                        else if (firstInput == "2")
                        {
                            // Adding Course
                            var newCourse = Creator.CreateCourse();
                            Creator.InsertCourse(conn, newCourse);
                            Console.WriteLine($"You have successfully added a new course. {newCourse.Name} starts {newCourse.StartTime} and will be held in room {newCourse.Room}");
                            Console.WriteLine("Would you like to add another course?");
                            var input = Console.ReadLine();
                            if (input == "no")
                            {
                                running = false;
                            }
                        }
                        else if (firstInput == "3")
                        {
                            // Showing enrolled students
                            Creator.GetStudentAndCourse(conn);
                            Console.WriteLine();
                            Console.WriteLine("Would you like to go to the main menu?");
                            var input = Console.ReadLine();
                            if (input == "no")
                            {
                                running = false;
                            }
                        }
                        else if (firstInput == "4")
                        {
                            //Shows who is teaching what 
                            Creator.GetProfessorsAndCourses(conn);
                            Console.WriteLine("Would you like to go back to the main menu?");
                            var input = Console.ReadLine();
                            if (input == "no")
                            {
                                running = false;
                            }
                        }
                    }
                    else if (Ainput == "2")
                    {
                        Console.WriteLine("Please choose one of the following options.\n");
                        Console.WriteLine(" 1. New student enrollment.\n 2. Already enrolled student (shows all students enrolled in courses)");
                        var inputone = Console.ReadLine();
                        if (inputone == "1")
                        {

                            var newStudent = Creator.CreateStudent();
                            Creator.InsertStudent(conn, newStudent);
                            Console.WriteLine("You have successfully enrolled as a student in Proforma University.\n Please choose one of the following courses to enroll in.");
                            Console.WriteLine(" 1. Intro to Star Wars\n 2. How to assert dominance over your cat\n 3. The Deep Bluie\n 4. The Continuing Saga of Star Wars\n\n Select a number");

                            var inputtwo = Console.ReadLine();
                            var student = Creator.GetLastStudent(conn);
                            var newEnroll = new Enroll
                            {
                                StudentID = student.ID,
                                CourseID = Int32.Parse(inputtwo)
                            };
                            Creator.InsertEnroll(conn, newEnroll);
                            Console.WriteLine("Would you to go back to the main menu? Type yes or no.");
                            var input = Console.ReadLine();
                            if (input == "no")
                            {
                                running = false;
                            }
                        }
                        if (inputone == "2")
                        {
                            Creator.GetStudentAndCourse(conn);
                            Console.WriteLine();
                            Console.WriteLine("Would you like to go to the main menu? Type yes or no.");
                            var input = Console.ReadLine();
                            if(input == "no")
                            {
                                running = false;
                            }

                        }
                    }
                }
            }
        }

    }
}
