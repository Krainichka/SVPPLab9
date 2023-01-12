using Lab9.DAL.Data;
using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab9.DAL.Repositories
{
    public class EfModelsRepository : IRepository<Model>
    {
        private readonly DbSet <Model> models;
        private readonly CarsContext carsContext1;
        public EfModelsRepository(CarsContext carsContext)
        {
            carsContext1 = carsContext;
            models = carsContext.Models;
        }

        public void Create(Model entity)
        {
            models.AddAsync(entity);
        }

        public bool Delete(int id)
        {
            var model = models.Find(id);
            if (model == null) return false;
            //почему не так удалять связь Б-М??????
            //model.Brand.Models.Remove(model.Brand.Models.First<Model>(m => m.Id == id));
            if (model.BrandId > 0)//если у модели есть бренд,то
            {
                carsContext1.Brands.Find(model.BrandId).Models.Remove(model);//удалить из DbSetBrand
            };
                models.Remove(model);//удалить из Model
                return true;
        }

    public IQueryable<Model> Find(Expression<Func<Model, bool>> predicate)
        {
           
            return models.Where(predicate);
        }

        public async Task<IEnumerable<Model>> FindAsync(Expression<Func<Model, bool>> predicate)
        {
            return await Task.Run(() => 
            {
                //Thread.Sleep(5000);
                 return models.Where(predicate);
            });
        }

        public Model Get(int id, params string[] includes)
        {
            IQueryable<Model> q = models;
            foreach (var include in includes)
                q = q.Include(include);
            return q.First(s => s.Id == id);
        }

        public IQueryable<Model> GetAll()
        {
            return models.AsQueryable();
        }

        public void Update(Model entity)
        {
            models.Update(entity);
        }
    }
}
