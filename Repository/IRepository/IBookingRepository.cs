using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface IBookingRepository : IRepository<Booking>
    {
         void Update(Booking booking);

        int IncrementCount(Booking booking, int count);
        int DecrementCount(Booking booking, int count);
    }
}

