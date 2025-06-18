using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WeatherNowWebApp.Services;
using WeatherNowWebApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace WeatherNowWebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;

        public LoginModel(UserService userService)
        {
            _userService = userService;
            CreateUserError = string.Empty;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Firstname { get; set; }

        [BindProperty]
        public string Surname { get; set; }

        [BindProperty]
        public string NewUsername { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public int RoleId { get; set; }

        public string CreateUserError { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Use the asynchronous method to get the user
            var user = await _userService.GetUserAsync(Username, Password);



            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()) // Bruk `ClaimTypes.Role` og konverter `RoleId` til en string
            };




                // Create a claims identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Authenticate the user and create a cookie
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false, // Remember the user across sessions
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60) // Cookie duration
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Redirect based on user role
                if (user.RoleId == 1) // 1 representerer admin
                {
                    return RedirectToPage("AdminUserPage");
                }
                else if (user.RoleId == 0) // 0 representerer vanlig bruker
                {
                    return RedirectToPage("Userpage");
                }
                else
                {
                    return RedirectToPage("AccessDenied");
                }

            }
            else
            {
                // Login error
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }
        }


        public async Task<IActionResult> OnPostCreateUserAsync()
        {
            if (NewPassword != ConfirmPassword)
            {
                CreateUserError = "Passwords do not match.";
                return Page();
            }

            // Check if the username already exists
            var existingUser = await _userService.GetUserByUsernameAsync(NewUsername);
            if (existingUser != null)
            {
                CreateUserError = "Username already exists.";
                return Page();
            }

            // Create and save the new user
            var newUser = new User
            {
                UserName = NewUsername,
                Password = NewPassword, // This will be stored in plain text
                Firstname = Firstname,
                Surname = Surname,
                RoleId = 0  // Default to 'User' role
            };

            // Save the user
            await _userService.CreateUserAsync(newUser);

            // Redirect to the login page after successful creation
            return RedirectToPage("Index");
        }
    }
}
