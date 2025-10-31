using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeLeaveManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pass = txtPass.Text;

            string query = "select * from UserInfo where Username='"+name+"' and [Password] = '"+pass+"'";
            DataTable result = DataConnect.GetData(query);
            if(result == null)
            {
                MessageBox.Show("Something went wrong.");
                return;
            }

            if(result.Rows.Count !=1)
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int uID = Convert.ToInt32(result.Rows[0]["UserID"]);
            string uName = result.Rows[0]["Username"].ToString();
            string uPass = result.Rows[0]["Password"].ToString();
            string utype = result.Rows[0]["Role"].ToString();
            if (utype == "admin")
            {
                AdminDashboard obj = new AdminDashboard(uID);
                this.Hide();
                obj.Show();
            }
            else if(utype == "employee")
            {
                EmployeeDashboard obj = new EmployeeDashboard(uID);
                this.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid user type","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        private void picboxExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPass.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '#';
            }
        }

        private void btnDevInfo_Click(object sender, EventArgs e)
        {
            DevInfoForm obj = new DevInfoForm();
            obj.Show();
            this.Hide();
        }
    }
}
