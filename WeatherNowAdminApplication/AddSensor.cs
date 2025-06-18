using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WeatherNowApplication.Properties.ExternalCommunication;
using WeatherNowApplication.Properties.Config;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;

namespace WeatherNowApplication
{
    public partial class AddSensor : Form
    {

        private string ConnectionString => ConfigurationManager.ConnectionStrings["WeatherNowDB"].ConnectionString;

        private DatagridConfiguration dgvConfiguration;
        private ComboboxConfiguration cboConfiguration;
        private SQLCommands sqlCommands;
        private GUIConfig guiConfig;
        private DatagridConfiguration dgvConfig;


        static Color startColor = Color.FromArgb(206, 150, 235, 225); // #96ebe1ce
        static Color middleColor = Color.FromArgb(180, 87, 199, 87);  // #57c757b4
        static Color endColor = Color.FromArgb(255, 235, 233, 129);   // #ebe981


        string viewSensor = @"SELECT * FROM SENSOR";
        string viewLocation = @"SELECT * FROM LOCATION";


        public AddSensor()
        {
            InitializeComponent();
            InitializeCustomUI();

            // Initialiser objektene **før** de brukes
            sqlCommands = new SQLCommands();
            dgvConfiguration = new DatagridConfiguration();
            cboConfiguration = new ComboboxConfiguration();
            guiConfig = new GUIConfig();
            dgvConfig = new DatagridConfiguration();

            try
            {
                // Kall RefreshGUI etter at alle objektene er initialisert
                RefreshGUI();

                // Sett opp estetikk for DataGridViews
                dgvConfiguration.DgvEstetics(dgvActiveSensors);
                dgvConfiguration.DgvEstetics(dgvDisplayLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldnt Fetch Data, Error: {ex.Message}");
            }
        }

        private void AddSensor_Load(object sender, EventArgs e)
        {
            // Koble til event handlers her etter at alt er initialisert
            btnAddSensorToDB.Click += btnAddSensorToDB_Click;
            btnAddLocationIdToSensor.Click += btnAddLocationIdToSensor_Click;
            RefreshGUI();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Få grafikk-objektet
            Graphics g = e.Graphics;

            // Definer rektangelet som dekker hele formen
            Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);

            // Lag en lineær gradient med de tre fargene
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColor, endColor, 40f))
            {
                // Definer gradientens mellomfarge
                ColorBlend colorBlend = new ColorBlend(3);
                colorBlend.Colors = new Color[] { startColor, middleColor, endColor };
                colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f };
                brush.InterpolationColors = colorBlend;

                // Fyll bakgrunnen med gradienten
                g.FillRectangle(brush, rect);
            }
        }


        private void InitializeCustomUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Image logo = Image.FromFile("Properties/img/Logo_transparent.png");
            Panel customTitleBar = GUIConfig.CreateCustomTitleBar(this, Color.DarkSlateGray, logo);

            this.Controls.Add(customTitleBar);
        }



        public void RefreshGUI()
        {
            string sqlSensorQuery = @"SELECT SensorId, SensorType, LocationId FROM SENSOR";
            string sqlLocationQuery = @"SELECT LocationId, City, Country FROM LOCATION";
            string sqlLocationIdQuery = @"SELECT LocationId FROM LOCATION";

            try
            {
                // Oppdater DataGridView-er med de nyeste dataene fra databasen
                DataTable sensorTable = sqlCommands.GetDataTable(sqlSensorQuery, ConnectionString);
                dgvActiveSensors.DataSource = sensorTable;
                dgvActiveSensors.Refresh();

                DataTable locationTable = sqlCommands.GetDataTable(sqlLocationQuery, ConnectionString);
                dgvDisplayLocation.DataSource = locationTable;
                dgvDisplayLocation.Refresh();

                // Fyll ComboBox-er med de nyeste dataene
                cboActiveSensorId.Items.Clear();
                cboActiveLocationId.Items.Clear();
                cboLocationToDelete.Items.Clear();
                cboSensorToDelete.Items.Clear();

                cboConfiguration.FillComboBox(cboActiveSensorId, sqlSensorQuery, ConnectionString);
                cboConfiguration.FillComboBox(cboActiveLocationId, sqlLocationQuery, ConnectionString);
                cboConfiguration.FillComboBox(cboLocationToDelete, sqlLocationIdQuery, ConnectionString);
                cboConfiguration.FillComboBox(cboSensorToDelete, sqlSensorQuery, ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldnt Fetch Data, Error: {ex.Message}");
            }
        }






        private void btnAddSensorToDB_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommands.AddSensor(txtAddSensorId, txtAddSensorType);
                RefreshGUI();
            }
            catch (Exception)
            {

            }
        }

        private void btnAddLocationIdToSensor_Click(object sender, EventArgs e)
        {
            try
            {
                // Sjekk at begge ComboBox-kontroller har en valgt verdi
                if (cboActiveSensorId.SelectedIndex >= 0 && cboActiveLocationId.SelectedIndex >= 0)
                {

                    sqlCommands.AddLocationToSensor(cboActiveSensorId, cboActiveLocationId);
                    RefreshGUI();
                }
                else
                {
                    MessageBox.Show("Please choose both SensorId and LocationId.");
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnAddNewLocation_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtNewLocationId.Text) ||
                    string.IsNullOrWhiteSpace(txtNewLocationCountry.Text) ||
                    string.IsNullOrWhiteSpace(txtNewLocationCity.Text))
                {
                    MessageBox.Show("Please fill all elements.");
                    return;
                }

                sqlCommands.AddLocation(txtNewLocationId, txtNewLocationCountry, txtNewLocationCity);

                txtNewLocationId.Clear();
                txtNewLocationCountry.Clear();
                txtNewLocationCity.Clear();
                RefreshGUI();

            }
            catch (Exception)
            {

            }
        }


        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommands.DeleteLocation(cboLocationToDelete);
                RefreshGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Remove Sensor Connected To The Location First. Error: {ex.Message}");
            }

        }

        private void btnDeleteSensor_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommands.DeleteSensor(cboSensorToDelete);
                RefreshGUI();
            }
            catch (Exception)
            {

            }
        }

        private void btnRemoveLocationSensor_Click(object sender, EventArgs e)
        {
            try
            {
                // Sjekk at brukeren har valgt en SensorId
                if (cboActiveSensorId.SelectedIndex >= 0)
                {
                    sqlCommands.RemoveLocationFromSensor(cboActiveSensorId);
                    RefreshGUI();
                }
                else
                {
                    MessageBox.Show("Vennligst velg en SensorId for å fjerne lokasjon.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error with removal of location from sensor. Error: {ex.Message}");
            }
        }


    }
}
