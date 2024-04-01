using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface IDestinationRepository : IRepository<Destination>
    {
         void Update(Destination destination);
         void Save();
    }
}
