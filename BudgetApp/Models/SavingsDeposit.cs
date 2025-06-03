using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class SavingsDeposit
    {
        public int Id { get; set; }

        [Required]
        public int SavingsGoalId { get; set; }
        public SavingsGoal? SavingsGoal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string? Note { get; set; }
        [NotMapped]
        public decimal DepositAmount { get; set; } = 0;
    }
}
