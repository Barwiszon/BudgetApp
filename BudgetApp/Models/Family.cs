public class Family
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string CreatedByUserId { get; set; } = null!;

    public ApplicationUser CreatedByUser { get; set; } = null!;

    public ICollection<ApplicationUser> Members { get; set; } = new List<ApplicationUser>();

    public int FamilyId { get; set; }

    public ICollection<FamilyInvite> Invites { get; set; } = new List<FamilyInvite>();


}
