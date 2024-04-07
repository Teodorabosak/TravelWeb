using SQLitePCL;
using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
         void Update(OrderHeader obj);

		void UpdateStatus(int id, string? paymentStatus = null);
		void UpdateStripePaymentID(int id, string sessionId, string paymentItentId);

	}
}
