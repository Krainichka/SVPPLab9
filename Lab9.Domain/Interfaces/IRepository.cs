using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Domain.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>>predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>>predicate);

        TEntity Get(int id, params string[] includes);
        void Create(TEntity entity);
        void Update(TEntity entity);
        bool Delete(int id);

    }
}
