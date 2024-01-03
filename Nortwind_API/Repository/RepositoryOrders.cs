using Nortwind_API.Entities;
using System.Linq.Expressions;

namespace Nortwind_API.Repository
{
    public interface RepositoryOrders<Orders>
    {
        Task InsertAsync(Order entity);
        Task DeleteAsync(Order entity);
        Task<IList<Order>> SearchForAsync(Expression<Func<Order, bool>> predicate);
        // save entity, test via predicate if entity exists
        Task<bool?> SaveAsync(Order entity, Expression<Func<Order, bool>> predicate);
        Task<IList<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
    }
}
