namespace EmployeeLeaveManagementSystem
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnMngUser = new System.Windows.Forms.Button();
            this.btnMngLeave = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnMngEmployee = new System.Windows.Forms.Button();
            this.btnAdminProfile = new System.Windows.Forms.Button();
            this.btnMngLeaveReq = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Admin";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 500);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(82, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sign Out";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(23, 440);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnMngUser
            // 
            this.btnMngUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMngUser.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMngUser.Image = ((System.Drawing.Image)(resources.GetObject("btnMngUser.Image")));
            this.btnMngUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMngUser.Location = new System.Drawing.Point(402, 101);
            this.btnMngUser.Name = "btnMngUser";
            this.btnMngUser.Size = new System.Drawing.Size(279, 49);
            this.btnMngUser.TabIndex = 2;
            this.btnMngUser.Text = "User";
            this.btnMngUser.UseVisualStyleBackColor = true;
            this.btnMngUser.Click += new System.EventHandler(this.btnMngUser_Click);
            // 
            // btnMngLeave
            // 
            this.btnMngLeave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMngLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMngLeave.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMngLeave.Image = ((System.Drawing.Image)(resources.GetObject("btnMngLeave.Image")));
            this.btnMngLeave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMngLeave.Location = new System.Drawing.Point(402, 268);
            this.btnMngLeave.Name = "btnMngLeave";
            this.btnMngLeave.Size = new System.Drawing.Size(279, 49);
            this.btnMngLeave.TabIndex = 3;
            this.btnMngLeave.Text = "Leave Type";
            this.btnMngLeave.UseVisualStyleBackColor = true;
            this.btnMngLeave.Click += new System.EventHandler(this.btnMngLeave_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewHistory.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnViewHistory.Image")));
            this.btnViewHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewHistory.Location = new System.Drawing.Point(402, 419);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(279, 49);
            this.btnViewHistory.TabIndex = 4;
            this.btnViewHistory.Text = "History";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnMngEmployee
            // 
            this.btnMngEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMngEmployee.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMngEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnMngEmployee.Image")));
            this.btnMngEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMngEmployee.Location = new System.Drawing.Point(402, 184);
            this.btnMngEmployee.Name = "btnMngEmployee";
            this.btnMngEmployee.Size = new System.Drawing.Size(279, 49);
            this.btnMngEmployee.TabIndex = 5;
            this.btnMngEmployee.Text = "Employee";
            this.btnMngEmployee.UseVisualStyleBackColor = true;
            this.btnMngEmployee.Click += new System.EventHandler(this.btnMngEmployee_Click);
            // 
            // btnAdminProfile
            // 
            this.btnAdminProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdminProfile.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminProfile.Image")));
            this.btnAdminProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminProfile.Location = new System.Drawing.Point(402, 21);
            this.btnAdminProfile.Name = "btnAdminProfile";
            this.btnAdminProfile.Size = new System.Drawing.Size(279, 49);
            this.btnAdminProfile.TabIndex = 6;
            this.btnAdminProfile.Text = "Profile";
            this.btnAdminProfile.UseVisualStyleBackColor = true;
            this.btnAdminProfile.Click += new System.EventHandler(this.btnAdminProfile_Click);
            // 
            // btnMngLeaveReq
            // 
            this.btnMngLeaveReq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMngLeaveReq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMngLeaveReq.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMngLeaveReq.Image = ((System.Drawing.Image)(resources.GetObject("btnMngLeaveReq.Image")));
            this.btnMngLeaveReq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMngLeaveReq.Location = new System.Drawing.Point(402, 348);
            this.btnMngLeaveReq.Name = "btnMngLeaveReq";
            this.btnMngLeaveReq.Size = new System.Drawing.Size(279, 49);
            this.btnMngLeaveReq.TabIndex = 7;
            this.btnMngLeaveReq.Text = "Leave Request";
            this.btnMngLeaveReq.UseVisualStyleBackColor = true;
            this.btnMngLeaveReq.Click += new System.EventHandler(this.btnMngLeaveReq_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btnMngLeaveReq);
            this.Controls.Add(this.btnAdminProfile);
            this.Controls.Add(this.btnMngEmployee);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.btnMngLeave);
            this.Controls.Add(this.btnMngUser);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnMngUser;
        private System.Windows.Forms.Button btnMngLeave;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnMngEmployee;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAdminProfile;
        private System.Windows.Forms.Button btnMngLeaveReq;
    }
}