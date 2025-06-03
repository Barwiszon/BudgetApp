using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class FamilyTransfer
    {
        public int Id { get; set; }

        [Required]
        public string FromUserId { get; set; } = null!;
        public ApplicationUser FromUser { get; set; } = null!;

        [Required]
        public string ToUserId { get; set; } = null!;
        public ApplicationUser ToUser { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int FamilyId { get; set; }
        public Family Family { get; set; } = null!;
    }
}
