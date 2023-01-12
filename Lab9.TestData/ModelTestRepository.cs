using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.TestData
{
    public class ModelTestRepository : IRepository<Model>
    {
        private readonly List<Model> _models;

        public ModelTestRepository(List<Model> models)
        {
            _models = models;
        }

        public void Create(Model entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Model> Find(Expression<Func<Model, bool>> predicate)
        {
            Func<Model, bool> filter = predicate.Compile();
            return _models.Where(filter).AsQueryable();

        }

        public Task<IEnumerable<Model>> FindAsync(Expression<Func<Model, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Model Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Model entity)
        {
            throw new NotImplementedException();
        }
    }
}
