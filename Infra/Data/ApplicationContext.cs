using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.BaseCurrency).IsRequired().HasMaxLength(3);
                builder.Property(e => e.Currency).IsRequired().HasMaxLength(3);
                builder.Property(e => e.Amount).HasColumnType("decimal(18,4)");
                builder.Property(e => e.Date)
                    .HasColumnType("date");

                builder.HasIndex(e => new { e.Date, e.BaseCurrency,  e.Currency })
                    .IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
