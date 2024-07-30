
using Nortwind_API.Entities;
using Repository;

namespace Nortwind_API.UnitsOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Employee> employesRepository { get; }

    }

}
