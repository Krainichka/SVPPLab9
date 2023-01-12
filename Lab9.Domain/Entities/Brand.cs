using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//производитель
namespace Lab9.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }//название бренда(марка)
        public DateTime FoundationDate { get; set; }// дата основания бренда
        // public string Address { get; set; }//адрес
        public int Amount { get; set; }//количество выпущенных авто за год
        public ICollection<Model> Models { get; set; }
    }
}
