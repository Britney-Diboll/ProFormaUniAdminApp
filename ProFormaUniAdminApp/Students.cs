using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFormaUniAdminApp
{
    class Students
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }

        public Students()
        {

        }

        public Students(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            FullName = reader["FullName"].ToString();
            Email = reader["Email"].ToString();
            PhoneNumber = reader["PhoneNumber"].ToString();
            Major = reader["Major"].ToString();
        }

    }
}
