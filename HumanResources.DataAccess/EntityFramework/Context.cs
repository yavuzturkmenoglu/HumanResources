using HumanResources.Core.Constants;
using HumanResources.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.DataAccess.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Inventory> Equipments { get; set; }
        public DbSet<Education> Educations { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>().Property(p => p.Name)
                .HasMaxLength(Constraint.Database.User.NameMaxLenght)
                .IsRequired();

            modelBuilder.Entity<User>().Property(p => p.LastName)
                .HasMaxLength(Constraint.Database.User.LastNameMaxLenght)
                .IsRequired();
            #endregion

            #region Graduation
            modelBuilder.Entity<Education>().Property(p => p.Name)
                .HasMaxLength(Constraint.Database.Education.NameMaxLenght)
                .IsRequired();
            #endregion
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity)
                {
                    if (entry.State == EntityState.Added)
                        ((Entity)entry.Entity).CreatedAt = DateTime.UtcNow;

                    if (entry.State == EntityState.Modified)
                        ((Entity)entry.Entity).UpdatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
