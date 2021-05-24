using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Data;
using Rema1000.Models;

namespace Rema1000.Services
{
    /// <summary>
    /// Use the DbContext to create a Mock database for the suppliers.
    /// </summary>
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

        /// <summary>
        /// Attempts to get a specific Supplier via a input Guid.
        /// </summary>
        /// <param name="id">The Guid of the Supplier being searched for.</param>
        /// <returns>Returns a Supplier object. The returned Supplier is Blank if no Supplier has the input Guid value.</returns>
        public Supplier Read(Guid id)
        {
            foreach (Supplier supplier in _mockDb)
            {
                if (supplier.SupplierID == id)
                {
                    return supplier;
                }
            }
            // If there is no supplier with the input id create and return a new blank supplier.
            return new Supplier();
        }


        /// <summary>
        /// Get the _mockDb database.
        /// </summary>
        /// <returns>Returns the entire _mockDb.</returns>
        public List<Supplier> Read()
        {
            return _mockDb;
        }

        /// <summary>
        /// Updates a already existing Supplier in the database.
        /// </summary>
        /// <param name="id">The Guid of the Supplier being updates.</param>
        /// <param name="supplier">The new supplier data.</param>
        /// <returns>Return true on success else return false.</returns>
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

        /// <summary>
        /// Deletes a Supplier from the _mockDb database;
        /// </summary>
        /// <param name="id">The Guid of the Supplier being deleted.</param>
        /// <returns>Returns true if success else return false.</returns>
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
