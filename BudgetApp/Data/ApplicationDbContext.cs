using BudgetApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Zostawiamy tylko ten jeden, generyczny konstruktor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 1) relacja Family.CreatedByUser
            builder.Entity<Family>()
                .HasOne(f => f.CreatedByUser)
                .WithMany(u => u.FamiliesCreated)
                .HasForeignKey(f => f.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2) relacja ApplicationUser.Family <-> Family.Members
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Family)
                .WithMany(f => f.Members)
                .HasForeignKey(u => u.FamilyId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
