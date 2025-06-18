namespace WeatherNowApplication
{
    partial class AddUser
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
            txtSurname = new TextBox();
            lblLastname = new Label();
            lblFirstname = new Label();
            txtFirstname = new TextBox();
            btnAddUser = new Button();
            txtPassword = new TextBox();
            label1 = new Label();
            txtUserName = new TextBox();
            label2 = new Label();
            cboRole = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(341, 57);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(100, 23);
            txtSurname.TabIndex = 4;
            // 
            // lblLastname
            // 
            lblLastname.AutoSize = true;
            lblLastname.Location = new Point(341, 37);
            lblLastname.Name = "lblLastname";
            lblLastname.Size = new Size(57, 15);
            lblLastname.TabIndex = 28;
            lblLastname.Text = "Surname:";
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Location = new Point(235, 37);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(62, 15);
            lblFirstname.TabIndex = 27;
            lblFirstname.Text = "Firstname:";
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(235, 57);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(100, 23);
            txtFirstname.TabIndex = 3;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(32, 97);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(74, 25);
            btnAddUser.TabIndex = 6;
            btnAddUser.Text = "Add User";
            btnAddUser.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(129, 57);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 37);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 30;
            label1.Text = "Password:";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(23, 57);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(100, 23);
            txtUserName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 37);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 32;
            label2.Text = "Username:";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Items.AddRange(new object[] { "Admin", "User" });
            cboRole.Location = new Point(447, 57);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(100, 23);
            cboRole.Sorted = true;
            cboRole.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(447, 37);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 35;
            label3.Text = "Role:";
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 137);
            Controls.Add(label3);
            Controls.Add(cboRole);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtSurname);
            Controls.Add(lblLastname);
            Controls.Add(lblFirstname);
            Controls.Add(txtFirstname);
            Controls.Add(btnAddUser);
            Name = "AddUser";
            Text = "AddUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSurname;
        private Label lblLastname;
        private Label lblFirstname;
        private TextBox txtFirstname;
        private Button btnAddUser;
        private TextBox txtPassword;
        private Label label1;
        private TextBox txtUserName;
        private Label label2;
        private ComboBox cboRole;
        private Label label3;
    }
}