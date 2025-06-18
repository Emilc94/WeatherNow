using System;

namespace WeatherNowWebApp.Models
{
    public class MeasurementSensorView
    {
        public int MeasurementId { get; set; }  // Primærnøkkel for måling
        public int SensorId { get; set; }       // Sensor-ID som målingen tilhører
        public string SensorType { get; set; }  // Typen sensor (for eksempel "Temperature", "Humidity", etc.)
        public float MeasurementData { get; set; } // Måledata (f.eks. temperaturverdi)
        public DateTime MeasurementTime { get; set; } // Tidspunkt for måling
    }
}
