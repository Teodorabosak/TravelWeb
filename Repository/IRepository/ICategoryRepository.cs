using TravelWeb.Models;

namespace TravelWeb.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
         void Update(Category category);
         void Save();
    }
}
