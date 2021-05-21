using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Models;

namespace Rema1000.Data
{
    public class DbContextRema1000 : DbContext
    {
        public DbContextRema1000 (DbContextOptions<DbContextRema1000> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MeassurementUnit> MeassurementUnits { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}