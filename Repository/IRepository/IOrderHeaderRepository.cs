using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
         void Update(OrderHeader obj);
        
         
    }
}
