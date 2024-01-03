using System.Linq.Expressions;

namespace Nortwind_API.Repository
{
    public interface RepositoryEmployees<Employee>
    {
        Task InsertAsync(Employee entity);
        Task DeleteAsync(Employee entity);
        Task<IList<Employee>> SearchForAsync(Expression<Func<Employee, bool>> predicate);
        // save entity, test via predicate if entity exists
        Task<bool?> SaveAsync(Employee entity, Expression<Func<Employee, bool>> predicate);
        Task<IList<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
    }

}
