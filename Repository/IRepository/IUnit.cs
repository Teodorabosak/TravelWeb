namespace TravelWeb.Repository.IRepository
{
    public interface IUnit
    {
        ICategoryRepository Category { get; }
        IDestinationRepository Destination{ get; }

        void Save();
    }
}
