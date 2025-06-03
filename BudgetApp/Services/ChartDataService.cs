using BudgetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services
{
    public class ChartDataService
    {
        private readonly ApplicationDbContext _context;

        public ChartDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, double>> GetSpendingByCategoryAsync()
        {
            return await _context.Transactions
                .Where(t => t.Amount < 0)
                .GroupBy(t => t.Category.Name ?? "(brak)")
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(t => (double)(-t.Amount))
                })
                .ToDictionaryAsync(x => x.Category, x => x.Total);
        }

        public async Task<Dictionary<DateTime, double>> GetSpendingOverTimeAsync()
        {
            return await _context.Transactions
                .Where(t => t.Amount < 0)
                .GroupBy(t => t.Date.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Total = g.Sum(t => (double)(-t.Amount))
                })
                .ToDictionaryAsync(x => x.Date, x => x.Total);
        }

        public async Task<Dictionary<string, double>> GetSpendingByUserAsync()
        {
            return await _context.Transactions
                .Where(t => t.Amount < 0)
                .GroupBy(t => t.User.Email ?? "(brak)")
                .Select(g => new
                {
                    UserEmail = g.Key,
                    Total = g.Sum(t => (double)(-t.Amount))
                })
                .ToDictionaryAsync(g => g.UserEmail, g => g.Total);
        }

        public async Task<double> GetAverageDailySpendingAsync()
        {
            var thirtyDaysAgo = DateTime.Today.AddDays(-30);
            var total = await _context.Transactions
                .Where(t => t.Amount < 0 && t.Date >= thirtyDaysAgo)
                .SumAsync(t => (double)(-t.Amount));

            return total / 30;
        }

        public async Task<double> GetMaxSpendingAsync()
        {
            return await _context.Transactions
                .Where(t => t.Amount < 0)
                .Select(t => (double)(-t.Amount))  
                .OrderBy(x => x)
                .FirstOrDefaultAsync();
        }


        public async Task<string> GetTopCategoryAsync()
        {
            return await _context.Transactions
                .Where(t => t.Amount < 0)
                .GroupBy(t => t.Category.Name ?? "(brak)")
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(t => (double)(-t.Amount))
                })
                .OrderByDescending(g => g.Total)
                .Select(g => g.Category)
                .FirstOrDefaultAsync() ?? "(brak)";
        }
    }
}
