using System.Linq;
using System.Threading.Tasks;
using WeatherNowWebApp.Models;
using WeatherNowWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace WeatherNowWebApp.Services
{
    public class UserService
    {
        private readonly WeatherNowDB _context;

        public UserService(WeatherNowDB context)
        {
            _context = context;
        }

        //check if a user exists with the given username and password
        public async Task<User> GetUserAsync(string username, string password)
        {
            // Retrieve user based on username
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            // Verify the password if the user exists
            if (user != null && user.Password == password) // Direct comparison for plain text
            {
                return user;
            }

            return null;
        }



        //check if a user exists with the given username
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        //create a new user
        public async Task CreateUserAsync(User user)
        {
            // Store password in plain text
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
