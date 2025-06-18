using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WeatherNowApplication.Properties.ExternalCommunication;
using WeatherNowApplication.Properties.Config;

namespace WeatherNowApplication
{
    public partial class Form1 : Form
    {
        private DatagridConfiguration dgvConfiguration;
        private ComboboxConfiguration cboConfiguration;
        private SQLCommands sqlCommands;
        private GUIConfig guiConfig;
        private DatagridConfiguration dgvConfig;

        private string ConnectionString => ConfigurationManager.ConnectionStrings["WeatherNowDB"].ConnectionString;

        string viewUser = @"SELECT UserId FROM [USER]";
        string viewSensor = @"SELECT SensorId FROM SENSOR";
        string viewUserSensor = @"SELECT * dbo.MeasurementLocationView";
        string viewMeasurement = @"SELECT MeasurementId FROM MEASUREMENT";

        public Form1()
        {
            InitializeComponent();
            InitializeCustomUI();

            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.FormBorderStyle = FormBorderStyle.None;

            sqlCommands = new SQLCommands();
            dgvConfiguration = new DatagridConfiguration();
            cboConfiguration = new ComboboxConfiguration();
            guiConfig = new GUIConfig();
            dgvConfig = new DatagridConfiguration();

 

            try
            {
                RefreshGUI();
                dgvConfig.DgvEstetics(dgvUsers);
                dgvConfig.DgvEstetics(dgvSensors);
                dgvConfig.DgvEstetics(dgvMeasurement);
                dgvConfig.DgvEstetics(dgvAllMeasurement);
                dgvConfig.DgvEstetics(dgvUserData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldnt Fetch Data, Error: {ex.Message}");
            }
        }

        private void InitializeCustomUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Image logo = Image.FromFile("Properties/img/Logo_transparent.png");
            Panel customTitleBar = GUIConfig.CreateCustomTitleBar(this, Color.DarkSlateGray, logo);

            this.Controls.Add(customTitleBar);
        }





        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            Graphics g = e.Graphics;
            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            Rectangle backgroundRect = tabControl.ClientRectangle;

            GUIConfig.DrawTabControlBackground(g, backgroundRect);
            for (int i = 0; i < tabControl.TabCount; i++)
            {
                Rectangle currentTabRect = tabControl.GetTabRect(i);
                GUIConfig.DrawTab(g, currentTabRect);
                GUIConfig.DrawTabText(g, tabControl.TabPages[i], tabControl.Font, currentTabRect);
            }
        }

        private void tabUserManagement_Paint(object sender, PaintEventArgs e)
        {
            GUIConfig.DrawTabBackground(e.Graphics, tabUserManagement.ClientRectangle);
        }

        private void tabHelp_Paint(object sender, PaintEventArgs e)
        {
            GUIConfig.DrawTabBackground(e.Graphics, tabHelp.ClientRectangle);
        }

        public void RefreshGUI()
        {
            string sqlQueryUser = SQLCommands.GetUserQuery();
            string sqlQuerySensor = SQLCommands.GetSensorQuery();
            string sqlQueryMeasLocationView = SQLCommands.GetMeasLocationQuery();
            string sqlQueryUserData = SQLCommands.GetUserDataQuery();

            try
            {
                dgvConfiguration.ViewDataGridView(sqlQueryUser, ConnectionString, dgvUsers);
                dgvConfiguration.ViewDataGridView(sqlQuerySensor, ConnectionString, dgvSensors);
                dgvConfiguration.ViewDataGridView(sqlQueryMeasLocationView, ConnectionString, dgvAllMeasurement);
                dgvConfiguration.ViewDataGridView(sqlQueryUserData, ConnectionString, dgvUserData);
                EditDgvMeasColumnName(dgvAllMeasurement);

                cboUsersToDelete.Items.Clear();
                cboSensors.Items.Clear();
                cboSensorConnect.Items.Clear();
                cboUserConnect.Items.Clear();
                cboMeasureId.Items.Clear();

                cboConfiguration.FillComboBox(cboUsersToDelete, viewUser, ConnectionString);
                cboConfiguration.FillComboBox(cboUserConnect, viewUser, ConnectionString);
                cboConfiguration.FillComboBox(cboSensors, viewSensor, ConnectionString);
                cboConfiguration.FillComboBox(cboSensorConnect, viewSensor, ConnectionString);
                cboConfiguration.FillComboBox(cboMeasureId, viewMeasurement, ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldnt Fetch Data, Error: {ex.Message}");
            }

            dgvUsers.Refresh();
            dgvSensors.Refresh();
        }

        public static void OpenEmailClient(string recipientEmail, string subject = "", string body = "")
        {
            try
            {
                string mailtoUri = $"mailto:{recipientEmail}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
                Process.Start(new ProcessStartInfo(mailtoUri) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problems opening the email client: {ex.Message}", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

            sqlCommands.RemoveUser(cboUsersToDelete);
            RefreshGUI();


        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser addUserForm = new AddUser();
            addUserForm.ShowDialog();
            RefreshGUI();
        }

        private void btnAddSensor_Click(object sender, EventArgs e)
        {
            try
            {
                var addSensorForm = new AddSensor();
                addSensorForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteMeasurement_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMeasureId.SelectedIndex >= 0)
                {
                    sqlCommands.DeleteMeasurement(cboMeasureId);
                    RefreshGUI();
                    MessageBox.Show("Measurement Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("Please select a measurement ID to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting measurement: {ex.Message}");
            }
        }


        private void btnConnectSensor_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommands.AddSensorToUser(cboUserConnect, cboSensorConnect);
                cboUserConnect.Items.Clear();
                cboSensorConnect.Items.Clear();
                RefreshGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting sensor to user. Error message:", ex.Message);
            }
        }

        private void btnDisconnectSensor_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommands.RemoveSensorFromUser(cboUserConnect, cboSensorConnect);
                cboUserConnect.Items.Clear();
                cboSensorConnect.Items.Clear();
                RefreshGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting sensor to user. Error message:", ex.Message);
            }
        }


