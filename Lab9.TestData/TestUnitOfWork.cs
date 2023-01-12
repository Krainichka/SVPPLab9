using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9.TestData
{
    public class TestUnitOfWork : IUnitOfWork
    {
        private IRepository<Model> modelsRepository;
        private IRepository<Brand> brandsRepository;
        private List<Model> models;
        private List<Brand> brands;

        public TestUnitOfWork()
        {
            models= new List<Model>();
            brands= new List<Brand>();
            brandsRepository = new BrandTestRepository(brands);
            foreach(var brand in brands)
            {
                models.AddRange(brand.Models);              
            }
            modelsRepository = new ModelTestRepository(models);
        }

        public IRepository<Brand> BrandsRepository => brandsRepository;

        public IRepository<Model> ModelsRepository => modelsRepository;

        public void SaveChanges()
        {
           
        }
    }
}
