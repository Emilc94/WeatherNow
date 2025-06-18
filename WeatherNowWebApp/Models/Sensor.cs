using System.Diagnostics.Metrics;
using WeatherNowWebApp.Models;

namespace WeatherNowWebApp.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }    // Primærnøkkel for sensor
        public string? SensorType { get; set; } // Type sensor (f.eks. temperatur)

        // Fremmednøkkel for lokasjon
        public int LocationId { get; set; }  // FK til Location
        public Location? Location { get; set; } // Navigasjonsfelt for lokasjon

        // Navigasjonsfelt for målinger
        public ICollection<MEASUREMENT>? Measurements { get; set; }
        public ICollection<UserData>? UserData { get; set; }  // Navigasjonsfelt for tilknytning til UserData
    }
}
