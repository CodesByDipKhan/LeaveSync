using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeLeaveManagementSystem
{
    public partial class UserManagement : Form
    {
        int uID = 0;
        public UserManagement()
        {
            InitializeComponent();
        }
        public UserManagement(int id)
        {
            InitializeComponent();
            uID = id;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string query = "SELECT * FROM USERINFO";
            DataTable result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvManageUser.AutoGenerateColumns = false;
            dgvManageUser.DataSource = result;
            dgvManageUser.Refresh();
            dgvManageUser.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void dgvManageUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvManageUser.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadSingleData(id);
            }
        }
        private void LoadSingleData(string id)
        {
            string query = "SELECT * FROM USERINFO WHERE USERID=" + id + "";
            DataTable result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtUserID.Text = result.Rows[0]["UserID"].ToString();
            txtUsername.Text = result.Rows[0]["Username"].ToString();
            txtPass.Text = result.Rows[0]["Password"].ToString();
            txtRole.Text = result.Rows[0]["Role"].ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtUserID.Clear();
            txtUsername.Clear();
            txtPass.Clear();
            txtRole.Clear();
            dgvManageUser.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteData();
        }
        private void DeleteData()
        {
            string id = txtUserID.Text;
            if (id == "")
            {
                MessageBox.Show("Please select a row first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "DELETE FROM USERINFO WHERE USERID=" + id + "";
            DialogResult result1 = MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                var result = DataConnect.ExecuteQuery(query);
                if (result == false)
                {
                    MessageBox.Show("Something went wrong.");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }
        private void SaveData()
        {
            string id = txtUserID.Text;
            string name = txtUsername.Text;
            string pass = txtPass.Text;
            string role = txtRole.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please fill in all required fields: Username, Password, and Role", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (id == "")
            {
                string query = "insert into UserInfo(Username,[Password],[Role]) output inserted.UserID values('" + name + "','" + pass + "','" + role + "')";
                var result = DataConnect.GetData(query);
                if (result == null)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtUserID.Text = result.Rows[0]["UserID"].ToString();
                MessageBox.Show("New record inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string query = "update UserInfo set Username = '" + name + "',[Password] ='" + pass + "',[Role] = '" + role + "' where UserID = " + id + "";
                var result = DataConnect.ExecuteQuery(query);
                if (result == false)
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.LoadData();

            for (int i = 0; i < dgvManageUser.Rows.Count; i++)
            {
                string selectedID = dgvManageUser.Rows[i].Cells[0].Value.ToString();
                if (selectedID == id)
                {
                    dgvManageUser.Rows[i].Selected = true;
                    break;
                }
            }
        }

        private void UserManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminDashboard obj = new AdminDashboard(uID);
            obj.Show();
        }
    }
}
