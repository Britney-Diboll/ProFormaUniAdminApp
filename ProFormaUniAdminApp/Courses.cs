using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFormaUniAdminApp
{
    class Courses
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public int Room { get; set; }
        public DateTime StartTime { get; set; }

        public Courses()
        {

        }

       /* public Courses(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            Number = reader["Name"].ToString();
            Level = reader["CourseLevel"].ToString();
            Name = reader["Name"].ToString();
            Room = (int)reader["Room"];
            StartTime = (DateTime)reader["StartTime"];

        } */
    }
}
