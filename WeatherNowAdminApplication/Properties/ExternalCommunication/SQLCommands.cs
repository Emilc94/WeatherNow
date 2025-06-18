using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WeatherNowApplication.Properties.ExternalCommunication;

namespace WeatherNowApplication
{
    public class SQLCommands : IExternalCommunication
    {
        private string ConnectionString => ConfigurationManager.ConnectionStrings["WeatherNowDB"].ConnectionString;

        public string GetTypeConfig()
        {
            return ConnectionString;
        }

        public static string GetUserQuery()
        {
            return @"SELECT * FROM [USER]";
        }

        public static string GetSensorIdQuery()
        {
            return @"SELECT * FROM SENSOR";
        }

        public static string GetLocationQuery()
        {
            return @"SELECT LocationId, City, Country FROM LOCATION";
        }

        public static string GetSensorQuery()
        {
            return @"SELECT * FROM SensorLocationView";
        }

        public static string GetMeasLocationQuery()
        {
            return @"SELECT * FROM MeasurementLocationView;";
        }

        public static string GetUserDataQuery()
        {
            return @"SELECT * FROM USERDATA";
        }


        public DataTable GetDataTable(string query, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }


        public bool ValidateUser(string username, string password)
        {      
            // SQL-spørring for å sjekke om brukeren finnes
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(1) FROM [USER] WHERE Username = @Username AND Password = @Password AND RoleId = 1";

                try
                {
                    
                     using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Legg til parameterne for å unngå SQL-injeksjon
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            connection.Open();

                            // Utfør spørringen og sjekk om brukeren finnes
                            int count = Convert.ToInt32(command.ExecuteScalar());

                            return count > 0; // Returner true hvis bruker eksisterer
                        }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error connection to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
            }
        }





        public void AddNewUser(TextBox txtusername, TextBox txtpassword, TextBox txtfirstname, TextBox txtsurname, ComboBox cborole)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text) ||
                string.IsNullOrEmpty(txtfirstname.Text) || string.IsNullOrEmpty(txtsurname.Text) ||
                string.IsNullOrEmpty(cborole.Text))
            {
                MessageBox.Show("All fields are required. Please fill out all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("uspAddNewUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@surname", txtsurname.Text);
                    cmd.Parameters.AddWithValue("@roleid", cborole.Text == "Admin" ? 1 : 0);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User is added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void RemoveUser(ComboBox cboBox)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRemoveUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (cboBox.SelectedIndex >= 0)
                        {
                            cmd.Parameters.AddWithValue("@userId", Convert.ToInt32(cboBox.Text));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User is deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No Element Chosen In ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sensor has to be removed from user before deleting!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void AddLocationToSensor(ComboBox cbosensorid, ComboBox cbolocationid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspAddLocationToSensor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Sjekk om tekstboksen og comboboksen ikke er tomme
                        if (cbosensorid.SelectedIndex >= 0 && cbolocationid.SelectedIndex >= 0)
                        {
                            cmd.Parameters.AddWithValue("@SensorId", Convert.ToInt32(cbosensorid.Text));
                            cmd.Parameters.AddWithValue("@LocationId", Convert.ToInt32(cbolocationid.Text));

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Location Updated For Sensor.");
                        }
                        else
                        {
                            MessageBox.Show("Ingen element valgt i ComboBox.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Adding Location To Sensor \r Error : {ex.Message}");
            }
        }


        public void RemoveLocationFromSensor(ComboBox cbosensorid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRemoveLocationFromSensor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Sjekk at en sensor er valgt fra ComboBox
                        if (cbosensorid.SelectedIndex >= 0)
                        {
                            cmd.Parameters.AddWithValue("@SensorId", Convert.ToInt32(cbosensorid.Text));

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Location Removed from Sensor.");
                        }
                        else
                        {
                            MessageBox.Show("Ingen Sensor valgt.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Removing Location from Sensor. Error: {ex.Message}");
            }
        }




        public void AddSensor(TextBox sensorid, TextBox sensortype)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspAddNewSensor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (sensorid.Text != null & sensortype.Text != null)
                        {
                            cmd.Parameters.AddWithValue("@SensorId", Convert.ToInt32(sensorid.Text));
                            cmd.Parameters.AddWithValue("@SensorType", sensortype.Text.ToString());
                            cmd.ExecuteNonQuery();
                            
                        }
                        else
                        {
                            MessageBox.Show("No Element Chosen In ComboBox.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Adding Sensor \r Error : {ex.Message}");
            }
        }



        public void AddSensorToUser(ComboBox cboUserId, ComboBox cboSensorId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspAddUserData", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (cboUserId.SelectedIndex >= 0)
                        {
                            cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(cboUserId.Text));
                            cmd.Parameters.AddWithValue("@Sensorid", Convert.ToInt32(cboSensorId.Text));
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("No Element Chosen In ComboBox.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Adding Sensor To User \r Error : {ex.Message}");
            }
        }

        public void RemoveSensorFromUser(ComboBox cboUserId, ComboBox cboSensorId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspDeleteUserSensor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (cboUserId.SelectedIndex >= 0)
                        {
                            cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(cboUserId.Text));
                            cmd.Parameters.AddWithValue("@Sensorid", Convert.ToInt32(cboSensorId.Text));
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("No Element Chosen In ComboBox.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Removing Sensor From User \r Error : {ex.Message}");
            }
        }

        public void AddLocation(TextBox locationId, TextBox country, TextBox city)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspAddLocation", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LocationId", Convert.ToInt32(locationId.Text));
                        cmd.Parameters.AddWithValue("@Country", country.Text);
                        cmd.Parameters.AddWithValue("@City", city.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New Location Added.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Adding To Location: {ex.Message}");
            }
        }


        public void DeleteLocation(ComboBox cbolocationId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspDeleteLocation", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LocationId", Convert.ToInt32(cbolocationId.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Location Deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error With Deleting Location. Make sure to disconnect sensor from location before deleting location");
            }
        }

        public void DeleteSensor(ComboBox cbosensorid)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("uspDeleteSensor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SensorId", Convert.ToInt32(cbosensorid.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sensor Deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error With Deleting Sensor: {ex.Message}");
            }
        }



        public void DeleteMeasurement(ComboBox cboMeasurementId)
        {
            try
            {
                if (cboMeasurementId.SelectedIndex >= 0)
                {
                    int measurementId = Convert.ToInt32(cboMeasurementId.SelectedItem); 

                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("uspDeleteMeasurement", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            
                            cmd.Parameters.AddWithValue("@MeasurementId", measurementId);

                            int rowsAffected = cmd.ExecuteNonQuery();                            
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a measurement ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting measurement: {ex.Message}");
            }
        }




    }
}
