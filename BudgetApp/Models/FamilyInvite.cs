using System;

namespace BudgetApp.Models
{
    public class FamilyInvite
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public int FamilyId { get; set; }
        public string Email { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public Family Family { get; set; } = null!;
        public bool Accepted { get; set; } = false;

    }
}
