using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Credit.Repositories.Models
{
    public partial class CreditDefinitionsDemoContext : DbContext
    {
        public CreditDefinitionsDemoContext()
        {
        }

        public CreditDefinitionsDemoContext(DbContextOptions<CreditDefinitionsDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditRange> CreditRanges { get; set; }
        public virtual DbSet<InterestRange> InterestRanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=credit.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditRange>(entity =>
            {
                entity.HasKey(k => k.Id);

                entity.Property(e => e.AmountFrom)
                    .IsRequired();

                entity.Property(e => e.AmountTo)
                    .IsRequired();

                entity.Property(e => e.IsAvailable)
                    .IsRequired();
            });

            modelBuilder.Entity<InterestRange>(entity =>
            {
                entity.HasKey(k => k.Id);

                entity.Property(e => e.AmountFrom)
                    .IsRequired();

                entity.Property(e => e.AmountTo)
                    .IsRequired();

                entity.Property(e => e.InterestRate)
                    .IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
