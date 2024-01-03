using Repository;
using SchoolApp.Models;
using SchoolApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.UnitOfWork
{
    internal class UnitOfWorkSQL : IUnitOfWorkSchool
    {
        private readonly SchoolContext _context;
        private BaseRepositorySQL<Section> _sectionRepository;
        private BaseRepositorySQL<Student> _studentRepository;
        public UnitOfWorkSQL(SchoolContext context) 
        {
            this._context = context;
            this._sectionRepository = new BaseRepositorySQL<Section>(context);
            this._studentRepository = new BaseRepositorySQL<Student>(context);
        }

        public IRepository<Section> SectionRepository {  get { return  this._sectionRepository; } }

        public IRepository<Student> StudentRepository {  get { return this._studentRepository; } }
    }
}
