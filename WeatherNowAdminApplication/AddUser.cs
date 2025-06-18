using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using WeatherNowApplication.Properties.ExternalCommunication;
using System.Data.SqlClient;
using System.Data;
using WeatherNowApplication.Properties.Config;

namespace WeatherNowApplication
{
    public partial class AddUser : Form
    {        

        private DatagridConfiguration dgvConfiguration;
        private ComboboxConfiguration cboConfiguration;
        private SQLCommands sqlCommands;
        private GUIConfig guiConfig;


        static Color startColor = Color.FromArgb(206, 150, 235, 225); // #96ebe1ce
        static Color middleColor = Color.FromArgb(180, 87, 199, 87);  // #57c757b4
        static Color endColor = Color.FromArgb(255, 235, 233, 129);

        public AddUser()
        {
            InitializeComponent();
            InitializeCustomUI();

            sqlCommands = new SQLCommands();
            string userConfig = sqlCommands.GetTypeConfig();
            dgvConfiguration = new DatagridConfiguration();
            cboConfiguration = new ComboboxConfiguration();
            guiConfig = new GUIConfig();
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



        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommands.AddNewUser(txtUserName, txtPassword, txtFirstname, txtSurname, cboRole);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            
        }

        private void InitializeCustomUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Image logo = Image.FromFile("Properties/img/Logo_transparent.png");
            Panel customTitleBar = GUIConfig.CreateCustomTitleBar(this, Color.DarkSlateGray, logo);

            this.Controls.Add(customTitleBar);
        }





    }
}
