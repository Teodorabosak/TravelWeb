namespace TravelWeb.Repository.IRepository
{
    public interface IUnit
    {
        ICategoryRepository Category { get; }
        IDestinationRepository Destination{ get; }
        IBookingRepository Booking { get; }
        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}
