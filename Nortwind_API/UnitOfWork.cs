using Nortwind_API.Entities;

namespace Nortwind_API
{
    public class UnitOfWork 
    {
        private readonly Employee _context;

        public UnitOfWork()
        {
            _context = new Employee();
        }

    }

}
