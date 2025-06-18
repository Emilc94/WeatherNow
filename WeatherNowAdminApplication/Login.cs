using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherNowApplication.Properties.Config;
using WeatherNowApplication;
using System.Drawing.Drawing2D;
using WeatherNowApplication.Properties.ExternalCommunication;

namespace WeatherNowApplication
{



    public partial class Login : Form
    {
        private GUIConfig guiConfig;
        private SQLCommands sqlConfig;

        static Color startColor = Color.FromArgb(206, 150, 235, 225); // #96ebe1ce
        static Color middleColor = Color.FromArgb(180, 87, 199, 87);  // #57c757b4
        static Color endColor = Color.FromArgb(255, 235, 233, 129);   // #ebe981


        public Login()
        {
            InitializeComponent();
            InitializeCustomUI();

            guiConfig = new GUIConfig();
            sqlConfig = new SQLCommands();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                // Sjekk om feltene er fylt ut
                if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please write both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kall metoden for å sjekke brukerens legitimasjon
                if (sqlConfig.ValidateUser(user, password))
                {
                    MessageBox.Show("Login approved", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Åpne hovedskjermen eller fortsett med applikasjonen
                    this.Hide();
                    Form1 mainForm = new Form1();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Wrong username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Experiencing trouble connection to database, Error:" + ex);;
            }
        }




    }
}
