using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rema1000.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; } // the name of the department (ie: Meats, Dairy etc).
    }
}
