using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeLeaveManagementSystem
{
    public partial class AdminProfile : Form
    {
        int uID = 0;
        public AdminProfile()
        {
            InitializeComponent(); 
        }
        public AdminProfile(int id)
        {
            InitializeComponent();
            uID = id;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminDashboard obj = new AdminDashboard(uID);
            this.Close();
            obj.Show();
        }
        private void AdminProfile_Load(object sender, EventArgs e)
        {
            string query = "select UserID,Username,[Password] from UserInfo  where UserID="+uID+"";
            var result = DataConnect.GetData(query);
            if (result == null)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtID.Text = result.Rows[0]["UserID"].ToString();
            txtName.Text = result.Rows[0]["Username"].ToString();
            txtPass.Text = result.Rows[0]["Password"].ToString();
            this.ActiveControl = label1;
        }
    }
}
