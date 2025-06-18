using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherNowWebApp.Models
{
    [Table("USER")]
    public class User
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }  // Brukernavn

        public string? Password { get; set; }  // Passord

        public string? Firstname { get; set; } // Fornavn

        public string? Surname { get; set; }   // Etternavn

        public int RoleId { get; set; } // Fremmednøkkel til Role       
    }
}
