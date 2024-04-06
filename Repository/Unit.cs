using TravelWeb.Data;
using TravelWeb.Models;
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
            Booking = new BookingRepository(_context);
            ApplicationUser = new ApplicationUserRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);
            OrderHeader = new OrderHeaderRepository(_context);

        }
        public ICategoryRepository Category {get; private set;}

        public IDestinationRepository Destination { get; private set; }


        public IBookingRepository Booking { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }


            public void Save()
            {
                _context.SaveChanges();
            }
    }
}
