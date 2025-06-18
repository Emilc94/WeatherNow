using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WeatherNowApplication.Properties.ExternalCommunication
{
    public class GUI
    {
        protected void ExecuteQuery(string sqlQuery, string config, DataGridView dgv = null, ComboBox cboBox = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(config))
                {
                    using (SqlCommand sql = new SqlCommand(sqlQuery, conn))
                    {
                        conn.Open();

                        if (dgv != null)
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(sql))
                            {
                                DataTable datatable = new DataTable();
                                sda.Fill(datatable);
                                dgv.DataSource = datatable;
                            }
                        }
                        else if (cboBox != null)
                        {
                            using (SqlDataReader dr = sql.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    string retrievedTableValue = dr[0].ToString();
                                    cboBox.Items.Add(retrievedTableValue);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Feil ved kjøring av SQL-spørring '{sqlQuery}' med konfigurasjon '{config}': {ex.Message}");
            }
        }
    }
}
