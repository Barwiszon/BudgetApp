using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        // true = wydatek, false = przychód
        public bool IsExpense { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
