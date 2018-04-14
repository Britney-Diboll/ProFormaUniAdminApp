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
                    else if(firstInput == "2")
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
                        Console.WriteLine("There are no enrolled students at this time!");
                        Console.WriteLine("Would you like to go back to the main menu?");
                        var input = Console.ReadLine();
                        if(input == "no")
                        {
                            running = false;
                        }
                    }
                    else if( firstInput == "4")
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
            }

        }
    }
}
