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
    public partial class AdminDashboard : Form
    {
        int uID = 0;
        public AdminDashboard()
        {
            InitializeComponent();
        }
        public AdminDashboard(int id)
        {
            InitializeComponent();
            uID = id;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Quesition,", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login obj = new Login();
                this.Hide();
                obj.Show();
            }
        }

        private void btnAdminProfile_Click(object sender, EventArgs e)
        {
            AdminProfile obj = new AdminProfile(uID);
            this.Hide();
            obj.Show();
        }

        private void btnMngLeave_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeaveType obj = new LeaveType(uID);
            obj.Show();
        }

        private void btnMngUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserManagement obj = new UserManagement(uID);
            obj.Show();
        }

        private void btnMngEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpManage obj = new EmpManage(uID);
            obj.Show();
        }

        private void btnMngLeaveReq_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeaveReqManage obj = new LeaveReqManage(uID);
            obj.Show();
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            AdminHistory obj = new AdminHistory(uID);
            obj.Show();
            this.Hide();
        }
    }
}
