using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        // …
        public int FamilyId { get; set; }
        public Family Family { get; set; } = null!;
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public string? Note { get; set; }
    }
}
