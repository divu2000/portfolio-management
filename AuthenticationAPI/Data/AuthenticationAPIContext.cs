using Microsoft.EntityFrameworkCore;
using AuthenticationAPI.Data.Entities;

namespace AuthenticationAPI.Data
{
    public class AuthenticationAPIContext : DbContext
    {
        public AuthenticationAPIContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasData(
                    new User() { Id = 1, Username = "Admin", Password = "Admin"},
                    new User() { Id = 2, Username = "User", Password = "User"},
                    new User() { Id = 103, Username = "Arka", Password = "arka1234"}
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}
