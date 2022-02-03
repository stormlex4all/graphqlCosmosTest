using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.Data
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions<CosmosDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(p =>
            {
                //p.HasKey(t => t.Id);
                p.Property(t => t.Name).IsRequired();
                p.Property(t => t.Description);
                p.HasNoDiscriminator()
                .ToContainer("Test")
                .HasPartitionKey(p => p.Id)
                .HasKey(p => new { p.Id });
            });
        }
    }
}
