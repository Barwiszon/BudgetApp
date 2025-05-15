using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Balance { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
