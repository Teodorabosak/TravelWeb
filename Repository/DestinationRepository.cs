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
            var objDb = _context.Destinations.FirstOrDefault(u => u.Id == destination.Id);
            if(objDb != null)
            {
                objDb.Name = destination.Name;
                objDb.Description = destination.Description;
                objDb.Price = destination.Price;
                objDb.Date2 = destination.Date2;
                objDb.Date1 = destination.Date1;
                objDb.CategoryId = destination.CategoryId;
                objDb.Hotel = destination.Hotel;

                if(destination.ImageUrl != null)
                {
                    objDb.ImageUrl = destination.ImageUrl;
                }
            }
        }
    }
}