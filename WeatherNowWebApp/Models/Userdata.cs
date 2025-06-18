namespace WeatherNowWebApp.Models
{
    public class UserData
    {
        public int UserDataId { get; set; }  // Primærnøkkel for UserData

        // Fremmednøkkel for bruker
        public int UserId { get; set; }      // FK til User
        public User? User { get; set; }       // Navigasjonsfelt for bruker

        // Fremmednøkkel for sensor
        public int SensorId { get; set; }    // FK til Sensor
        public Sensor? Sensor { get; set; }   // Navigasjonsfelt for sensor

        public DateTime MeasureTime { get; set; }  // Tidspunkt for tilknytning/måling
    }
}
