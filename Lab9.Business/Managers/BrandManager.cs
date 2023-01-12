using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9.Business.Managers
{
    public class BrandManager : BaseManager
    {
        public BrandManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //получение общего списка производителей (Brand)
        public IEnumerable<Brand> Brands
        {
            get => brandRepository.GetAll();
        }

        // получение производителя по Id
        public Brand Get(int id) => brandRepository.Get(id);

        //создание производителя?????
        public Brand CreateBrand(Brand brand)
        {
            brandRepository.Create(brand);
            unitOfWork.SaveChanges();
            return brand;
        }

        // Добавление производителей  
        public void AddRange(List<Brand> brands)
        {
            brands.ForEach(b => brandRepository.Create(b));
            unitOfWork.SaveChanges();
        }
        // удаление производителя
        public bool DeleteGroup(int id)
        {
            var result = brandRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        //редактирование данных о производителе
        public void UpdateBrand(Brand brand)
        {
            brandRepository.Update(brand);
            unitOfWork.SaveChanges();
        }

        // добавление модели авто по производителю
        public void AddModelToBrand(Model model, int brandId)
        {
            var brand = brandRepository.Get(brandId);
            model.BrandId = brandId;
            if (model.Id <= 0)
                modelRepository.Create(model);
            else modelRepository.Update(model);
            unitOfWork.SaveChanges();
        }

        // удаление модели авто 
        public void RemoveModelFromBrand(Model model, int brandId)
        {
            var brand = brandRepository.Get(brandId, "Models");
            brand.Models.Remove(model);
            brandRepository.Update(brand);
            modelRepository.Update(model);
            unitOfWork.SaveChanges();
        }

        //получить список моделей по производителю (бренду)
        public ICollection<Model> GetModelOfBrand(int brandId) => modelRepository.Find(m => m.BrandId == brandId).ToList();
        public async Task<IEnumerable<Model>> GetModelsOfBrandAsync(int brandId) => await modelRepository.FindAsync(m => m.BrandId == brandId);

    }
}
