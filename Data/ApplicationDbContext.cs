using Microsoft.EntityFrameworkCore;
using TravelWeb.Models;

namespace TravelWeb.Data
{
    public class ApplicationDbContext : DbContext //nasledjuje iz DbContext klase, koju smo uveli putem nugget-a
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Letovanje", DisplayOrder = 1, ImageUrl="" },
                new Category { Id = 2, Name = "Gradovi Europe", DisplayOrder = 2 , ImageUrl = "" },
                new Category { Id = 3, Name = "Putovanja za mlade", DisplayOrder = 3, ImageUrl = "" },
                 new Category { Id = 4, Name = "Egzotična putovanja", DisplayOrder = 4, ImageUrl = "" }
                );
            modelBuilder.Entity<Destination>().HasData(
               new Destination
               {
                   Id = 2,
                   Name = "Budimpesta",
                   Description = "Uživajte u čarima termalnih kupki, poput čuvenih Gellért kupki, gde možete opustiti tela u toplim izvorima pod elegantnim mozaicima. Za ljubitelje umetnosti, poseta Muzeju savremene umetnosti ili Mađarskoj nacionalnoj galeriji predstavlja priliku da se upoznate sa bogatom kulturnom baštinom grada.  Gurmani će uživati u mađarskoj kuhinji, probajući čuvene gulaše, paprikaš i slatke poslastice poput krempita. Ne zaboravite posetiti Veliko tržište kako biste istražili lokalne proizvode i suvenire.  Budimpešta takođe nudi dinamičan noćni život, sa širokim spektrom barova, klubova i restorana. Šetnja duž obala " +
                   "Dunava noću pruža romantičnu atmosferu, posebno kada su mostovi osvetljeni.",
                   Hotel = "Sheraton hotel",
                   Price = 120,
                   Date1 = new DateTime (2024, 3, 6, 12, 50, 0),
                   Date2 = new DateTime(2024, 3, 29, 0, 50, 0),
                   CategoryId = 2
               }

               );

        }
    }
}
