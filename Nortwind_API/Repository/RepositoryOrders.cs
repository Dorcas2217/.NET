using Nortwind_API.Entities;
using Repository;
using System.Linq.Expressions;

namespace Nortwind_API.Repository
{
    public class RepositoryOrders : BaseRepositorySQL<Order>
    {
        public RepositoryOrders(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
