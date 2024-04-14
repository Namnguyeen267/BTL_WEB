using BTL_WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_WEB.Data
{
    public class DtbContext : DbContext
    {
        public DtbContext(DbContextOptions<DtbContext>options):base(options){ }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleID);
        }

    }
}
