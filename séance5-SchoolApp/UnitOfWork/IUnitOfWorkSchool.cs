using SchoolApp.Models;
using SchoolApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.UnitOfWork
{
     interface IUnitOfWorkSchool 
    {
        IRepository<Section> SectionRepository { get; }
        IRepository<Student> StudentRepository { get; }
    }
}
