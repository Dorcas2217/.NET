using SchoolApp.Models;
using SchoolApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.UnitOfWork
{
    class UnitOfWorkMem : IUnitOfWorkSchool
    {
        private SectionRepositoryMem  sectionRepositoryMem;

        public UnitOfWorkMem(SectionRepositoryMem sectionRepositoryMem)
        {
            this.sectionRepositoryMem = sectionRepositoryMem;
        }
    
        public IRepository<Section> SectionRepository
        {
            get { return this.sectionRepositoryMem; }
        }

        public IRepository<Student> StudentRepository => throw new NotImplementedException();
    }
}
