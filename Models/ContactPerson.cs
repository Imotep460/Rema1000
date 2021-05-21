using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rema1000.Models
{
    public class ContactPerson
    {
        [Key]
        public Guid ContectPersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactSelfPhone { get; set; } // The phoneNumber for contactpersons personal workphone.
        public string SupplierMainline { get; set; } // The phonenumber for the Suppliers mainline.
        public Supplier Supplier { get; set; } // The Supplier the contactperson works for.
    }
}
