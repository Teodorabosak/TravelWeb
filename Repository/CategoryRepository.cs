using System.Linq.Expressions;
using TravelWeb.Data;
using TravelWeb.Models;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
           _context.Categories.Update(category);
        }
    }
}
