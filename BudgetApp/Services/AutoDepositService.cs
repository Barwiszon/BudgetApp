using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services
{
    public class AutoDepositService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<AutoDepositService> _logger;

        public AutoDepositService(IServiceProvider services, ILogger<AutoDepositService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var now = DateTime.Now;

                var allGoals = await db.SavingsGoals
                    .Where(g => g.AutoDepositEnabled)
                    .ToListAsync(stoppingToken);

                var goals = allGoals
                    .Where(g =>
                        !g.LastAutoDepositDate.HasValue ||
                        (now - g.LastAutoDepositDate.Value).TotalDays >= g.AutoDepositIntervalDays)
                    .ToList();


                foreach (var goal in goals)
                {
                    var deposit = new SavingsDeposit
                    {
                        SavingsGoalId = goal.Id,
                        Amount = goal.AutoDepositAmount,
                        Date = now
                    };

                    db.SavingsDeposits.Add(deposit);
                    goal.SavedAmount += goal.AutoDepositAmount;
                    goal.LastAutoDepositDate = now;

                    _logger.LogInformation($"Auto-wpłata {deposit.Amount} zł na cel '{goal.Name}'");
                }

                await db.SaveChangesAsync(stoppingToken);

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
