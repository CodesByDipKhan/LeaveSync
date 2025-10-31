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
    public partial class LeaveReqManage : Form
    {
        int uID = 0;
        public LeaveReqManage()
        {
            InitializeComponent();
        }
        public LeaveReqManage(int id)
        {
            InitializeComponent();
            uID = id;
        }

        private void LeaveReqManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminDashboard obj = new AdminDashboard(uID);
            obj.Show();
        }

        private void LeaveReqManage_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string query = "SELECT LA.AppID,E.EmpID, E.[Name], LT.TypeName AS LeaveType, LA.[Start], LA.[End], LA.AppliedDate FROM LeaveApply LA inner join Employee E ON LA.EmpID = E.EmpID inner join LeaveType LT ON LA.TypeID = LT.TypeID WHERE LA.[Status] = 'Pending'";
            DataTable result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvManageReq.DataSource = result;
            dgvManageReq.Refresh();
            dgvManageReq.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvManageReq.ClearSelection();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvManageReq.SelectedRows.Count > 0)
            {
                int rowIndex = dgvManageReq.SelectedRows[0].Index;
                int selectedAppID = Convert.ToInt32(dgvManageReq.SelectedRows[0].Cells["AppID"].Value);
                int empID = Convert.ToInt32(dgvManageReq.SelectedRows[0].Cells["EmpID"].Value);
                string typeName = dgvManageReq.SelectedRows[0].Cells["LeaveType"].Value.ToString(); 
                DateTime startDate = Convert.ToDateTime(dgvManageReq.SelectedRows[0].Cells["Start"].Value);
                DateTime endDate = Convert.ToDateTime(dgvManageReq.SelectedRows[0].Cells["End"].Value);

                if (rowIndex >= 0)
                {
                    TimeSpan leaveDuration = endDate - startDate;
                    int leaveDays = leaveDuration.Days + 1;
                    DialogResult output = MessageBox.Show("Are you sure?","Question",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (output == DialogResult.Yes)
                    {
                        string approveQuery = "UPDATE LeaveApply SET [Status] = 'Approved' WHERE AppID = " + selectedAppID;
                        var result = DataConnect.ExecuteQuery(approveQuery);
                        if (result == false)
                        {
                            MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string deductBalance = "UPDATE Employee SET Balance = Balance - " + leaveDays + " WHERE EmpID = " + empID;
                        var updateBalance = DataConnect.ExecuteQuery(deductBalance);
                        if (updateBalance == false)
                        {
                            MessageBox.Show("Failed to update leave balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show("Successfully approved and leave balance updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadData();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvManageReq.SelectedRows.Count > 0)
            {
                int rowIndex = dgvManageReq.SelectedRows[0].Index;
                int selectedAppID = Convert.ToInt32(dgvManageReq.SelectedRows[0].Cells["AppID"].Value);

                if (rowIndex >= 0)
                {
                    DialogResult result2 = MessageBox.Show("Are you sure","Question",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result2 == DialogResult.Yes)
                    {
                        string query = "update LeaveApply set [Status] = 'Rejected' where AppID = " + selectedAppID;
                        var result = DataConnect.ExecuteQuery(query);
                        if (result == false)
                        {
                            MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        MessageBox.Show("Successfully rejected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadData();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
