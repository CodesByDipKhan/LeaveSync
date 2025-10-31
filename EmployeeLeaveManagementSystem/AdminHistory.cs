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
    public partial class AdminHistory : Form
    {
        int uID = 0;
        public AdminHistory()
        {
            InitializeComponent();
        }
        public AdminHistory(int id)
        {
            InitializeComponent();
            uID = id;
        }

        private void AdminHistory_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string query = "SELECT LA.AppID,E.EmpID, E.[Name], LT.TypeName AS LeaveType, LA.[Start], LA.[End], LA.AppliedDate,LA.[Status] FROM LeaveApply LA inner join Employee E ON LA.EmpID = E.EmpID inner join LeaveType LT ON LA.TypeID = LT.TypeID WHERE LA.[Status] = 'Approved' OR LA.[Status] = 'Rejected'";
            DataTable result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvAdminHistory.DataSource = result;
            dgvAdminHistory.Refresh();
            dgvAdminHistory.ClearSelection();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard obj = new AdminDashboard(uID);
            obj.Show();
            this.Close();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            dgvAdminHistory.ClearSelection();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.DeleteData();
        }
        private void DeleteData()
        {
            if (dgvAdminHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvAdminHistory.SelectedRows[0].Index;

            if (rowIndex >= 0)
            {
                int selectedAppID = Convert.ToInt32(dgvAdminHistory.SelectedRows[0].Cells["AppID"].Value);
                string query = "delete from LeaveApply where AppID = "+selectedAppID+"";
                DialogResult output = MessageBox.Show("Are you sure?","Question",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (output == DialogResult.Yes)
                {
                    var result = DataConnect.ExecuteQuery(query);
                    if (result == false)
                    {
                        MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadData();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
