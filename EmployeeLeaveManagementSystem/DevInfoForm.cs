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
    public partial class DevInfoForm : Form
    {
        public DevInfoForm()
        {
            InitializeComponent();
        }

        private void DevInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/dip.khan.526");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://x.com/dipkhan870");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/dashboard");
        }
    }
}
