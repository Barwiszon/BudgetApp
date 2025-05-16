// Models/Family.cs
public class Family
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    // to już masz, upewnij się że to string
    public string CreatedByUserId { get; set; } = null!;

    // nawigacja do autora
    public ApplicationUser CreatedByUser { get; set; } = null!;

    // jeśli będziesz trzymać członków rodziny w kolekcji:
    public ICollection<ApplicationUser> Members { get; set; } = new List<ApplicationUser>();

    public int FamilyId { get; set; }
    

  
}
