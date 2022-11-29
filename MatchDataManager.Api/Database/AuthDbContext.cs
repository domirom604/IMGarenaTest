using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Data
{
    public class AuthDbContext : DbContext
    {
       
        public DbSet<Library> BookTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=E:\Users\dromanow\ASP.net library\MatchDataManager.Api\Database\Database.db");

        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Name=Database");
        // changing database source is necessary

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<Library>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.IdKey);
                entity.Property(e => e.BookName).HasMaxLength(255);
                entity.Property(e => e.Author).HasMaxLength(55);
                entity.Property(e => e.CityOfPublish).HasMaxLength(55);
                entity.Property(e => e.YearOFPublish).HasMaxLength(5);

                entity.HasData(new Library
                {
                    IdKey = 1,
                    Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857799"),
                    BookName = "New Story Book",
                    Author = "Alan Walk",
                    CityOfPublish = "Gliwice",
                    YearOFPublish = "2022"

                }); ;

            });
        }
    }
}
