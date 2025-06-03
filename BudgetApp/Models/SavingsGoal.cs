using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class SavingsGoal
    {
        public int Id { get; set; }

        
        public string UserId { get; set; } = null!;
        public ApplicationUser? User { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;  

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TargetAmount { get; set; }  

        [Column(TypeName = "decimal(18,2)")]
        public decimal SavedAmount { get; set; }   // Ile już odłożono

        [DataType(DataType.Date)]
        public DateTime? TargetDate { get; set; }  // Na kiedy chcemy osiągnąć cel

        public ICollection<SavingsDeposit> Deposits { get; set; } = new List<SavingsDeposit>();

        public bool IsShared { get; set; } = false; // Wspólny cel rodzinny

        public int? FamilyId { get; set; }          

        public Family? Family { get; set; }

        public bool AutoDepositEnabled { get; set; } = false;
        public decimal AutoDepositAmount { get; set; } 
        public int AutoDepositIntervalDays { get; set; } = 7;
        public DateTime? LastAutoDepositDate { get; set; }

        [NotMapped]
        public decimal DepositAmount { get; set; }
        public List<SavingsContribution>? Contributions { get; set; }


    }
}
