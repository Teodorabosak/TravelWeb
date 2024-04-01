using TravelWeb.Data;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Repository
{
    public class Unit : IUnit
    {
        private ApplicationDbContext _context;
        public Unit(ApplicationDbContext context) 
        { 
            _context = context;
            Category = new CategoryRepository(_context);
            Destination = new DestinationRepository(_context);
        }
        public ICategoryRepository Category {get; set;}

        public IDestinationRepository Destination { get; set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
