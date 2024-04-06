using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
         void Update(OrderDetail obj);
        
         
    }
}
