using BudgetApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyInvite> Invites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 1) Kto utworzy³ Family
            builder.Entity<Family>()
                .HasOne(f => f.CreatedByUser)
                .WithMany(u => u.FamiliesCreated)
                .HasForeignKey(f => f.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2) Ka¿dy ApplicationUser mo¿e nale¿eæ do jednej Family
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Family)
                .WithMany(f => f.Members)
                .HasForeignKey(u => u.FamilyId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<FamilyInvite>()
                .HasKey(i => i.Id);

            builder.Entity<FamilyInvite>()
                .HasOne(i => i.Family)
                .WithMany(f => f.Invites)
                .HasForeignKey(i => i.FamilyId)
                .OnDelete(DeleteBehavior.Cascade);




            // (opcjonalnie) mo¿esz dodaæ konfiguracjê dla Account, Category, Transaction...
        }
    }
}
