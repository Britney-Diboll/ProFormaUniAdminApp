using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFormaUniAdminApp
{
    class Enroll
    {
        public string Number { get; set; }
        public string CourseLevel { get; set; }
        public string CourseName { get; set; }
        public int Room { get; set; }
        public DateTime StartTime { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }


        public Enroll(SqlDataReader reader)
        {
            Number = reader["Number"].ToString();
            CourseLevel = reader["CourseLevel"].ToString();
            CourseName = reader["CourseName"].ToString();
            Room = (int)reader["Room"];
            StartTime = (DateTime)reader["StartTime"];
            FullName = reader["FullName"].ToString();
            Email = reader["Email"].ToString();
            PhoneNumber = reader["PhoneNumber"].ToString();
            Major = reader["Major"].ToString();
           

        }
        public Enroll()
        {

        }

    }
}
