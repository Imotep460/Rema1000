using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rema1000.Models
{
    public class Address
    {
        [Key]
        public Guid AddressID { get; set; }
        [Required]
        public string StreetName { get; set; } // The name of the street
        public string StreetNumber { get; set; } // the StreetNumber for the supplier (NOTE: this is string because som housenumber contains letters).
        [Required]
        public string City { get; set; } // The city for the zipcode.
        [Required]
        public int Zipcode { get; set; } // the address zipcode.
        public Supplier Supplier { get; set; } // The Supplier who lives at the address.
    }
}
