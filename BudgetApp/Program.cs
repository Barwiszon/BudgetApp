using BudgetApp.Data;
using BudgetApp.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;


using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


var conn = builder.Configuration.GetConnectionString("DefaultConnection")
           ?? throw new InvalidOperationException("Connection string not found.");
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlite(conn));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services
  .AddDefaultIdentity<ApplicationUser>(opts => opts.SignIn.RequireConfirmedAccount = false)
  .AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ChartDataService>();
builder.Services.AddSingleton<IEmailSender, NullEmailSender>();

builder.Services.AddHostedService<BudgetApp.Services.AutoDepositService>();

builder.Services.AddHostedService<RecurringExpenseService>();
builder.Services.AddHostedService<AutoRecurringExpenseService>();
builder.Services.AddScoped<BalanceService>();


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


public class NullEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
        => Task.CompletedTask;
}
