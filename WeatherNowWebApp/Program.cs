using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WeatherNowWebApp.Data;
using WeatherNowWebApp.Models;
using WeatherNowWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Legg til tjenester i containeren
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeFolder("/"); 
        options.Conventions.AllowAnonymousToPage("/Index");
    });


builder.Services.AddDbContext<WeatherNowDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherNowDB")));
builder.Services.AddScoped<UserService>();  


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim(ClaimTypes.Role, "0"));
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
