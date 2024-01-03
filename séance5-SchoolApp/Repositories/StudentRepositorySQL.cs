using Repository;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repositories
{
    class StudentRepositorySQL : BaseRepositorySQL<Student>
    {
        public StudentRepositorySQL(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}
