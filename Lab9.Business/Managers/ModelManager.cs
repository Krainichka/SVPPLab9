using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Business.Managers
{
    public class ModelManager : BaseManager
    {
        public ModelManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #region bacic CRUD operations 
        public bool DeleteModel(int id)
        {
            var result = modelRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }
        public IEnumerable<Model> FindModel(Expression<Func<Model, bool>> predicate) =>
        modelRepository.Find(predicate);
        public Model GetModeltById(int id) => modelRepository.Get(id);
        public IEnumerable<Model> GetAllModels() =>modelRepository.GetAll();
        public void UpDateModel(Model model)
        {
            modelRepository.Update(model);
            unitOfWork.SaveChanges();
        }
        #endregion
    }
}
