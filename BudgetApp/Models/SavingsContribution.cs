using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class SavingsContribution
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int SavingsGoalId { get; set; }

        [ForeignKey(nameof(SavingsGoalId))]
        public SavingsGoal SavingsGoal { get; set; } = null!;
        public DateTime Date { get; set; }

    }
}
