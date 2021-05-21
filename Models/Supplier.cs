using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rema1000.Models
{
    public class Supplier
    {
        [Key]
        public Guid SupplierID { get; set; }
        [Required]
        public string SupplierNamer { get; set; }
        public List<Product> SupplierProducts { get; set; } // Products the Supplier sells.
        public List<Address> SupplierAddress { get; set; } // Supplier Address.
        public List<ContactPerson> SupplierContactPerson { get; set; } // Liason person between the shop and the supplier.
    }
}