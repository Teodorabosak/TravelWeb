using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface IDestinationRepository :  IRepository<Destination>
    {
        void Update(Destination destination);
        //void Save(); ne zavisi od modela, globalna metoda , nalazi se u Unit 
    }
}
