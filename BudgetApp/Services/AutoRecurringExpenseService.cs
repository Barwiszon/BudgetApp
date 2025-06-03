using Microsoft.EntityFrameworkCore;

public class AutoRecurringExpenseService : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly ILogger<AutoRecurringExpenseService> _logger;

    public AutoRecurringExpenseService(IServiceProvider services, ILogger<AutoRecurringExpenseService> logger)
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
            var now = DateTime.UtcNow;

            
            var all = await db.RecurringExpenses
                .Include(r => r.Account)
                .Where(r =>
                    r.StartDate <= now &&
                    (r.EndDate == null || r.EndDate >= now))
                .ToListAsync(stoppingToken);

            
            var toExecute = all
                .Where(r => r.LastExecutionDate == null ||
                            (now - r.LastExecutionDate.Value).TotalDays >= GetDays(r.Frequency))
                .ToList();

            foreach (var exp in toExecute)
            {
                var tx = new Transaction
                {
                    AccountId = exp.AccountId,
                    Amount = -exp.Amount,
                    Date = now,
                    Note = $"Automatyczny wydatek: {exp.Note}",
                    UserId = exp.UserId
                };

                exp.LastExecutionDate = now;

                db.Transactions.Add(tx);
            }

            await db.SaveChangesAsync(stoppingToken);
            _logger.LogInformation($"Wykonano automatyczne wydatki: {toExecute.Count}");

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
