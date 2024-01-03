using Repository;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repositories
{
    class SectionRepositorySQL : BaseRepositorySQL<Section>
    {
        public SectionRepositorySQL(SchoolContext dbContext) : base(dbContext)
        {

        }
    }
}
