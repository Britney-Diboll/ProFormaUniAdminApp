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
        ///private static Professors newProfessor() { }

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
    }

}
