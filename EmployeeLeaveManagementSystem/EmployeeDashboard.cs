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
    public partial class EmployeeDashboard : Form
    {
        int id = 0;
        public EmployeeDashboard()
        {
            InitializeComponent();
        }
        public EmployeeDashboard(int uID)
        {
            InitializeComponent();
            id= uID;
        }

        private void btnEmpProfile_Click(object sender, EventArgs e)
        {
            EmpProfile obj = new EmpProfile(id);
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login obj = new Login();
                this.Hide();
                obj.Show();
            }
            else
            {
                return;
            }
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            LeaveApply obj = new LeaveApply(id);
            obj.Show();
            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            EmpHistory obj = new EmpHistory(id);
            obj.Show();
            this.Hide();
        }
    }
}
