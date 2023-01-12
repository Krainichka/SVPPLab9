using Lab9.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Brand> BrandsRepository { get; }
        IRepository<Model> ModelsRepository { get; }

        void SaveChanges();

    }
}
