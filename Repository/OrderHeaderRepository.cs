using System.Linq.Expressions;
using TravelWeb.Data;
using TravelWeb.Models;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _context;
        public OrderHeaderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
        public void Update(OrderHeader obj)
        {
           _context.OrderHeaders.Update(obj);
        }
		public void UpdateStatus(int id, string? paymentStatus = null)
		{
			var orderFromDb = _context.OrderHeaders.FirstOrDefault(u => u.Id == id);
			if (orderFromDb != null)
			{
				orderFromDb.PaymentStatus = paymentStatus;
				//_context.SaveChanges();
			}
		}
		public void UpdateStripePaymentID(int id, string sessionId, string paymentItentId)
		{
			var orderFromDb = _context.OrderHeaders.FirstOrDefault(u => u.Id == id);

			orderFromDb.SessionId = sessionId;
			orderFromDb.PaymentIntentId = paymentItentId;
		}
	}
}
