using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1000.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        [Required]
        public string Productname { get; set; }
        public string ProductDescription { get; set; }
        public decimal SalesPrice { get; set; } // Price the customer pays
        public decimal PurchasePrice { get; set; } // Price the shop pays the supplier.
        public int UnitsInStock { get; set; } // How many units of the product are currently in stock.
        public MeassurementUnit MeassurementUnit { get; set; } // How is the product messured (KG, liter, deciliter etc).
        public decimal MeassurementUnitValue { get; set; } // What ís the value of the meassurement (how many kg, liter, deciliter etc).
        public ProductCategory ProductCategory { get; set; } // Describes the product category (ie: Meat, dairy, Vegtables etc).
        public Supplier Supplier { get; set; } // The Supplier of the product.
    }
}
