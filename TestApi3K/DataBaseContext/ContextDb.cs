using Microsoft.EntityFrameworkCore;
using TestApi3K.Model;

namespace TestApi3K.DataBaseContext
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<UsersRecord> UsersRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsersRecord>(entity =>
            {
                entity.HasIndex(ua => new { ua.id_Achievement, ua.id_User })
                      .IsUnique();
            });
        }
    }
}
