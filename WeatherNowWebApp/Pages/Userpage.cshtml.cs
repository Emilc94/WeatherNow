using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WeatherNowWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WeatherNowWebApp.Pages
{
    [Authorize(Policy = "UserOnly")]
    public class UserpageModel : PageModel
    {
        private readonly ILogger<UserpageModel> _logger;
        private readonly IConfiguration _configuration;
        public List<MeasurementSensorView> LogDataList { get; set; }

        public UserpageModel(ILogger<UserpageModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            LogDataList = new List<MeasurementSensorView>();
        }


        public async Task<IActionResult> OnPostLogoutAsync()
        {
            Console.WriteLine("Admin Logout called");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Slett alle cookies relatert til autentisering
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // Oppdater cache-kontroll header på en trygg måte
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            HttpContext.Response.Headers["Pragma"] = "no-cache";
            HttpContext.Response.Headers["Expires"] = "0";

            return RedirectToPage("/Index");
        }





        public void OnGet()
        {
            // Hent tilkoblingsstrengen fra konfigurasjonen
            string connectionString = _configuration.GetConnectionString("WeatherNowDB");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT MeasurementId, SensorId, SensorType, MeasurementData, MeasurementTime FROM [dbo].[MeasurementSensorView]";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LogDataList.Add(new MeasurementSensorView
                            {
                                MeasurementId = reader.GetInt32(0),
                                SensorId = reader.GetInt32(1),
                                SensorType = reader.GetString(2),
                                MeasurementData = (float)reader.GetDouble(3),
                                MeasurementTime = reader.GetDateTime(4)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error fetching data: {Message}", ex.Message);
                }

            }







        }
    }
}
