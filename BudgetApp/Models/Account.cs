using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public int? FamilyId { get; set; }
        public Family? Family { get; set; }
        

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

    }
}
