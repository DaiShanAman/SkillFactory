using Module_25.Entities;
using Microsoft.EntityFrameworkCore;

namespace Module_25
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Module_25;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
