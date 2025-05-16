// Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace BudgetApp.Models
{


    public class ApplicationUser : IdentityUser
    {
        
        public int? FamilyId { get; set; }
        public Family? Family { get; set; }
        public ICollection<Family> FamiliesCreated { get; set; } = new List<Family>();
    }   

}
