using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeatherNowWebApp.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminUserpageModel : PageModel
    {
        private readonly ILogger<AdminUserpageModel> _logger;

        public AdminUserpageModel(ILogger<AdminUserpageModel> logger)
        {
            _logger = logger;
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
        }
    }
}
