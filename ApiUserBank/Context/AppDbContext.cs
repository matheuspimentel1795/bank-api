using ApiUserBank.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiUserBank.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserBank> UserBank { get; set; }


        // Fluent Api

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<UserBank>().HasKey(c => c.Id);
            mb.Entity<UserBank>().Property(c => c.AccountNumber)
                .HasMaxLength(10)
                .IsRequired();
            mb.Entity<UserBank>().Property(c => c.AccountValue)
             .HasPrecision(12, 2)
            .IsRequired();


            mb.Entity<UserBank>().HasData(
                new UserBank
                {
                    Id = 1,
                    AccountNumber = 12345,
                    AccountValue = 100.00
                });
        }
        }
}
