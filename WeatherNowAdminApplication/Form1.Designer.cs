namespace WeatherNowApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabHelp = new TabPage();
            linkNexelPage = new LinkLabel();
            label11 = new Label();
            linkInstagram = new LinkLabel();
            linkFacebook = new LinkLabel();
            picInstagram = new PictureBox();
            picFacebook = new PictureBox();
            label10 = new Label();
            btnContact = new Button();
            picLinkNexelLogo = new PictureBox();
            tabSensorControl = new TabPage();
            label12 = new Label();
            btnDeleteMeasurement = new Button();
            cboMeasureId = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            dgvAllMeasurement = new DataGridView();
            label6 = new Label();
            label5 = new Label();
            dgvMeasurement = new DataGridView();
            dtpFrom = new DateTimePicker();
            btnShowData = new Button();
            dtpTo = new DateTimePicker();
            lvlSensorShow = new Label();
            cboSensors = new ComboBox();
            tabUserManagement = new TabPage();
            btnAddSensor = new Button();
            label9 = new Label();
            btnDisconnectSensor = new Button();
            dgvUserData = new DataGridView();
            label4 = new Label();
            label3 = new Label();
            dgvSensors = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            cboUserConnect = new ComboBox();
            dgvUsers = new DataGridView();
            btnAddUser = new Button();
            lvlUser = new Label();
            cboUsersToDelete = new ComboBox();
            cboSensorConnect = new ComboBox();
            lblSensor = new Label();
            btnDeleteUser = new Button();
            btnConnectSensor = new Button();
            tabControl = new TabControl();
            tabHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInstagram).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFacebook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLinkNexelLogo).BeginInit();
            tabSensorControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllMeasurement).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeasurement).BeginInit();
            tabUserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSensors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabHelp
            // 
            tabHelp.Controls.Add(linkNexelPage);
            tabHelp.Controls.Add(label11);
            tabHelp.Controls.Add(linkInstagram);
            tabHelp.Controls.Add(linkFacebook);
            tabHelp.Controls.Add(picInstagram);
            tabHelp.Controls.Add(picFacebook);
            tabHelp.Controls.Add(label10);
            tabHelp.Controls.Add(btnContact);
            tabHelp.Controls.Add(picLinkNexelLogo);
            tabHelp.Location = new Point(4, 29);
            tabHelp.Name = "tabHelp";
            tabHelp.Padding = new Padding(3);
            tabHelp.Size = new Size(768, 392);
            tabHelp.TabIndex = 2;
            tabHelp.Text = "Help";
            tabHelp.UseVisualStyleBackColor = true;
            tabHelp.Paint += tabHelp_Paint;
            // 
            // linkNexelPage
            // 
            linkNexelPage.AutoSize = true;
            linkNexelPage.Location = new Point(167, 83);
            linkNexelPage.Name = "linkNexelPage";
            linkNexelPage.Size = new Size(85, 15);
            linkNexelPage.TabIndex = 20;
            linkNexelPage.TabStop = true;
            linkNexelPage.Text = "Nexel Software";
            linkNexelPage.LinkClicked += linkNexelPage_LinkClicked;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(96, 44);
            label11.Name = "label11";
            label11.Size = new Size(37, 15);
            label11.TabIndex = 19;
            label11.Text = "Links:";
            // 
            // linkInstagram
            // 
            linkInstagram.AutoSize = true;
            linkInstagram.Location = new Point(167, 207);
            linkInstagram.Name = "linkInstagram";
            linkInstagram.Size = new Size(92, 15);
            linkInstagram.TabIndex = 18;
            linkInstagram.TabStop = true;
            linkInstagram.Text = "/Nexel_Software";
            linkInstagram.LinkClicked += linkInstagram_LinkClicked;
            // 
            // linkFacebook
            // 
            linkFacebook.AutoSize = true;
            linkFacebook.Location = new Point(167, 149);
            linkFacebook.Name = "linkFacebook";
            linkFacebook.Size = new Size(92, 15);
            linkFacebook.TabIndex = 17;
            linkFacebook.TabStop = true;
            linkFacebook.Text = "/Nexel_Software";
            linkFacebook.LinkClicked += linkFacebook_LinkClicked;
            // 
            // picInstagram
            // 
            picInstagram.Image = (Image)resources.GetObject("picInstagram.Image");
            picInstagram.Location = new Point(96, 194);
            picInstagram.Name = "picInstagram";
            picInstagram.Size = new Size(65, 54);
            picInstagram.SizeMode = PictureBoxSizeMode.StretchImage;
            picInstagram.TabIndex = 16;
            picInstagram.TabStop = false;
            picInstagram.Click += picInstagram_Click;
            picInstagram.MouseEnter += picInstagram_MouseEnter;
            picInstagram.MouseLeave += picInstagram_MouseLeave;
            // 
            // picFacebook
            // 
            picFacebook.Image = (Image)resources.GetObject("picFacebook.Image");
            picFacebook.Location = new Point(96, 128);
            picFacebook.Name = "picFacebook";
            picFacebook.Size = new Size(65, 59);
            picFacebook.SizeMode = PictureBoxSizeMode.StretchImage;
            picFacebook.TabIndex = 15;
            picFacebook.TabStop = false;
            picFacebook.Click += picFacebook_Click;
            picFacebook.MouseEnter += picFacebook_MouseEnter;
            picFacebook.MouseLeave += picFacebook_MouseLeave;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(426, 45);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 14;
            label10.Text = "Contact us:";
            // 
            // btnContact
            // 
            btnContact.Location = new Point(426, 62);
            btnContact.Margin = new Padding(2);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(267, 41);
            btnContact.TabIndex = 12;
            btnContact.Text = "Create mail";
            btnContact.UseVisualStyleBackColor = true;
            btnContact.Click += btnEmilContact_Click;
            // 
            // picLinkNexelLogo
            // 
            picLinkNexelLogo.Image = (Image)resources.GetObject("picLinkNexelLogo.Image");
            picLinkNexelLogo.InitialImage = null;
            picLinkNexelLogo.Location = new Point(98, 62);
            picLinkNexelLogo.Name = "picLinkNexelLogo";
            picLinkNexelLogo.Size = new Size(63, 60);
            picLinkNexelLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLinkNexelLogo.TabIndex = 9;
            picLinkNexelLogo.TabStop = false;
            picLinkNexelLogo.WaitOnLoad = true;
            picLinkNexelLogo.Click += picLinkNexelLogo_Click;
            picLinkNexelLogo.MouseEnter += picLinkNexelLogo_MouseEnter;
            picLinkNexelLogo.MouseLeave += picLinkNexelLogo_MouseLeave;
            // 
            // tabSensorControl
            // 
            tabSensorControl.BackgroundImageLayout = ImageLayout.Stretch;
            tabSensorControl.Controls.Add(label12);
            tabSensorControl.Controls.Add(btnDeleteMeasurement);
            tabSensorControl.Controls.Add(cboMeasureId);
            tabSensorControl.Controls.Add(label8);
            tabSensorControl.Controls.Add(label7);
            tabSensorControl.Controls.Add(dgvAllMeasurement);
            tabSensorControl.Controls.Add(label6);
            tabSensorControl.Controls.Add(label5);
            tabSensorControl.Controls.Add(dgvMeasurement);
            tabSensorControl.Controls.Add(dtpFrom);
            tabSensorControl.Controls.Add(btnShowData);
            tabSensorControl.Controls.Add(dtpTo);
            tabSensorControl.Controls.Add(lvlSensorShow);
            tabSensorControl.Controls.Add(cboSensors);
            tabSensorControl.Location = new Point(4, 29);
            tabSensorControl.Name = "tabSensorControl";
            tabSensorControl.Padding = new Padding(3);
            tabSensorControl.Size = new Size(768, 392);
            tabSensorControl.TabIndex = 1;
            tabSensorControl.Text = "SensorControl";
            tabSensorControl.UseVisualStyleBackColor = true;
            tabSensorControl.Paint += tabUserManagement_Paint;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(484, 320);
            label12.Name = "label12";
            label12.Size = new Size(65, 15);
            label12.TabIndex = 54;
            label12.Text = "MeasureId:";
            // 
            // btnDeleteMeasurement
            // 
            btnDeleteMeasurement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteMeasurement.Location = new Point(662, 309);
            btnDeleteMeasurement.Name = "btnDeleteMeasurement";
            btnDeleteMeasurement.Size = new Size(91, 40);
            btnDeleteMeasurement.TabIndex = 53;
            btnDeleteMeasurement.Text = "Delete MeasuremeId";
            btnDeleteMeasurement.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDeleteMeasurement.UseVisualStyleBackColor = true;
            btnDeleteMeasurement.Click += btnDeleteMeasurement_Click;
            // 
            // cboMeasureId
            // 
            cboMeasureId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboMeasureId.FormattingEnabled = true;
            cboMeasureId.Location = new Point(562, 320);
            cboMeasureId.Name = "cboMeasureId";
            cboMeasureId.Size = new Size(93, 23);
            cboMeasureId.TabIndex = 52;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(478, 3);
            label8.Name = "label8";
            label8.Size = new Size(166, 15);
            label8.TabIndex = 50;
            label8.Text = "Measurements by parameters:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(8, 3);
            label7.Name = "label7";
            label7.Size = new Size(105, 15);
            label7.TabIndex = 49;
            label7.Text = "All measurements:";
            // 
            // dgvAllMeasurement
            // 
            dgvAllMeasurement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAllMeasurement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllMeasurement.Location = new Point(8, 21);
            dgvAllMeasurement.Name = "dgvAllMeasurement";
            dgvAllMeasurement.RowHeadersWidth = 62;
            dgvAllMeasurement.Size = new Size(464, 363);
            dgvAllMeasurement.TabIndex = 48;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(498, 255);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 47;
            label6.Text = "To date:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(482, 231);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 46;
            label5.Text = "From date:";
            // 
            // dgvMeasurement
            // 
            dgvMeasurement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMeasurement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeasurement.Location = new Point(478, 21);
            dgvMeasurement.Name = "dgvMeasurement";
            dgvMeasurement.RowHeadersWidth = 62;
            dgvMeasurement.Size = new Size(275, 202);
            dgvMeasurement.TabIndex = 45;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.CustomFormat = "HH:mm dd.MM.yyyy";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.Location = new Point(555, 231);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(111, 23);
            dtpFrom.TabIndex = 36;
            // 
            // btnShowData
            // 
            btnShowData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowData.Location = new Point(677, 240);
            btnShowData.Name = "btnShowData";
            btnShowData.Size = new Size(76, 50);
            btnShowData.TabIndex = 35;
            btnShowData.Text = "Show Data";
            btnShowData.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnShowData.UseVisualStyleBackColor = true;
            btnShowData.Click += btnShowData_Click;
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.CustomFormat = "HH:mm dd.MM.yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(555, 255);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(111, 23);
            dtpTo.TabIndex = 37;
            dtpTo.Value = new DateTime(2024, 11, 2, 2, 19, 59, 0);
            // 
            // lvlSensorShow
            // 
            lvlSensorShow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lvlSensorShow.AutoSize = true;
            lvlSensorShow.Location = new Point(490, 280);
            lvlSensorShow.Name = "lvlSensorShow";
            lvlSensorShow.Size = new Size(55, 15);
            lvlSensorShow.TabIndex = 40;
            lvlSensorShow.Text = "SensorId:";
            // 
            // cboSensors
            // 
            cboSensors.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboSensors.FormattingEnabled = true;
            cboSensors.Location = new Point(555, 280);
            cboSensors.Name = "cboSensors";
            cboSensors.Size = new Size(111, 23);
            cboSensors.TabIndex = 39;
            // 
            // tabUserManagement
            // 
            tabUserManagement.BackColor = Color.Transparent;
            tabUserManagement.Controls.Add(btnAddSensor);
            tabUserManagement.Controls.Add(label9);
            tabUserManagement.Controls.Add(btnDisconnectSensor);
            tabUserManagement.Controls.Add(dgvUserData);
            tabUserManagement.Controls.Add(label4);
            tabUserManagement.Controls.Add(label3);
            tabUserManagement.Controls.Add(dgvSensors);
            tabUserManagement.Controls.Add(label2);
            tabUserManagement.Controls.Add(label1);
            tabUserManagement.Controls.Add(cboUserConnect);
            tabUserManagement.Controls.Add(dgvUsers);
            tabUserManagement.Controls.Add(btnAddUser);
            tabUserManagement.Controls.Add(lvlUser);
            tabUserManagement.Controls.Add(cboUsersToDelete);
            tabUserManagement.Controls.Add(cboSensorConnect);
            tabUserManagement.Controls.Add(lblSensor);
            tabUserManagement.Controls.Add(btnDeleteUser);
            tabUserManagement.Controls.Add(btnConnectSensor);
            tabUserManagement.Location = new Point(4, 29);
            tabUserManagement.Name = "tabUserManagement";
            tabUserManagement.Padding = new Padding(3);
            tabUserManagement.Size = new Size(768, 392);
            tabUserManagement.TabIndex = 0;
            tabUserManagement.Text = "Usermanager";
            tabUserManagement.Paint += tabUserManagement_Paint;
            // 
            // btnAddSensor
            // 
            btnAddSensor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddSensor.Location = new Point(523, 310);
            btnAddSensor.Name = "btnAddSensor";
            btnAddSensor.Size = new Size(228, 31);
            btnAddSensor.TabIndex = 52;
            btnAddSensor.Text = "Edit Sensor And Locations";
            btnAddSensor.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddSensor.UseVisualStyleBackColor = true;
            btnAddSensor.Click += btnAddSensor_Click_1;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(253, 199);
            label9.Name = "label9";
            label9.Size = new Size(111, 15);
            label9.TabIndex = 43;
            label9.Text = "Connected Sensors:";
            // 
            // btnDisconnectSensor
            // 
            btnDisconnectSensor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisconnectSensor.Location = new Point(604, 248);
            btnDisconnectSensor.Name = "btnDisconnectSensor";
            btnDisconnectSensor.Size = new Size(78, 37);
            btnDisconnectSensor.TabIndex = 42;
            btnDisconnectSensor.Text = "Disconnect";
            btnDisconnectSensor.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDisconnectSensor.UseVisualStyleBackColor = true;
            btnDisconnectSensor.Click += btnDisconnectSensor_Click;
            // 
            // dgvUserData
            // 
            dgvUserData.AllowUserToResizeRows = false;
            dgvUserData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUserData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUserData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUserData.Location = new Point(253, 217);
            dgvUserData.Name = "dgvUserData";
            dgvUserData.RowHeadersWidth = 62;
            dgvUserData.Size = new Size(248, 167);
            dgvUserData.TabIndex = 41;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(8, 200);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 40;
            label4.Text = "Available Sensors:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(15, 3);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 39;
            label3.Text = "Users:";
            // 
            // dgvSensors
            // 
            dgvSensors.AllowUserToAddRows = false;
            dgvSensors.AllowUserToDeleteRows = false;
            dgvSensors.AllowUserToResizeColumns = false;
            dgvSensors.AllowUserToResizeRows = false;
            dgvSensors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvSensors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSensors.Location = new Point(8, 217);
            dgvSensors.Margin = new Padding(2);
            dgvSensors.Name = "dgvSensors";
            dgvSensors.RowHeadersWidth = 62;
            dgvSensors.Size = new Size(240, 167);
            dgvSensors.TabIndex = 38;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(523, 22);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 37;
            label2.Text = "Add new user:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(523, 200);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 36;
            label1.Text = "Choose user:";
            // 
            // cboUserConnect
            // 
            cboUserConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboUserConnect.FormattingEnabled = true;
            cboUserConnect.Location = new Point(523, 219);
            cboUserConnect.Name = "cboUserConnect";
            cboUserConnect.Size = new Size(75, 23);
            cboUserConnect.TabIndex = 35;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(8, 21);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(493, 176);
            dgvUsers.TabIndex = 34;
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUser.Location = new Point(523, 40);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(110, 36);
            btnAddUser.TabIndex = 33;
            btnAddUser.Text = "Add User";
            btnAddUser.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // lvlUser
            // 
            lvlUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lvlUser.AutoSize = true;
            lvlUser.Location = new Point(523, 79);
            lvlUser.Name = "lvlUser";
            lvlUser.Size = new Size(92, 15);
            lvlUser.TabIndex = 12;
            lvlUser.Text = "UserId to delete:";
            // 
            // cboUsersToDelete
            // 
            cboUsersToDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboUsersToDelete.FormattingEnabled = true;
            cboUsersToDelete.Location = new Point(523, 97);
            cboUsersToDelete.Name = "cboUsersToDelete";
            cboUsersToDelete.Size = new Size(110, 23);
            cboUsersToDelete.TabIndex = 11;
            // 
            // cboSensorConnect
            // 
            cboSensorConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboSensorConnect.FormattingEnabled = true;
            cboSensorConnect.Location = new Point(604, 219);
            cboSensorConnect.Name = "cboSensorConnect";
            cboSensorConnect.Size = new Size(74, 23);
            cboSensorConnect.TabIndex = 17;
            // 
            // lblSensor
            // 
            lblSensor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSensor.AutoSize = true;
            lblSensor.Location = new Point(604, 200);
            lblSensor.Name = "lblSensor";
            lblSensor.Size = new Size(87, 15);
            lblSensor.TabIndex = 18;
            lblSensor.Text = "Choose sensor:";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteUser.Location = new Point(523, 126);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(110, 38);
            btnDeleteUser.TabIndex = 22;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnConnectSensor
            // 
            btnConnectSensor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnectSensor.Location = new Point(523, 248);
            btnConnectSensor.Name = "btnConnectSensor";
            btnConnectSensor.Size = new Size(78, 37);
            btnConnectSensor.TabIndex = 25;
            btnConnectSensor.Text = "Connect";
            btnConnectSensor.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnConnectSensor.UseVisualStyleBackColor = true;
            btnConnectSensor.Click += btnConnectSensor_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabUserManagement);
            tabControl.Controls.Add(tabSensorControl);
            tabControl.Controls.Add(tabHelp);
            tabControl.Dock = DockStyle.Fill;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.ItemSize = new Size(82, 25);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 425);
            tabControl.SizeMode = TabSizeMode.FillToRight;
            tabControl.TabIndex = 35;
            tabControl.DrawItem += tabControl_DrawItem;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(776, 425);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "WeatherNow";
            tabHelp.ResumeLayout(false);
            tabHelp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picInstagram).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFacebook).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLinkNexelLogo).EndInit();
            tabSensorControl.ResumeLayout(false);
            tabSensorControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllMeasurement).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeasurement).EndInit();
            tabUserManagement.ResumeLayout(false);
            tabUserManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserData).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSensors).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabHelp;
        private Button btnContact;
        private PictureBox picLinkNexelLogo;
        private TabPage tabSensorControl;
        private Label label8;
        private Label label7;
        private DataGridView dgvAllMeasurement;
        private Label label6;
        private Label label5;
        private DataGridView dgvMeasurement;
        private DateTimePicker dtpFrom;
        private Button btnShowData;
        private DateTimePicker dtpTo;
        private Label lvlSensorShow;
        private ComboBox cboSensors;
        private TabPage tabUserManagement;
        private Button btnDisconnectSensor;
        private DataGridView dgvUserData;
        private Label label4;
        private Label label3;
        private DataGridView dgvSensors;
        private Label label2;
        private Label label1;
        private ComboBox cboUserConnect;
        private DataGridView dgvUsers;
        private Button btnAddUser;
        private Label lvlUser;
        private ComboBox cboUsersToDelete;
        private ComboBox cboSensorConnect;
        private Label lblSensor;
        private Button btnDeleteUser;
        private Button btnConnectSensor;
        private TabControl tabControl;
        private Label label9;
        private Label label10;
        private LinkLabel linkInstagram;
        private LinkLabel linkFacebook;
        private PictureBox picInstagram;
        private PictureBox picFacebook;
        private LinkLabel linkNexelPage;
        private Label label11;
        private Button btnDeleteMeasurement;
        private ComboBox cboMeasureId;
        private Button btnAddSensor;
        private Label label12;
    }
}
