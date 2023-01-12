using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//модель авто
namespace Lab9.Domain.Entities
{
    public class Model
    {
       public int Id { get; set; }
        public string Name { get; set; }// название модели
        public string ImageModel { get; set; }
        public decimal Price { get; set; } //цена млн руб
        public DateTime IssueDate { get; set; }//дата выпуска (месяц, год)
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
