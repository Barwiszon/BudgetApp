using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, Range(-1_000_000_000, 1_000_000_000)]
        [RegularExpression(@"^-?\d+(\.\d{1,2})?$")]
        public decimal Amount { get; set; }

        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Note { get; set; }
    }
}
