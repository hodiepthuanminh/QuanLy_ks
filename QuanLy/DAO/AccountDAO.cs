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
            

        }
    }
}
