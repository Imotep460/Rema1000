using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Rema1000.Models;
using Rema1000.Data;

namespace Rema1000.Services
{
    /// <summary>
    /// Use the DbContext to create a mock database for the ProductCategories.
    /// </summary>
    public class ProductCategorySqlService : IService<ProductCategory>, IProductCategoryRead<ProductCategory>
    {
        private readonly DbContextRema1000 _dbContextRema1000;
        private readonly List<ProductCategory> _mockDb = new List<ProductCategory>();

        public ProductCategorySqlService(DbContextRema1000 dbContextRema1000)
        {
            _dbContextRema1000 = dbContextRema1000;
        }

        /// <summary>
        /// Adds a input ProductCategory to the _mockDb database.
        /// </summary>
        /// <param name="productCategory">The ProductCategory being added to the _mockDb.</param>
        /// <returns>Returns the input ProductCategory.</returns>
        public ProductCategory Create(ProductCategory productCategory)
        {
            _mockDb.Add(productCategory);
            return productCategory;
        }

        /// <summary>
        /// Gets a specific ProductCategory object via a input Guid.
        /// </summary>
        /// <param name="id">The Guid of the ProductCategory being looked for.</param>
        /// <returns>Return a ProductCategory object. If the input Guid does not exists returns a Blank ProductCategory object.</returns>
        public ProductCategory Read(Guid id)
        {
            foreach (ProductCategory productCategory in _mockDb)
            {
                if (productCategory.ProductCategoryID == id)
                {
                    return productCategory;
                }
            }
            // If the ProductCategory does not exists create and return a new Blank ProductCategory object.
            return new ProductCategory();
        }

        public List<ProductCategory> ReadByCategory(Guid id)
        {
            List<ProductCategory> tempList = new List<ProductCategory>();

            foreach(ProductCategory productCategory in _mockDb)
            {
                if (productCategory.ProductDepartment.DepartmentID == id)
                {
                    tempList.Add(productCategory);
                }
            }
            return tempList;
        }

        /// <summary>
        /// Gets the entire mock database.
        /// </summary>
        /// <returns>Returns the entire _mockDb.</returns>
        public List<ProductCategory> Read()
        {
            return _mockDb;
        }

        /// <summary>
        /// Updates a ProductCategory object.
        /// </summary>
        /// <param name="id">The Guid of the ProductCategory that is being updated.</param>
        /// <param name="productCategory">The new ProductCategory object data.</param>
        /// <returns>Returns true on success, else returns false.</returns>
        public bool Update(Guid id, ProductCategory productCategory)
        {
            for (int i = 0; i <= _mockDb.Count(); i++)
            {
                if (_mockDb[i].ProductCategoryID == id)
                {
                    _mockDb[i] = productCategory;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deletes a ProductCategory object from _mockDb.
        /// </summary>
        /// <param name="id">The Guid of the ProductCategory object being deleted.</param>
        /// <returns>Returns true on success, else returns false.</returns>
        public bool Delete(Guid id)
        {
            for (int i = 0; i <= _mockDb.Count(); i++)
            {
                if (_mockDb[i].ProductCategoryID == id)
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
