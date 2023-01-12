using Lab9.DAL.Data;
using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Lab9.DAL.Repositories
{
    public class EfBrandsRepository : IRepository<Brand>
    {
        private readonly DbSet<Brand> brands;

        public EfBrandsRepository(CarsContext carsContext)
        {
            brands = carsContext.Brands;
        }

        public void Create(Brand entity)
        {
            brands.Add(entity);
        }

        public bool Delete(int id)
        {
            var brand = brands.Find(id);
            if(brand != null)
            {
                brands.Remove(brand);
                return true;
            }
            else
            { return false; }
        }

        public IQueryable<Brand> Find(Expression<Func<Brand, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brand>> FindAsync(Expression<Func<Brand, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int id, params string[] includes) //разобрать
        {
            //Get(4) - хочу бренд с ид = 4
            /* 
             * 4
             * Volvo
             * 31-01-2000
             * 34546
             * моделей типа нет. null(0)
             * 
             */
            /* Get(4, "Models")
             * 4
             * Volvo
             * 31-01-2000
             * 34546
             * вытаскиваю список всех моделей у этого бренда
             */
            /* Get(4, "Models", "Models") 
             * 4
             * Volvo
             * 31-01-2000
             * 34546
             * вытаскиваю список всех моделей у этого бренда и менеджеров
             */
            //

            IQueryable<Brand> q = brands;
            foreach (var include in includes)// 1 элемент в массиве
                q = q.Include(include);

            return q.First(b => b.Id == id);
        }

        public IQueryable<Brand> GetAll()
        {
            return brands.AsQueryable();
        }

        public void Update(Brand entity)
        {
            brands.Update(entity);
        }
    }
}
