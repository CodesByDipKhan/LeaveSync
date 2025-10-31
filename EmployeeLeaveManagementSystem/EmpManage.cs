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
    public partial class EmpManage : Form
    {
        int uID = 0;
        public EmpManage()
        {
            InitializeComponent();
        }
        public EmpManage(int id)
        {
            InitializeComponent();
            uID = id;
        }

        private void EmpManage_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string query = "select * from Employee";
            DataTable result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvManageEmp.AutoGenerateColumns = false;
            dgvManageEmp.DataSource = result;
            dgvManageEmp.Refresh();
            dgvManageEmp.ClearSelection();
        }

        private void dgvManageEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvManageEmp.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadSingleData(id);
            }
        }
        private void LoadSingleData(string id)
        {
            string query = "select * from Employee where EmpID=" + id + "";
            DataTable result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtID.Text = result.Rows[0]["EmpID"].ToString();
            txtName.Text = result.Rows[0]["Name"].ToString();
            if(result.Rows[0]["Gender"].ToString() == "Male")
            {
                rbtnMale.Checked = true;
            }
            else if(result.Rows[0]["Gender"].ToString() == "Female")
            {
                rbtnFemale.Checked = true;
            }
            else
            {
                MessageBox.Show("Please select a valid gender","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtPhone.Text = result.Rows[0]["Phone"].ToString();
            txtPosition.Text = result.Rows[0]["Position"].ToString();
            dtpDOJ.Value = DateTime.Parse(result.Rows[0]["DOJ"].ToString());
            txtBalance.Text = result.Rows[0]["Balance"].ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtPosition.Clear();
            txtBalance.Clear();
            rbtnMale.Checked=false;
            rbtnFemale.Checked=false;
            dtpDOJ.Value = DateTime.Now;
            dgvManageEmp.ClearSelection();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteData();
        }
        private void DeleteData()
        {
            string id = txtID.Text;
            if (id == "")
            {
                MessageBox.Show("Please select a row first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "delete from Employee where EmpID=" + id + "";
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
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtPosition.Text)  || string.IsNullOrWhiteSpace(txtBalance.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtID.Text;
            string name = txtName.Text;
            string gender = "";
            if (rbtnMale.Checked)
            {
                gender = "Male";
            }
            else if (rbtnFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                MessageBox.Show("Please select a valid gender", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string phone = txtPhone.Text;
            string position = txtPosition.Text;
            DateTime dt = Convert.ToDateTime(dtpDOJ.Text);
            string doj = dt.ToString("dd/MMM/yyyy");
            string balance = txtBalance.Text;
            if (dgvManageEmp.SelectedRows.Count==0)
            {
                string query = "insert into Employee output inserted.EmpID values(" + id + ",'" + name + "','" + gender + "','" + phone + "','" + position + "','" + doj + "'," + balance + ")";
                var result = DataConnect.GetData(query);
                if (result == null)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtID.Text = result.Rows[0]["EmpID"].ToString();
                MessageBox.Show("New record inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string query = "update Employee set EmpID=" + id + ",[Name]='" + name + "',Gender='" + gender + "',Phone='" + phone + "',Position='" + position + "',DOJ='" + doj + "',Balance=" + balance + " where EmpID=" + id + "";
                var result = DataConnect.ExecuteQuery(query);
                if (result == false)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.LoadData();

            for (int i = 0; i < dgvManageEmp.Rows.Count; i++)
            {
                string selectedID = dgvManageEmp.Rows[i].Cells[0].Value.ToString();
                if (selectedID == id)
                {
                    dgvManageEmp.Rows[i].Selected = true;
                    break;
                }
            }
        }

        private void EmpManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminDashboard obj = new AdminDashboard(uID);
            obj.Show();
        }
    }
}
