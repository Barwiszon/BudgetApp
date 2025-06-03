using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BudgetApp.Services
{
    public class RecurringExpenseService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RecurringExpenseService> _logger;

        public RecurringExpenseService(IServiceProvider serviceProvider, ILogger<RecurringExpenseService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var now = DateTime.Now;


                var candidates = await db.RecurringExpenses
                    .Where(r => r.StartDate <= now && (r.EndDate == null || r.EndDate >= now))
                    .ToListAsync(stoppingToken);


                var toExecute = candidates
                    .Where(r =>
                        r.LastExecutionDate == null ||
                        (now - r.LastExecutionDate.Value).TotalDays >= GetDays(r.Frequency))
                    .ToList();

                foreach (var expense in toExecute)
                {
                    db.Transactions.Add(new Transaction
                    {
                        AccountId = expense.AccountId,
                        UserId = expense.UserId,
                        Amount = -expense.Amount,
                        Date = now,
                        Note = expense.Note ?? "[Automatyczny wydatek]",
                        Category = null
                    });

                    expense.LastExecutionDate = now;
                }

                await db.SaveChangesAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }

        private int GetDays(RecurrenceFrequency frequency)
        {
            return frequency switch
            {
                RecurrenceFrequency.Weekly => 7,
                RecurrenceFrequency.Monthly => 30,
                _ => int.MaxValue 
            };
        }
    }
}
