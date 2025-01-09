using Microsoft.EntityFrameworkCore;
using schoollib_wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoollib_wpf
{
    class ApplicationContext : DbContext
    {
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AttachedBook> AttachedBooks { get; set; }

        public ApplicationContext()
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=schoollib-test.db");
        }
    }
}
