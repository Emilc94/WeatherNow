namespace WeatherNowApplication
{
    partial class AddSensor
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
            txtAddSensorId = new TextBox();
            txtAddSensorType = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dgvActiveSensors = new DataGridView();
            label3 = new Label();
            btnAddSensorToDB = new Button();
            dgvDisplayLocation = new DataGridView();
            label4 = new Label();
            cboActiveLocationId = new ComboBox();
            cboActiveSensorId = new ComboBox();
            btnAddLocationIdToSensor = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cboSensorToDelete = new ComboBox();
            btnDeleteSensor = new Button();
            btnAddNewLocation = new Button();
            label8 = new Label();
            label9 = new Label();
            txtNewLocationCountry = new TextBox();
            txtNewLocationCity = new TextBox();
            btnDeleteLocation = new Button();
            label10 = new Label();
            cboLocationToDelete = new ComboBox();
            label11 = new Label();
            txtNewLocationId = new TextBox();
            label15 = new Label();
            label12 = new Label();
            panel1 = new Panel();
            btnRemoveLocationSensor = new Button();
            label16 = new Label();
            label13 = new Label();
            panel2 = new Panel();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvActiveSensors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDisplayLocation).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtAddSensorId
            // 
            txtAddSensorId.Location = new Point(58, 58);
            txtAddSensorId.Name = "txtAddSensorId";
            txtAddSensorId.Size = new Size(94, 23);
            txtAddSensorId.TabIndex = 0;
            // 
            // txtAddSensorType
            // 
            txtAddSensorType.Location = new Point(58, 105);
            txtAddSensorType.Name = "txtAddSensorType";
            txtAddSensorType.Size = new Size(94, 23);
            txtAddSensorType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 40);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "SensorId";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 87);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "SensorType";
            // 
            // dgvActiveSensors
            // 
            dgvActiveSensors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveSensors.Location = new Point(12, 56);
            dgvActiveSensors.Name = "dgvActiveSensors";
            dgvActiveSensors.RowHeadersWidth = 62;
            dgvActiveSensors.Size = new Size(266, 128);
            dgvActiveSensors.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 38);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 5;
            label3.Text = "Active sensors";
            // 
            // btnAddSensorToDB
            // 
            btnAddSensorToDB.Location = new Point(58, 170);
            btnAddSensorToDB.Name = "btnAddSensorToDB";
            btnAddSensorToDB.Size = new Size(94, 40);
            btnAddSensorToDB.TabIndex = 6;
            btnAddSensorToDB.Text = "Add New Sensor";
            btnAddSensorToDB.UseVisualStyleBackColor = true;
            btnAddSensorToDB.Click += btnAddSensorToDB_Click;
            // 
            // dgvDisplayLocation
            // 
            dgvDisplayLocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDisplayLocation.Location = new Point(12, 211);
            dgvDisplayLocation.Name = "dgvDisplayLocation";
            dgvDisplayLocation.RowHeadersWidth = 62;
            dgvDisplayLocation.Size = new Size(266, 130);
            dgvDisplayLocation.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 192);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 8;
            label4.Text = "Locations:";
            // 
            // cboActiveLocationId
            // 
            cboActiveLocationId.FormattingEnabled = true;
            cboActiveLocationId.Location = new Point(389, 104);
            cboActiveLocationId.Name = "cboActiveLocationId";
            cboActiveLocationId.Size = new Size(87, 23);
            cboActiveLocationId.TabIndex = 9;
            // 
            // cboActiveSensorId
            // 
            cboActiveSensorId.FormattingEnabled = true;
            cboActiveSensorId.Location = new Point(389, 58);
            cboActiveSensorId.Name = "cboActiveSensorId";
            cboActiveSensorId.Size = new Size(87, 23);
            cboActiveSensorId.TabIndex = 10;
            // 
            // btnAddLocationIdToSensor
            // 
            btnAddLocationIdToSensor.Location = new Point(382, 130);
            btnAddLocationIdToSensor.Name = "btnAddLocationIdToSensor";
            btnAddLocationIdToSensor.Size = new Size(94, 40);
            btnAddLocationIdToSensor.TabIndex = 11;
            btnAddLocationIdToSensor.Text = "Add Location to Sensor";
            btnAddLocationIdToSensor.UseVisualStyleBackColor = true;
            btnAddLocationIdToSensor.Click += btnAddLocationIdToSensor_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(389, 86);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 12;
            label5.Text = "LocationId";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(389, 40);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 13;
            label6.Text = "SensorId:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 32);
            label7.Name = "label7";
            label7.Size = new Size(104, 15);
            label7.TabIndex = 15;
            label7.Text = "SensorId to delete:";
            // 
            // cboSensorToDelete
            // 
            cboSensorToDelete.FormattingEnabled = true;
            cboSensorToDelete.Location = new Point(30, 52);
            cboSensorToDelete.Name = "cboSensorToDelete";
            cboSensorToDelete.Size = new Size(87, 23);
            cboSensorToDelete.TabIndex = 14;
            // 
            // btnDeleteSensor
            // 
            btnDeleteSensor.Location = new Point(30, 81);
            btnDeleteSensor.Name = "btnDeleteSensor";
            btnDeleteSensor.Size = new Size(87, 38);
            btnDeleteSensor.TabIndex = 16;
            btnDeleteSensor.Text = "Delete Sensor";
            btnDeleteSensor.UseVisualStyleBackColor = true;
            btnDeleteSensor.Click += btnDeleteSensor_Click;
            // 
            // btnAddNewLocation
            // 
            btnAddNewLocation.Location = new Point(213, 170);
            btnAddNewLocation.Name = "btnAddNewLocation";
            btnAddNewLocation.Size = new Size(94, 40);
            btnAddNewLocation.TabIndex = 21;
            btnAddNewLocation.Text = "Add New Location";
            btnAddNewLocation.UseVisualStyleBackColor = true;
            btnAddNewLocation.Click += btnAddNewLocation_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(216, 124);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 20;
            label8.Text = "Country:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(213, 84);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 19;
            label9.Text = "City:";
            // 
            // txtNewLocationCountry
            // 
            txtNewLocationCountry.Location = new Point(216, 142);
            txtNewLocationCountry.Name = "txtNewLocationCountry";
            txtNewLocationCountry.Size = new Size(91, 23);
            txtNewLocationCountry.TabIndex = 18;
            // 
            // txtNewLocationCity
            // 
            txtNewLocationCity.Location = new Point(216, 98);
            txtNewLocationCity.Name = "txtNewLocationCity";
            txtNewLocationCity.Size = new Size(91, 23);
            txtNewLocationCity.TabIndex = 17;
            // 
            // btnDeleteLocation
            // 
            btnDeleteLocation.Location = new Point(30, 201);
            btnDeleteLocation.Name = "btnDeleteLocation";
            btnDeleteLocation.Size = new Size(87, 38);
            btnDeleteLocation.TabIndex = 24;
            btnDeleteLocation.Text = "Delete Location";
            btnDeleteLocation.UseVisualStyleBackColor = true;
            btnDeleteLocation.Click += btnDeleteLocation_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(30, 155);
            label10.Name = "label10";
            label10.Size = new Size(116, 15);
            label10.TabIndex = 23;
            label10.Text = "LocationId to Delete:";
            // 
            // cboLocationToDelete
            // 
            cboLocationToDelete.FormattingEnabled = true;
            cboLocationToDelete.Location = new Point(30, 170);
            cboLocationToDelete.Name = "cboLocationToDelete";
            cboLocationToDelete.Size = new Size(87, 23);
            cboLocationToDelete.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(216, 40);
            label11.Name = "label11";
            label11.Size = new Size(66, 15);
            label11.TabIndex = 26;
            label11.Text = "LocationId:";
            // 
            // txtNewLocationId
            // 
            txtNewLocationId.Location = new Point(216, 58);
            txtNewLocationId.Name = "txtNewLocationId";
            txtNewLocationId.Size = new Size(91, 23);
            txtNewLocationId.TabIndex = 25;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F);
            label15.Location = new Point(193, 6);
            label15.Name = "label15";
            label15.Size = new Size(137, 21);
            label15.TabIndex = 27;
            label15.Text = "Add New Location";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(41, 6);
            label12.Name = "label12";
            label12.Size = new Size(126, 21);
            label12.TabIndex = 33;
            label12.Text = "Add New Sensor";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(btnRemoveLocationSensor);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtNewLocationCity);
            panel1.Controls.Add(btnAddLocationIdToSensor);
            panel1.Controls.Add(txtAddSensorId);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtNewLocationCountry);
            panel1.Controls.Add(cboActiveLocationId);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(cboActiveSensorId);
            panel1.Controls.Add(txtNewLocationId);
            panel1.Controls.Add(txtAddSensorType);
            panel1.Controls.Add(btnAddNewLocation);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnAddSensorToDB);
            panel1.Location = new Point(284, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 285);
            panel1.TabIndex = 34;
            // 
            // btnRemoveLocationSensor
            // 
            btnRemoveLocationSensor.Location = new Point(381, 176);
            btnRemoveLocationSensor.Name = "btnRemoveLocationSensor";
            btnRemoveLocationSensor.Size = new Size(94, 40);
            btnRemoveLocationSensor.TabIndex = 37;
            btnRemoveLocationSensor.Text = "Remove Location from Sensor";
            btnRemoveLocationSensor.UseVisualStyleBackColor = true;
            btnRemoveLocationSensor.Click += btnRemoveLocationSensor_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F);
            label16.Location = new Point(366, 6);
            label16.Name = "label16";
            label16.Size = new Size(171, 21);
            label16.TabIndex = 36;
            label16.Text = "Add Location to Sensor";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(30, 11);
            label13.Name = "label13";
            label13.Size = new Size(106, 21);
            label13.TabIndex = 35;
            label13.Text = "Delete Sensor";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Controls.Add(label14);
            panel2.Controls.Add(cboSensorToDelete);
            panel2.Controls.Add(btnDeleteSensor);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(btnDeleteLocation);
            panel2.Controls.Add(cboLocationToDelete);
            panel2.Controls.Add(label10);
            panel2.Location = new Point(828, 56);
            panel2.Name = "panel2";
            panel2.Size = new Size(160, 285);
            panel2.TabIndex = 35;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F);
            label14.Location = new Point(30, 134);
            label14.Name = "label14";
            label14.Size = new Size(117, 21);
            label14.TabIndex = 36;
            label14.Text = "Delete Location";
            // 
            // AddSensor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1009, 353);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(dgvDisplayLocation);
            Controls.Add(label3);
            Controls.Add(dgvActiveSensors);
            Name = "AddSensor";
            Text = "Congfigure data";
            ((System.ComponentModel.ISupportInitialize)dgvActiveSensors).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDisplayLocation).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAddSensorId;
        private TextBox txtAddSensorType;
        private Label label1;
        private Label label2;
        private DataGridView dgvActiveSensors;
        private Label label3;
        private Button btnAddSensorToDB;
        private DataGridView dgvDisplayLocation;
        private Label label4;
        private ComboBox cboActiveLocationId;
        private ComboBox cboActiveSensorId;
        private Button btnAddLocationIdToSensor;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cboSensorToDelete;
        private Button btnDeleteSensor;
        private Button btnAddNewLocation;
        private Label label8;
        private Label label9;
        private TextBox txtNewLocationCountry;
        private TextBox txtNewLocationCity;
        private Button btnDeleteLocation;
        private Label label10;
        private ComboBox cboLocationToDelete;
        private Label label11;
        private TextBox txtNewLocationId;
        private Label label15;
        private Label label12;
        private Panel panel1;
        private Label label13;
        private Panel panel2;
        private Label label14;
        private Label label16;
        private Button btnRemoveLocationSensor;
    }
}