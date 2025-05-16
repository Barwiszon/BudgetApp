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

// Identity + domyślne UI + EF Stores
builder.Services
    .AddDefaultIdentity<ApplicationUser>(opts => opts.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Blazor Server + uwierzytelnianie
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// „pusty” e-mail sender potrzebny dla Identity.UI
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

app.MapBlazorHub();              // Blazor SignalR
app.MapFallbackToPage("/_Host"); // strona hostująca Blazor

app.Run();

// Pomocnicza klasa no-op do wysyłki maili
public class NullEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
        => Task.CompletedTask;
}
