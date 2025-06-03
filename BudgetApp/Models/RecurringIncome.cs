using System;
using BudgetApp.Models;

namespace BudgetApp.Models
{
    public class RecurringIncome
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;
        public ApplicationUser? User { get; set; }

        public int AccountId { get; set; }
        public Account? Account { get; set; }

        public decimal Amount { get; set; }

        public string? Note { get; set; }

        public DateTime StartDate { get; set; }

        public RecurrenceFrequency Frequency { get; set; }
    }
}
