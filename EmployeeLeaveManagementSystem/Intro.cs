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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value<100)
            {
                progressBar1.Value += 2;
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Welcome to LeaveSync");
                this.Hide();
                Login obj = new Login();
                obj.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult result = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
