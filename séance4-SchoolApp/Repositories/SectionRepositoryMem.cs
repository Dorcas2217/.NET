using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repositories
{
     class SectionRepositoryMem : IRepository<Section>
    {
        private List<Section> _sections;
        public SectionRepositoryMem() { 
            _sections = new List<Section>();
            _sections.Add(new Section { Name = "section1"});
            _sections.Add(new Section { Name = "section2"});

        }

        public void Delete(Section entity)
        {
            if(_sections.Contains(entity))
            {
                _sections.Remove(entity);
            }           
        }

        public IList<Section> GetAll()
        {
            return _sections;
        }

        public Section GetById(int id)
        {
            return _sections[id];
        }

        public void Insert(Section entity)
        {
            _sections.Add(entity);
        }

        public bool Save(Section entity, Expression<Func<Section, bool>> predicate)
        {
            Section sectionFind =(SearchFor(predicate)).FirstOrDefault();

            if (sectionFind == null)
            {
                Insert(entity);
                return true;
            } 
            return false;
        }

        public IList<Section> SearchFor(Expression<Func<Section, bool>> predicate)
        {
            return _sections.AsQueryable().Where(predicate).ToList();       
        }

        public bool SectionExists(Expression<Func<Section, bool>> predicate)
        {
            return _sections.AsQueryable().Any(predicate);
        }
    }
}
