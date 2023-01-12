using Lab9.Domain.Entities;
using Lab9.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Business.Managers
{
    public class BaseManager
    {
        protected readonly IRepository<Brand> brandRepository;
        protected readonly IRepository<Model> modelRepository;
        protected readonly IUnitOfWork unitOfWork;

        public BaseManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            brandRepository = unitOfWork.BrandsRepository;
            modelRepository = unitOfWork.ModelsRepository;
        }
    }
}
