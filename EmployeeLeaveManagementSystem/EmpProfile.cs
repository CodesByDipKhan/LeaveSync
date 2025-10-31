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
    public partial class EmpProfile : Form
    {
        int uID = 0;
        public EmpProfile()
        {
            InitializeComponent();
        }
        public EmpProfile(int uID)
        {
            InitializeComponent();
            this.uID = uID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EmployeeDashboard obj = new EmployeeDashboard(uID);
            obj.Show();
            this.Close();
        }

        private void EmpProfile_Load(object sender, EventArgs e)
        {
            string query = "select EmpID,Username,[Password],[Name],Gender,Phone,Position,DOJ,Balance from Employee inner join UserInfo on UserInfo.UserID=Employee.EmpID  where UserID="+uID+"";
            var result = DataConnect.GetData(query);
            if(result == null)
            {
                MessageBox.Show("Something went wrong","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                return;
            }
            txtID.Text = result.Rows[0]["EmpID"].ToString();
            txtUsername.Text = result.Rows[0]["Username"].ToString();
            txtPass.Text = result.Rows[0]["Password"].ToString();
            txtName.Text = result.Rows[0]["Name"].ToString();
            txtGender.Text = result.Rows[0]["Gender"].ToString();
            txtPhone.Text = result.Rows[0]["Phone"].ToString();
            txtPosition.Text = result.Rows[0]["Position"].ToString();
            txtDOJ.Text = result.Rows[0]["DOJ"].ToString();
            txtBalance.Text = result.Rows[0]["Balance"].ToString();
        }
    }
}
