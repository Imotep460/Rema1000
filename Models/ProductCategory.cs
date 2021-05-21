using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rema1000.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid ProductCategoryID { get; set; }
        [Required]
        public string ProductCategoryName { get; set; } // The name of the category (ie, beef, chicken, milk, cheese etc).
        public string ProductCategoryDescription { get; set; } // Additional description for the category.
        public Department ProductDepartment { get; set; } // The department for the product (ie. Meats, Dairy etc).
    }
}
