using Lab9.Business.Managers;
using Lab9.DAL.Repositories;
using Lab9.Domain.Interfaces;
using Lab9.TestData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Business.Infrastructure
{
    public class ManagersFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly BrandManager brandManager;
        private readonly ModelManager modelManager;

        public ManagersFactory()
        {
            unitOfWork = new TestUnitOfWork();
        }
        public ManagersFactory(string connectionStr)//имя подключения, к примеру DefaultConnection из файла appsettings.json
        {
           var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            var connStr= configuration.GetConnectionString(connectionStr);
            unitOfWork = new EfUnitOfWork(connStr);
        }

        public BrandManager GetBrandManager()
        {
            return brandManager ?? new BrandManager(unitOfWork);
        }
        public ModelManager GetModelManager()
        {
            return modelManager ?? new ModelManager(unitOfWork);
        }
    }
}

    

