using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFormaUniAdminApp
{
    class Creator
    {

        public static Professors CreateProfessor()
        {
            Console.WriteLine("What is your title? (Ex: Dr. , Mr. , Mrs. etc.)");
            var professorTitle = Console.ReadLine();
            Console.WriteLine("What is your first and last name?");
            var professorFullName = Console.ReadLine();

            var newProfessor = new Professors
            {
                Title = professorTitle,
                Name = professorFullName,

            };
            return newProfessor;

        }

        public static void InsertProfessor(SqlConnection conn, Professors newProfessor)
        {
            var _insert = "INSERT INTO Professors (Title, Name) " + "VALUES (@Title, @Name)";
            var command = new SqlCommand(_insert, conn);

            command.Parameters.AddWithValue("Title", newProfessor.Title);
            command.Parameters.AddWithValue("Name", newProfessor.Name);
            command.ExecuteScalar();
        }



        public static Courses CreateCourse()
        {
            Console.WriteLine("What is the course number? Ex: 101, 201, 2101 etc.");
            var courseNumber = Console.ReadLine();
            Console.WriteLine("What is the course level? Ex: Easy, Hard etc.");
            var courseCourseLevel = Console.ReadLine();
            Console.WriteLine("What is the name of the course?");
            var courseName = Console.ReadLine();
            Console.WriteLine("What is the room number?");
            var courseRoom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("When does the course start? Ex: 2018-04-13 08:30:00");
            var courseStartTime = Convert.ToDateTime(Console.ReadLine());

            var newCourse = new Courses
            {

                Number = courseNumber,
                CourseLevel = courseCourseLevel,
                Name = courseName,
                Room = courseRoom,
                StartTime = courseStartTime,
            };
            return newCourse;

        }

        public static void InsertCourse(SqlConnection conn, Courses newCourse)
        {
            var _insert = "INSERT INTO Courses (Number, CourseLevel, Name, Room, StartTime) " + "VALUES (@Number, @CourseLevel, @Name, @Room, @StartTime)";
            var command = new SqlCommand(_insert, conn);

            command.Parameters.AddWithValue("Number", newCourse.Number);
            command.Parameters.AddWithValue("CourseLevel", newCourse.CourseLevel);
            command.Parameters.AddWithValue("Name", newCourse.Name);
            command.Parameters.AddWithValue("Room", newCourse.Room);
            command.Parameters.AddWithValue("StartTime", newCourse.StartTime);
            command.ExecuteScalar();
        }

        public static List<Jobs> GetProfessorsAndCourses(SqlConnection conn)
        {
            var _select = "SELECT [Professors].[Title] AS [Title], [Professors].[Name] AS [ProfName], " + 
                          "[Courses].[Name] AS [CourseName], [Courses].[Number] AS [Number], [Courses].[CourseLevel] AS [CourseLevel], [Courses].[Room] AS [Room], [Courses].[StartTime] AS [StartTime]" +
                          " FROM [Professors]" + 
                          " JOIN [Jobs] ON [Jobs].[ProfessorID] = [Professors].[ID]" + 
                          " JOIN [Courses] ON [Courses].[ID] = [Jobs].[CourseID]";
            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var result = new List<Jobs>();
            while (reader.Read())
            {
                var _job = new Jobs(reader);
                Console.WriteLine($"{_job.Title} {_job.ProfName} is teaching {_job.CourseName}");

            }
            reader.Close();
            return result;
        }
    }

}
