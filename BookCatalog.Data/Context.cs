using BookCatalog.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookCatalog.Data
{
    public class Context: DbContext
    {
        public DbSet<Book> Book { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=BookCatalog;Trusted_Connection=True;");
        }
    }
}
