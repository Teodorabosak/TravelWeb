using System.Linq.Expressions;

namespace TravelWeb.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Category ili bilo koji drugi model nad kojim hocemo da vrsimo CRUD operacije
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
