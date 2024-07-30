using Nortwind_API.Entities;
using Nortwind_API.Models;
using Repository;


namespace Nortwind_API.Repository
{
    public class RepositoryEmployees : BaseRepositorySQL<EmployeDTO>
    {
        public RepositoryEmployees(NorthwindContext dbContext) : base(dbContext)
        {

        }
    }

}
