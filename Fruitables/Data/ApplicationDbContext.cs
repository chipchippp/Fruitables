using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fruitables.Models;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Fruitables.Models.OrderProduct;

namespace Fruitables.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Fruitables.Models.Category> Category { get; set; } = default!;
        public DbSet<Fruitables.Models.Product> Product { get; set; } = default!;
        public DbSet<Fruitables.Models.Order> Order { get; set; } = default!;
        public DbSet<Fruitables.Models.OrderProduct> OrderProduct { get; set; } = default!;
    }
}
