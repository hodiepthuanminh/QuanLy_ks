﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLy.DTO;
using QuanLy.DAO;

namespace QuanLy.BLL
{
    public class AccountBLL
    {
        AccountDAO dao = new AccountDAO();
        public List<AccountDTO> ReadAcount()
        {
            List<AccountDTO> lstAC = dao.ReadAccount();
            return lstAC;
        }
    }
}
