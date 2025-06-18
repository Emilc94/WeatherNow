namespace WeatherNowWebApp.Models
{
    public class Location
    {
        public int LocationId { get; set; }  // Primærnøkkel for lokasjon
        public float Longitude { get; set; } // Lengdegrad
        public float Latitude { get; set; }  // Breddegrad
        public string? Country { get; set; }  // Land
        public string? City { get; set; }     // By

        // Navigasjonsfelt for sensorer på denne lokasjonen
        public ICollection<Sensor>? Sensors { get; set; }
    }
}
