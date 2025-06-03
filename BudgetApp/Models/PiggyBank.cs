using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class PiggyBank
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser? User { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; } = 0;

        public string? Note { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? GoalDate { get; set; }
        [NotMapped]
        public decimal DepositAmount { get; set; } = 0;

        [NotMapped]
        public decimal WithdrawAmount { get; set; }
    }
}
    