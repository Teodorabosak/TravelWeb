using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface IBookingRepository : IRepository<Booking>
    {
         void Update(Booking booking);
        
         
    }
}
