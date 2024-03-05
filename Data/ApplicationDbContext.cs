using Microsoft.EntityFrameworkCore;
using TravelWeb.Models;

namespace TravelWeb.Data
{
    public class ApplicationDbContext : DbContext //nasledjuje iz DbContext klase, koju smo dodali putem nugget-a
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Letovanje", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Gradovi Europe", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Putovanja za mlade", DisplayOrder = 3 },
                 new Category { Id = 4, Name = "Egzotična putovanja", DisplayOrder = 4 }
                );
        }
    }
}
