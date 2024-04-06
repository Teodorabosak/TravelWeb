using System.Linq.Expressions;
using TravelWeb.Data;
using TravelWeb.Models;
using TravelWeb.Models.ViewModels;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
        public void Update(Booking booking)
        {
           _context.Bookings.Update(booking);
        }
        public int DecrementCount(Booking booking, int count)
        {
            booking.NumberOfPeople -= count;
            return booking.NumberOfPeople;
        }

        public int IncrementCount(Booking booking, int count)
        {
            booking.NumberOfPeople += count;
            return booking.NumberOfPeople;
        }
    }
}
