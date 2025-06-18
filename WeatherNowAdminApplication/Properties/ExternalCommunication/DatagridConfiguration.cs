using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WeatherNowApplication.Properties.ExternalCommunication
{
    internal class DatagridConfiguration : GUI
    {
        public void ViewDataGridView(string sqlQuery, string config, DataGridView dgv)
        {
            dgv.DataSource = null;
            ExecuteQuery(sqlQuery, config, dgv, null);
        }


        public void DgvEstetics(DataGridView dgv)
        {
            // Sett bakgrunnsfarger og andre estetiske detaljer
            dgv.BackgroundColor = Color.White;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(170, 255, 241);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(170, 255, 172);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersVisible = false;

            // Sett til Fill etter at dataene er lastet inn
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }








    }
}
