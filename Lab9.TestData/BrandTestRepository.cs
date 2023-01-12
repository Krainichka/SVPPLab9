using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9.TestData
{
    public class BrandTestRepository : IRepository<Brand>
    {
        private readonly List <Brand> brands;

        public BrandTestRepository(List<Brand> brands)
        {
            this.brands = brands;
            SetupData();
        }

        /// Метод, генерирующий тестовые данные
        
        private void SetupData()
        {
            Random r = new Random();
            int s = 1;
            for (var i = 1; i <= 5; i++)
            {
                var brand = new Brand
                {
                    Amount = r.Next(500, 1000),
                    Name = $"Производитель {i}",
                    FoundationDate= DateTime.Now-TimeSpan.FromDays(r.Next(1000,40000)),
                    Id = i
                };
                var models = new List<Model>();
                for (var j = 0; j < 9; j++)
                {
                    models.Add(new Model
                    {
                        BrandId = i,
                        IssueDate = new DateTime(new Random().Next(2017,2022),new Random().Next(1,12),1),
                        Name = $"модель авто {s}",// посмотреть
                        Id = s++,
                        Price = r.Next(100,1000)
                        
                    });
                }
                brand.Models = models;
                brands.Add(brand);
            }
        }


        public void Create(Brand entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brand> Find(Expression<Func<Brand, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int id, params string[] includes)
        {
            return brands.FirstOrDefault(b => b.Id == id);

        }

        public IQueryable<Brand> GetAll()
        {
            return brands.AsQueryable();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brand>> FindAsync(Expression<Func<Brand, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
