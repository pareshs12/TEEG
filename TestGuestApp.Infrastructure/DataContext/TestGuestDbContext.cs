using Microsoft.EntityFrameworkCore;
using TestGuestApp.Core.Entities;

namespace TestGuestApp.Infrastructure.DataContext
{
    public class TestGuestDbContext : DbContext
    {
        public TestGuestDbContext(DbContextOptions<TestGuestDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Guest>()
                .Property(g => g.PhoneNumbers)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(",", StringSplitOptions.None).ToList()
                );
        }
    }
}
