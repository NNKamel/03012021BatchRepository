using Microsoft.EntityFrameworkCore;
using models;
// using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class memeSaverContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Meme> Memes { get; set; }
        public DbSet<LikesJunction> LikesJunction { get; set; }

        public memeSaverContext(DbContextOptions<memeSaverContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:03012021-temp-server.database.windows.net,1433;Initial Catalog=tempMemeDB;Persist Security Info=False;User ID=tempserveradmin;Password=!q128800777;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LikesJunction>()
                .HasKey(c => new { c.PersonId, c.MemeId });
        }
    }
}