using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// DbContext + SQLite
var conn = builder.Configuration.GetConnectionString("DefaultConnection")
           ?? throw new InvalidOperationException("Connection string not found.");
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlite(conn));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Identity + domyślne UI + EF stores
builder.Services
    .AddDefaultIdentity<ApplicationUser>(opts => opts.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Blazor Server + AuthenticationState
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



// dummy email sender (Identity.UI wymaga IEmailSender)
builder.Services.AddSingleton<IEmailSender, NullEmailSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();             // /Identity/Account/...
app.MapBlazorHub();              // SignalR Blazor
app.MapFallbackToPage("/_Host"); // host-page

app.Run();

public class NullEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
        => Task.CompletedTask;
}
