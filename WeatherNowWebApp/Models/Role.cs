using System.ComponentModel.DataAnnotations.Schema;
using WeatherNowWebApp.Models;

[Table("Role")] // Bruk riktig tabellnavn
public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }

    public ICollection<User> Users { get; set; }
}
