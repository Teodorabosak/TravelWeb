using System.Linq.Expressions;
using TravelWeb.Data;
using TravelWeb.Models;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Repository
{
    public class DestinationRepository : Repository<Destination>, IDestinationRepository
    {
        private ApplicationDbContext _context;
       
        public DestinationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public void Update(Destination destination)
        {
            _context.Destinations.Update(destination);
        }
    }
}