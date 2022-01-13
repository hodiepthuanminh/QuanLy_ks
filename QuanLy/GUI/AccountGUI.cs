using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLy.DTO;
using QuanLy.BLL;

namespace QuanLy.GUI
{
    public partial class AccountGUI : Form
    {
        AccountBLL acBLL = new AccountBLL();
        public AccountGUI()
        {
            InitializeComponent();
        }
        int index;
        private void dtgv_Account_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            txt_UserName.Text = dtgv_Account.Rows[index].Cells[0].Value.ToString();
            txt_DisplayName.Text = dtgv_Account.Rows[index].Cells[1].Value.ToString();
            txt_PassWord.Text = dtgv_Account.Rows[index].Cells[2].Value.ToString();
            cb_Type.Text = dtgv_Account.Rows[index].Cells[3].Value.ToString();
        }

        private void AccountGUI_Load(object sender, EventArgs e)
        {
            List<AccountDTO> lisAC = acBLL.ReadAcount();
            foreach (AccountDTO ac in lisAC)
            {
                dtgv_Account.Rows.Add(ac.username, ac.displayname, ac.password, ac.type);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AccountDTO ac = new AccountDTO();
            ac.username = txt_UserName.Text;
            ac.displayname = txt_DisplayName.Text;
            ac.password = txt_PassWord.Text;
            ac.type = cb_Type.Text;
            acBLL.Add_Account(ac);
            dtgv_Account.Rows.Add(ac.username, ac.displayname, ac.password, ac.type);
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            AccountDTO ac = new AccountDTO();
            ac.username = txt_UserName.Text;
            ac.displayname = txt_DisplayName.Text;
            ac.password = txt_PassWord.Text;
            ac.type = cb_Type.Text;
            acBLL.Delete_Account(ac);
            dtgv_Account.Rows.RemoveAt(index);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (index>0)
            {
                AccountDTO ac = new AccountDTO();
                ac.username = txt_UserName.Text;
                ac.displayname = txt_DisplayName.Text;
                ac.password = txt_PassWord.Text;
                ac.type = cb_Type.Text;
                acBLL.Edit_Account(ac);
                dtgv_Account.Rows[index].Cells[0].Value = ac.username;
                dtgv_Account.Rows[index].Cells[1].Value = ac.displayname;
                dtgv_Account.Rows[index].Cells[2].Value = ac.password;
                dtgv_Account.Rows[index].Cells[3].Value = ac.type;
            }
        }
    }
}
