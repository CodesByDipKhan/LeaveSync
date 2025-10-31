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
    public partial class EmpHistory : Form
    {
        int uID = 0;
        public EmpHistory()
        {
            InitializeComponent();
        }
        public EmpHistory(int id)
        {
            InitializeComponent();
            uID = id;
        }

        private void EmpHistory_Load(object sender, EventArgs e)
        {
            string query = "select AppID,TypeName,[Start],[End],AppliedDate,[Status] from LeaveApply inner join LeaveType on LeaveType.TypeID = LeaveApply.TypeID where LeaveApply.EmpID = "+uID+"";
            DataTable result = DataConnect.GetData(query);
            if(result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvEmpHistory.DataSource = result;
            dgvEmpHistory.Refresh();
            dgvEmpHistory.ClearSelection();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            dgvEmpHistory.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeDashboard obj = new EmployeeDashboard(uID);
            obj.Show();
            this.Close();
        }
    }
}