        private void btnEmilContact_Click(object sender, EventArgs e)
        {
            OpenEmailClient("254629@usn.no", "Regarding issues with WeatherNow");
        }

 
        private void EditDgvMeasColumnName(DataGridView dgv)
        {
            dgv.Columns["MeasurementId"].HeaderText = "MeasID";
            dgv.Columns["MeasurementData"].HeaderText = "Data";
            dgv.Columns["MeasurementTime"].HeaderText = "Time";
            dgv.Columns["SensorId"].HeaderText = "Sensor";
            dgv.Columns["LocationId"].HeaderText = "Location";
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            int sensorId = Convert.ToInt32(cboSensors.SelectedIndex + 1);
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("uspGetMeasurementsBySensorAndDate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@SensorId", sensorId);
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                MessageBox.Show("Rows collected: " + dataTable.Rows.Count);
                dgvMeasurement.DataSource = dataTable;
                EditDgvMeasColumnName(dgvMeasurement);
            }
        }

        private void OpenNexelPage()
        {
            string url = "https://web01.usn.no/~238193/";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open page: " + ex.Message);
            }
        }

        private void NeverGonnaGiveYouUp()
        {
            string url = "https://www.youtube.com/watch?v=b0Ib9ZXxvg0&ab_channel=RickrollDifferentLinknoads";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open page: " + ex.Message);
            }
        }

        private void picFacebook_Click(object sender, EventArgs e)
        {
            NeverGonnaGiveYouUp();
        }

        private void picInstagram_Click(object sender, EventArgs e)
        {
            NeverGonnaGiveYouUp();
        }

        private void picLinkNexelLogo_Click(object sender, EventArgs e)
        {
            OpenNexelPage();
        }

        private void linkNexelPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenNexelPage();
        }

        private void linkFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NeverGonnaGiveYouUp();
        }

        private void linkInstagram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NeverGonnaGiveYouUp();
        }

        private Size originalSize;
        private Point originalLocation;

        private void picMouseEvent_MouseEnter(object sender, EventArgs e, PictureBox pic)
        {
            originalSize = pic.Size;
            originalLocation = pic.Location;

            pic.Size = new Size((int)(originalSize.Width * 1.1), (int)(originalSize.Height * 1.1));
            pic.Location = new Point(originalLocation.X - (pic.Width - originalSize.Width) / 2,
                                     originalLocation.Y - (pic.Height - originalSize.Height) / 2);
            pic.BackColor = Color.Transparent;
        }

        private void picMouseEvent_MouseLeave(object sender, EventArgs e, PictureBox pic)
        {
            pic.Size = originalSize;
            pic.Location = originalLocation;
            pic.BackColor = Color.Transparent;
        }

        private void picFacebook_MouseEnter(object sender, EventArgs e)
        {
            picMouseEvent_MouseEnter(sender, e, picFacebook);
        }

        private void picFacebook_MouseLeave(object sender, EventArgs e)
        {
            picMouseEvent_MouseLeave(sender, e, picFacebook);
        }

        private void picLinkNexelLogo_MouseEnter(object sender, EventArgs e)
        {
            picMouseEvent_MouseEnter(sender, e, picLinkNexelLogo);
        }

        private void picLinkNexelLogo_MouseLeave(object sender, EventArgs e)
        {
            picMouseEvent_MouseLeave(sender, e, picLinkNexelLogo);
        }

        private void picInstagram_MouseEnter(object sender, EventArgs e)
        {
            picMouseEvent_MouseEnter(sender, e, picInstagram);
        }

        private void picInstagram_MouseLeave(object sender, EventArgs e)
        {
            picMouseEvent_MouseLeave(sender, e, picInstagram);
        }

        private void btnAddSensor_Click_1(object sender, EventArgs e)
        {
            AddSensor addSensorForm = new AddSensor();
            addSensorForm.ShowDialog();
            RefreshGUI();
        }
    }
}
