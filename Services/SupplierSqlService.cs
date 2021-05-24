using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Data;
using Rema1000.Models;

namespace Rema1000.Services
{
    public class SupplierSqlService : IService<Supplier>
    {
        private readonly DbContextRema1000 _dbContextRema1000;
        private static List<Supplier> _mockDb = new List<Supplier>();

        public SupplierSqlService(DbContextRema1000 dbContext)
        {
            _dbContextRema1000 = dbContext;
        }

        /// <summary>
        /// Creates a new Supplier Object and adds it to the db.
        /// </summary>
        /// <param name="supplier">The Supplier object being creeated.</param>
        /// <returns>Return the Supplier object.</returns>
        public Supplier Create(Supplier supplier)
        {
            _mockDb.Add(supplier);
            return supplier;
        }

        public Supplier Read(Guid id)
        {
            foreach (Supplier supplier in _mockDb)
            {
                if (supplier.SupplierID == id)
                {
                    return supplier;
                }
            }
            return new Supplier();
        }

        public List<Supplier> Read()
        {
            return _mockDb;
        }

        public bool Update(Guid id, Supplier supplier)
        {
            for (int i = 0; i <= _mockDb.Count(); i++)
            {
                if (_mockDb[i].SupplierID == id)
                {
                    _mockDb[i] = supplier;
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            for (int i = 0; i <= _mockDb.Count(); i++)
            {
                if (_mockDb[i].SupplierID == id)
                {
                    _mockDb.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool SaveChanges()
        {
            return (_dbContextRema1000.SaveChanges() >= 0);
        }
    }
}
