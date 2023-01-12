using Lab9.DAL.Data;
using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.DAL.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly CarsContext context;
        private IRepository<Brand> brandsRepository;
        private IRepository<Model> modelsRepository;

        public EfUnitOfWork(string connectionStr)//??? выброс искл
        {
           var options = new DbContextOptionsBuilder<CarsContext>()
                .UseSqlServer(connectionStr)
                .Options;
           context = new CarsContext(options);
           context.Database.EnsureCreated();
        }

        public IRepository<Brand> BrandsRepository => brandsRepository ?? new EfBrandsRepository(context);

        public IRepository<Model> ModelsRepository => modelsRepository ?? new EfModelsRepository(context);
        public void SaveChanges()//вызывается именно у контекста
        {
           context.SaveChanges();
        }
    }
}
