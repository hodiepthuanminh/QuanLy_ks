﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLy.DAO
{
    public class DBConnection
    {
        public DBConnection() { }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-1H5HC0P\SQLEXPRESS;Initial Catalog=QuanLy;User ID=sa; Password=diep123456789@";
            return conn;
        }
    }
}
