using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product
    {        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; } 

        public string Category { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public string Material { get; set; }

        public double Weight { get; set; } 

        public int Stock { get; set; }

        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal SellingPrice { get; set; }

        public decimal VAT { get; set; }

        public decimal Price => SellingPrice + (SellingPrice * VAT / 100); //totaalprijs wordt berekend

        public bool Active { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

    }
}
