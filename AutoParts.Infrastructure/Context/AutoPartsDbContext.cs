using AutoParts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoParts.Infrastructure.Context
{
    public class AutoPartsDbContext : DbContext
    {
        public AutoPartsDbContext(DbContextOptions<AutoPartsDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(t => t.Id);
        }
    }
}