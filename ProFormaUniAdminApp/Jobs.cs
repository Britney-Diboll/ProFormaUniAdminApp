using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFormaUniAdminApp
{
    class Jobs
    {
        public string ProfName { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public string CourseLevel { get; set; }
        public string CourseName { get; set; }
        public int Room { get; set; }
        public DateTime StartTime { get; set; }


        public Jobs(SqlDataReader reader)
        {
            ProfName = reader["ProfName"].ToString();
            Title = reader["Title"].ToString();
            Number = reader["Number"].ToString();
            CourseLevel = reader["CourseLevel"].ToString();
            CourseName = reader["CourseName"].ToString();
            Room = (int)reader["Room"];
            StartTime = (DateTime)reader["StartTime"];

        }
        public Jobs()
        {

        }

    }
}
