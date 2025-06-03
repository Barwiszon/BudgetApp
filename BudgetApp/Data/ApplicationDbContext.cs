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
        public DbSet<RecurringIncome> RecurringIncomes { get; set; } = null!;
        public DbSet<PiggyBank> PiggyBanks { get; set; }
        public DbSet<SavingsGoal> SavingsGoals { get; set; }
        public DbSet<SavingsDeposit> SavingsDeposits { get; set; }
        public DbSet<RecurringExpense> RecurringExpenses { get; set; } = null!;
        public DbSet<FamilyTransfer> FamilyTransfers { get; set; } = null!;
        public DbSet<SavingsContribution> SavingsContributions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SavingsGoal>()
                .HasOne(g => g.User)
                .WithMany()
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SavingsDeposit>()
                .HasOne(d => d.SavingsGoal)
                .WithMany(g => g.Deposits)
                .HasForeignKey(d => d.SavingsGoalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SavingsContribution>()
                .HasOne(sc => sc.SavingsGoal)
                .WithMany(g => g.Contributions)
                .HasForeignKey(sc => sc.SavingsGoalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Family>()
                .HasOne(f => f.CreatedByUser)
                .WithMany(u => u.FamiliesCreated)
                .HasForeignKey(f => f.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

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

            builder.Entity<RecurringIncome>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RecurringIncome>()
                .HasOne(r => r.Account)
                .WithMany()
                .HasForeignKey(r => r.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<FamilyTransfer>()
                .HasOne(t => t.FromUser)
                .WithMany()
                .HasForeignKey(t => t.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FamilyTransfer>()
                .HasOne(t => t.ToUser)
                .WithMany()
                .HasForeignKey(t => t.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FamilyTransfer>()
                .HasOne(t => t.Family)
                .WithMany()
                .HasForeignKey(t => t.FamilyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
