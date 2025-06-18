using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WeatherNowApplication.Properties.ExternalCommunication
{
    internal class ComboboxConfiguration : GUI
    {
        public void FillComboBox(ComboBox cboBox, string sqlQuery, string config)
        {
            ExecuteQuery(sqlQuery, config, null, cboBox);
            if (cboBox.Items.Count > 0)
            {
                cboBox.SelectedIndex = 0; 
            }
        }
    }
}
