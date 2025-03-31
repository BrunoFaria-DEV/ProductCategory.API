﻿using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Entity;

namespace ProdutoCategory.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {}
    }
}