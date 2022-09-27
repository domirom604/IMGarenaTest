using MatchDataManager.Api.Database;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Team> TeamTable { get; set; }
        public DbSet<Location> LocationTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=E:\Users\dromanow\WPF_app_learn\MatchDataManager.Api\Database\Database.db");

        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Name=Database");
        // changing database source is necessary

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.IdKey);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.CoachName).HasMaxLength(55);

                entity.HasData(new Team
                {
                    IdKey = 1,
                    Id= new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),
                    Name = "domi",
                    CoachName = "elon"

                });;

            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.IdKey);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.City).HasMaxLength(55);

                entity.HasData(new Location
                {
                    IdKey = 1,
                    Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857799"),
                    Name = "emi",
                    City = "poznan"

                }); ;

            });
        }
    }
}
