using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class RecurringExpense
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        public string? Note { get; set; }

        public RecurrenceFrequency Frequency { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "Data zakończenia musi być po dacie startu.")]
        public DateTime? EndDate { get; set; }

        public DateTime? LastProcessedDate { get; set; }
        public DateTime? LastExecutionDate { get; set; }
    }
}
