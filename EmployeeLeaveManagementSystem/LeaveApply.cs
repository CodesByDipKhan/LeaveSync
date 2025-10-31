using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeLeaveManagementSystem
{
    public partial class LeaveApply : Form
    {
        int uID = 0;
        public LeaveApply()
        {
            InitializeComponent();
        }
        public LeaveApply(int id)
        {
            InitializeComponent();
            uID = id;
        }

        private void LeaveApply_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            string query = "select * from LeaveType";
            DataTable result = DataConnect.GetData(query);
            if(result == null)
            {
                MessageBox.Show("Something went wrong","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            cmbLeaveTypes.DisplayMember = "TypeName";
            cmbLeaveTypes.ValueMember = "TypeID";
            cmbLeaveTypes.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeDashboard obj = new EmployeeDashboard(uID);
            obj.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }
        private void ClearData()
        {
            cmbLeaveTypes.SelectedIndex = -1;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            rtxtReason.Clear();
        }

        private bool CheckForOverlappingLeaves()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\AIUB\\6th Semester\\EmployeeLeaveManagementSystem\\ELMSDB.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False");
            con.Open();
            string query = @"SELECT COUNT(*) FROM LeaveApply WHERE EmpID = @EmpID AND [Status] IN ('Pending', 'Approved')  
            AND ( (@Start BETWEEN [Start] AND [End]) OR (@End BETWEEN [Start] AND [End]) OR ([Start] BETWEEN @Start AND @End) OR ([End] BETWEEN @Start AND @End) )";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@EmpID", uID);
                cmd.Parameters.AddWithValue("@Start", dtpStart.Value);
                cmd.Parameters.AddWithValue("@End", dtpEnd.Value);

                int overlapCount = (int)cmd.ExecuteScalar();

                if (overlapCount > 0)
                {
                    MessageBox.Show("The requested leave period overlaps with an existing leave.");
                    return true; 
                }
                return false;
            }
        }

        private bool ValidateForm()
        {
            if (cmbLeaveTypes.SelectedItem == null)
            {
                MessageBox.Show("Please select a leave type.");
                return false;
            }

            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                MessageBox.Show("End date must be on or after the start date.");
                return false;
            }

            if (dtpStart.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the past.");
                return false;
            }
         
            int leaveDays = (dtpEnd.Value.Date - dtpStart.Value.Date).Days + 1;

            string query = "select * from employee where EmpID="+uID+"";
            DataTable result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong while fetching leave balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int leaveBalance = Convert.ToInt32(result.Rows[0]["Balance"]);

            DateTime doj = Convert.ToDateTime(result.Rows[0]["DOJ"]);
            if (dtpStart.Value.Date < doj)
            {
                MessageBox.Show("Leave cannot be applied before the joining date.", "Invalid Leave Period", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (leaveDays > leaveBalance)
            {
                MessageBox.Show($"Insufficient leave balance. Available: {leaveBalance} days, Requested: {leaveDays} days.","Insufficient Leave Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string typeID = cmbLeaveTypes.SelectedValue.ToString();
            string maxDaysQuery = "SELECT Days FROM LeaveType WHERE TypeID = " + typeID;
            DataTable maxDaysResult = DataConnect.GetData(maxDaysQuery);

            if (maxDaysResult == null)
            {
                MessageBox.Show("Something went wrong while fetching maximum allowed days for the selected leave type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int maxDays = Convert.ToInt32(maxDaysResult.Rows[0]["Days"]);

            if (leaveDays > maxDays)
            {
                MessageBox.Show($"The number of requested leave days exceeds the maximum allowed for this leave type. Max allowed: {maxDays}, Requested: {leaveDays}", "Exceeds Maximum Leave Days", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(CheckForOverlappingLeaves())
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(rtxtReason.Text))
            {
                MessageBox.Show("Please provide a reason for the leave.");
                return false;
            }
            return true;
        }
        private void rbtnSubmit_Click(object sender, EventArgs e)
        {
            this.SubmitData();
        }
        private void SubmitData()
        {
            if(ValidateForm()==true)
            {
                int empID = uID;
                int typeID = Convert.ToInt32(cmbLeaveTypes.SelectedValue);
                string startDate = dtpStart.Value.ToString();
                string endDate = dtpEnd.Value.ToString();
                string reason = rtxtReason.Text;
                string appliedDate = DateTime.Now.ToString();

                string query = "insert into LeaveApply(EmpID,TypeID,[Start],[End],[Status],Reason,AppliedDate) values ("+empID+","+typeID+",'"+startDate+"','"+endDate+"','Pending','"+reason+"','"+appliedDate+"')";
                var result = DataConnect.ExecuteQuery(query);
                if(result == false)
                {
                    MessageBox.Show("Something went wrong","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Leave application submitted successfully!");
                ClearData();
            }
        }
    }
}
