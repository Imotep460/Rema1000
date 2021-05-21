using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Data;
using Rema1000.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Rema1000.Services
{
    public class ProductSqlService : IService<Product>, IProductCategoryRead<Product>
    {
        private readonly DbContextRema1000 _dbContext;
        private static List<Product> _mockDB = new List<Product>();

        public ProductSqlService(DbContextRema1000 dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Create(Product product)
        {
            _mockDB.Add(product);
            return product;
        }

        public Product Read(Guid id)
        {
            foreach (Product product in _mockDB)
            {
                if (product.ProductID == id)
                {
                    return product;
                }
            }
            return new Product();
        }

        public List<Product> ReadByCategory(Guid categoryID)
        {
            List<Product> tempProducts = new List<Product>();

            foreach (Product product in _mockDB)
            {
                if (product.ProductCategory.ProductCategoryID == categoryID)
                {
                    tempProducts.Add(product);
                }
            }
            return tempProducts;
        }

        public List<Product> Read()
        {
            return _mockDB;
        }

        public bool Update(Guid id, Product product)
        {
            for (int i = 0; i <= _mockDB.Count(); i++)
            {
                if (_mockDB[i].ProductID == id)
                {
                    _mockDB[i] = product;
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            for (int i = 0; i <= _mockDB.Count(); i++)
            {
                if (_mockDB[i].ProductID == id)
                {
                    _mockDB.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
