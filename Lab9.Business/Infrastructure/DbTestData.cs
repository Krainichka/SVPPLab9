using Lab9.Business.Managers;
using Lab9.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9.Business.Infrastructure
{
    public static class DbTestData
    {
        public static void SetupData(BrandManager brandManager)
        {
            // Добавляем производителя авто (бренд)
            brandManager.AddRange(new List<Brand>
            {
                new Brand
                {
                    Name = "KIA",
                    FoundationDate = new DateTime(1956, 03, 01),
                    Amount = 14500
                },
                new Brand
                {
                    Name = "Audi",
                    FoundationDate = new DateTime(1902, 09, 01),
                    Amount = 10900
                },
                new Brand
                {
                    Name = "Lada",
                    FoundationDate = new DateTime(1965, 04, 01),
                    Amount = 19870
                },
                new Brand
                {
                    Name = "Volvo",
                    FoundationDate = new DateTime(1913, 02, 01),
                    Amount = 11340
                }
            });
            var brands = brandManager.Brands.ToList(); //список производителей

            // пополнение списка моделей авто
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "RIO",
                    Price = 1937.54M,
                    IssueDate = new DateTime(2021, 12, 01),
                    ImageModel = "rio.jpg"
                }, brands[0].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "CEED",
                    Price = 2456,
                    IssueDate = new DateTime(2022, 12, 01),
                    ImageModel = "ceed.jpg"
                }, brands[0].Id);

            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Sorento",
                    Price = 5462,
                    IssueDate = new DateTime(2022, 10, 01),
                    ImageModel = "sorento.jpg"
                }, brands[0].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Stinger",
                    Price = 9235,
                    IssueDate = new DateTime(2022, 12, 01),
                    ImageModel = "stinger.jpg"
                }, brands[0].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "A3",
                    Price = 3453,
                    IssueDate = new DateTime(2021, 02, 01),
                    ImageModel = "a3.jpg"
                }, brands[1].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "A8",
                    Price = 11768,
                    IssueDate = new DateTime(2023, 01, 01),
                    ImageModel = "a8.jpg"
                }, brands[1].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Q5",
                    Price = 14610,
                    IssueDate = new DateTime(2023, 01, 01),
                    ImageModel = "q5.jpg"
                }, brands[1].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Q8",
                    Price = 18666,
                    IssueDate = new DateTime(2022, 11, 01),
                    ImageModel = "q8.jpg"
                }, brands[1].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Niva",
                    Price = 2900,
                    IssueDate = new DateTime(2022, 02, 01),
                    ImageModel = "niva.jpg"
                }, brands[2].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Vesta",
                    Price = 1890,
                    IssueDate = new DateTime(2021, 11, 01),
                    ImageModel = "vesta.jpg"
                }, brands[2].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Vesta Sport",
                    Price = 3480,
                    IssueDate = new DateTime(2022, 10, 01),
                    ImageModel = "vestaS.jpg"
                }, brands[2].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "Xray",
                    Price = 4900,
                    IssueDate = new DateTime(2022, 09, 01),
                    ImageModel = "xray.jpg"
                }, brands[2].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "S60",
                    Price = 6470.6M,
                    IssueDate = new DateTime(2022, 12, 01),
                    ImageModel = "s60.jpg"
                }, brands[3].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "S90",
                    Price = 8700.35M,
                    IssueDate = new DateTime(2021, 10, 01),
                    ImageModel = "s90.jpg"
                }, brands[3].Id);
            brandManager.AddModelToBrand(
                new Model
                {
                    Name = "XC40",
                    Price = 11235,
                    IssueDate = new DateTime(2023, 01, 01),
                    ImageModel = "xc40.jpg"
                }, brands[3].Id);
        }
    }       
}
