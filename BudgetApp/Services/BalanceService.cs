using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services
{
    public class BalanceService
    {
        private readonly ApplicationDbContext _context;

        public BalanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetCurrentBalanceAsync(int accountId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
            if (account == null)
                return 0;

            var transactions = await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .ToListAsync();

            decimal transactionSum = 0;
            foreach (var t in transactions)
            {
                switch (t.Type)
                {
                    case TransactionType.Income:
                        transactionSum += t.Amount;
                        break;
                    case TransactionType.Expense:
                        transactionSum -= t.Amount;
                        break;
                    case TransactionType.Transfer:
                        transactionSum += t.Amount;
                        break;
                }
            }

            return account.Balance + transactionSum;
        }

        public async Task<Dictionary<int, decimal>> GetCurrentBalancesAsync(IEnumerable<int> accountIds)
        {
            var accounts = await _context.Accounts
                .Where(a => accountIds.Contains(a.Id))
                .ToListAsync();

            var transactions = await _context.Transactions
                .Where(t => accountIds.Contains(t.AccountId))
                .ToListAsync();

            var result = new Dictionary<int, decimal>();

            foreach (var acc in accounts)
            {
                var relatedTx = transactions.Where(t => t.AccountId == acc.Id);
                decimal transactionSum = 0;

                foreach (var t in relatedTx)
                {
                    switch (t.Type)
                    {
                        case TransactionType.Income:
                            transactionSum += t.Amount;
                            break;
                        case TransactionType.Expense:
                            transactionSum -= t.Amount;
                            break;
                        case TransactionType.Transfer:
                            transactionSum += t.Amount;
                            break;
                    }
                }

                result[acc.Id] = acc.Balance + transactionSum;
            }

            return result;
        }
    }
}
