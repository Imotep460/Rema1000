using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1000.Models
{
    public class MeassurementUnit
    {
        [Key]
        public Guid MeassurementUnitID { get; set; }
        [Required]
        public string MeassurementUnitName { get; set; }
    }
}
