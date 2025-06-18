using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WeatherNowApplication.Properties.Config
{
    public class GUIConfig
    {

        //tabcontrol and Titlebar colors
        static Color TitleAndTabControllColor3 = Color.FromArgb(255, 210, 180, 140);
        static Color TitleAndTabControllColor2 = Color.FromArgb(255,255,255);  
        static Color TitleAndTabControllColor1 = Color.FromArgb(255, 139, 69, 19);  




        //GrowthNanny Theme Colors
        static Color startColor = Color.FromArgb(206, 150, 235, 225); // #96ebe1ce
        static Color middleColor = Color.FromArgb(180, 87, 199, 87);  // #57c757b4
        static Color endColor = Color.FromArgb(255, 235, 233, 129);



        //Color for the tab buttons
        static Color tabstartColor = Color.FromArgb(135, 206, 235);
        static Color tabmiddleColor = Color.FromArgb(176, 196, 222);
        static Color tabendColor = Color.FromArgb(211, 211, 211);  



        public static void DrawTabBackground(Graphics g, Rectangle tabRect)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(tabRect, startColor, endColor, LinearGradientMode.Vertical))
            {
                ColorBlend colorBlend = new ColorBlend(3);
                colorBlend.Colors = new Color[] { startColor, middleColor, endColor };
                colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f };

                brush.InterpolationColors = colorBlend;
                g.FillRectangle(brush, tabRect);
            }
        }


        //Creating the Tab
        public static void DrawTab(Graphics g, Rectangle tabRect)
        {
            using (LinearGradientBrush tabBrush = new LinearGradientBrush(tabRect, startColor, endColor, LinearGradientMode.Vertical))
            {

                ColorBlend colorBlend = new ColorBlend(3)
                {
                    Colors = new Color[] { tabstartColor, tabmiddleColor, tabendColor },
                    Positions = new float[] { 0.0f, 0.5f, 1.0f }
                };
                tabBrush.InterpolationColors = colorBlend;

                g.FillRectangle(tabBrush, tabRect);
            }


            using (Pen borderPen = new Pen(Color.White, 1.5f))
            {
                g.DrawRectangle(borderPen, tabRect);
            }
        }

        //Drawing text on Tab
        public static void DrawTabText(Graphics g, TabPage tabPage, Font font, Rectangle tabRect)
        {
            string tabText = tabPage.Text;
            SizeF textSize = g.MeasureString(tabText, font);
            PointF textPosition = new PointF(
                tabRect.X + (tabRect.Width - textSize.Width) / 2,
                tabRect.Y + (tabRect.Height - textSize.Height) / 2
            );
            g.DrawString(tabText, font, Brushes.Black, textPosition);
        }

        //Backgroundcolor behind the tabButtons
        public static void DrawTabControlBackground(Graphics g, Rectangle backgroundRect)
        {
            // Oppretter en gradient som går fra toppen av faneknappene ned til tab-bakgrunnen
            using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(backgroundRect, startColor, endColor, LinearGradientMode.Vertical))
            {
                ColorBlend colorBlend = new ColorBlend(3);
                colorBlend.Colors = new Color[] { startColor, middleColor, endColor };
                colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f };

                backgroundBrush.InterpolationColors = colorBlend;
                g.FillRectangle(backgroundBrush, backgroundRect);
            }
        }




        //Creating costum titlebar
        public static Panel CreateCustomTitleBar(Form form, Color borderColor, Image logo = null)
        {
            Panel titleBar = new Panel
            {
                Size = new Size(form.Width, 30), //titleline at 30px
                BackColor = Color.Transparent,
                Dock = DockStyle.Top
            };

            titleBar.Paint += (sender, e) =>
            {                
                Rectangle rect = new Rectangle(0, -form.Height / 10, form.Width, form.Height);

                using (LinearGradientBrush brush = new LinearGradientBrush(rect, TitleAndTabControllColor1, TitleAndTabControllColor2, LinearGradientMode.Vertical))
                {
                    ColorBlend colorBlend = new ColorBlend(3);
                    colorBlend.Colors = new Color[] { TitleAndTabControllColor1, TitleAndTabControllColor2, TitleAndTabControllColor3 };
                    colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f };
                    brush.InterpolationColors = colorBlend;

                    e.Graphics.FillRectangle(brush, titleBar.ClientRectangle);
                }

                
                Rectangle glossRect = new Rectangle(0, 0, titleBar.Width, titleBar.Height / 2);
                using (LinearGradientBrush glossBrush = new LinearGradientBrush(glossRect, Color.FromArgb(128, 255, 255, 255), Color.Transparent, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(glossBrush, glossRect);
                }

               
                string titleText = "WeatherNow";
                Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
                SizeF textSize = e.Graphics.MeasureString(titleText, titleFont);

                int logoWidth = 30;
                int logoMargin = 5; //text logo distance
                float textX = logoWidth + logoMargin; //Placeing text after the logo
                PointF textPosition = new PointF(textX, (titleBar.Height - textSize.Height) / 2);

                e.Graphics.DrawString(titleText, titleFont, Brushes.White, textPosition);
            };

            
            if (logo != null)
            {                
                PictureBox logoPictureBox = new PictureBox
                {
                    Size = new Size(25, 25),
                    Location = new Point(5, (titleBar.Height - 25) / 2), 
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = CreateCircularImage(logo)
                };

                titleBar.Controls.Add(logoPictureBox);
            }

            // Exit Button
            Button closeButton = new Button
            {
                Text = "x",
                ForeColor = Color.White,
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(35, 30),
                Location = new Point(form.ClientSize.Width - 35, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => form.Close();

            // Minimize Button
            Button minimizeButton = new Button
            {
                Text = "-",
                ForeColor = Color.White,
                BackColor = Color.LightSlateGray,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(35, 30),
                Location = new Point(form.ClientSize.Width - 71, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.Click += (s, e) => form.WindowState = FormWindowState.Minimized;

            form.Controls.Add(closeButton);
            form.Controls.Add(minimizeButton);
            titleBar.Controls.Add(closeButton);

            titleBar.MouseDown += (s, e) => OnTitleBarMouseDown(form, e);
            titleBar.MouseMove += (s, e) => OnTitleBarMouseMove(form, e);
            titleBar.MouseUp += (s, e) => OnTitleBarMouseUp();

            return titleBar;
        }

        // Method to make picture circular
        private static Image CreateCircularImage(Image img)
        {
            Bitmap circularImage = new Bitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(circularImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, img.Width, img.Height);
                g.SetClip(path);
                g.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            return circularImage;
        }

        //Moving the TitleBar
        private static bool isDragging = false;
        private static Point dragStartPoint;

        private static void OnTitleBarMouseDown(Form form, MouseEventArgs e)
        {
            isDragging = true;
            dragStartPoint = e.Location;
        }

        private static void OnTitleBarMouseMove(Form form, MouseEventArgs e)
        {
            if (isDragging)
            {
                form.Location = new Point(form.Left + e.X - dragStartPoint.X, form.Top + e.Y - dragStartPoint.Y);
            }
        }

        private static void OnTitleBarMouseUp()
        {
            isDragging = false;
        }


        public static void StyleGrayGradientRoundedButton(Button btn, int borderRadius)
        {
            // Sett grunnleggende knappestil
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.Black;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btn.BackColor = Color.Transparent; // Gjør bakgrunnen transparent for å vise gradienten

            // Opprett en avrundet region for knappen
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(btn.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(btn.Width - borderRadius, btn.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, btn.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);

            // Variabler for hover-effekt
            bool isHovering = false;

            // Hover-effekt
            btn.MouseEnter += (s, e) =>
            {
                isHovering = true;
                btn.Invalidate(); 
            };

            btn.MouseLeave += (s, e) =>
            {
                isHovering = false;
                btn.Invalidate(); 
            };

            
            btn.Paint += (s, e) =>
            {                
                Color gradientStart = isHovering ? Color.FromArgb(180, 105, 130, 160) : Color.FromArgb(200, 173, 216, 230);
                Color gradientEnd = isHovering ? Color.FromArgb(180, 60, 90, 120) : Color.FromArgb(200, 255, 255, 255); 

                
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, gradientStart, gradientEnd, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }

                // Tegn teksten på knappen
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
        }




    }
}

