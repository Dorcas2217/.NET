using Microsoft.EntityFrameworkCore;
using Nortwind_API.Entities;
using Repository;

namespace Nortwind_API.UnitsOfWork
{
    public class UnitOfWorkSQL : IUnitOfWork
    {
        public readonly NorthwindContext NorthwindContext;
        public BaseRepositorySQL<Employee> _employesRepository;

        public UnitOfWorkSQL(NorthwindContext context)
        {
            this.NorthwindContext = context;
            this._employesRepository = new BaseRepositorySQL<Employee>(NorthwindContext);
        }

        public IRepository<Employee> employesRepository => _employesRepository;
    }
}
