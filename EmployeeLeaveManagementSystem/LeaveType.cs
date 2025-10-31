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
    public partial class LeaveType : Form
    {
        int uID = 0;
        public LeaveType()
        {
            InitializeComponent();
        }
        public LeaveType(int ID)
        {
            InitializeComponent();
            uID = ID;
        }

        private void LeaveType_Load(object sender, EventArgs e)
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
            dgvLeaveType.AutoGenerateColumns = false;
            dgvLeaveType.DataSource = result;
            dgvLeaveType.Refresh();
            dgvLeaveType.ClearSelection();
        }

        private void dgvLeaveType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                string id = dgvLeaveType.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadSingleData(id);
            }
        }
        private void LoadSingleData(string id)
        {
            string query = "select * from LeaveType where TypeID="+id+"";
            DataTable result = DataConnect.GetData(query);
            if(result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtID.Text = result.Rows[0]["TypeID"].ToString();
            txtName.Text = result.Rows[0]["TypeName"].ToString();
            txtDays.Text = result.Rows[0]["Days"].ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtID.Clear();
            txtName.Clear();
            txtDays.Clear();
            dgvLeaveType.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteData();
        }
        private void DeleteData()
        {
            string id = txtID.Text;
            if(id == "")
            {
                MessageBox.Show("Please select a row first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "delete from LeaveType where TypeID="+id+"";
            DialogResult output = MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (output == DialogResult.Yes)
            {
                var result = DataConnect.ExecuteQuery(query);
                if (result == false)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadData();
                this.NewData();
            }
            else
            {
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }
        private void SaveData()
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string days = txtDays.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(days) )
            {
                MessageBox.Show("Please fill in all required fields: Username, Password, and Role", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == "")
            {
                string query = "insert into LeaveType(TypeName,[Days]) output inserted.TypeID values ('" + name + "'," + days + ")";
                var result = DataConnect.GetData(query);
                if (result == null)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtID.Text = result.Rows[0]["TypeID"].ToString();
                MessageBox.Show("New record inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string query = "update LeaveType set TypeName='" + name + "',Days=" + days + " where TypeID=" + id + "";
                var result = DataConnect.ExecuteQuery(query);

                if (result == false)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.LoadData();

            for (int i = 0; i < dgvLeaveType.Rows.Count; i++)
            {
                string selectedID = dgvLeaveType.Rows[i].Cells[0].Value.ToString();
                if (selectedID == id)
                {
                    dgvLeaveType.Rows[i].Selected = true;
                    break;
                }
            }
        }

        private void LeaveType_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminDashboard obj = new AdminDashboard(uID);
            obj.Show();
        }
    }
}
