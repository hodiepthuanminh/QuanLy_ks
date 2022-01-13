using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLy.DTO;

namespace QuanLy.DAO
{
    public class AccountDAO:DBConnection
    {
        public List<AccountDTO> ReadAccount()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Get_Account", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<AccountDTO> lstAC = new List<AccountDTO>();
            while (reader.Read())
            {
                AccountDTO ac = new AccountDTO();
                ac.username = reader["username"].ToString();
                ac.displayname = reader["displayname"].ToString();
                ac.password = reader["password"].ToString();
                ac.type = reader["type"].ToString();
                lstAC.Add(ac);
            }
            conn.Close();
            return lstAC;
        }
        public void Add_Account(AccountDTO ac)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Add_Account",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter(" @username", ac.username));
            cmd.Parameters.Add(new SqlParameter(" @displayname", ac.displayname));
            cmd.Parameters.Add(new SqlParameter(" @password", ac.password));
            cmd.Parameters.Add(new SqlParameter(" @type", ac.type));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete_Account(AccountDTO ac)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete_Account", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.Char).Value = ac.username;           
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Edit_Account(AccountDTO ac)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Edit_Account", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.Char).Value = ac.username;
            cmd.Parameters.Add("@displayname", System.Data.SqlDbType.NVarChar).Value = ac.displayname;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.Char).Value = ac.password;
            cmd.Parameters.Add("@type", System.Data.SqlDbType.VarChar).Value = ac.type;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
