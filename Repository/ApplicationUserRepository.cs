using System.Linq.Expressions;
using TravelWeb.Data;
using TravelWeb.Models;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

     
    }
}
