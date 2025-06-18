namespace WeatherNowWebApp.Models
{
    public class MEASUREMENT
    {
        public int MeasurementId { get; set; }  // Primærnøkkel for måling
        public float MeasurementData { get; set; } // Måledata (f.eks. temperaturverdi)
        public DateTime MeasurementTime { get; set; } // Tidspunkt for måling
        
        public int SensorId { get; set; }       // FK til Sensor
        public Sensor? Sensor { get; set; }      // Navigasjonsfelt for sensor
    }
}
