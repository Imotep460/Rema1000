using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Services;
using Rema1000.Models;

namespace Rema1000.Controllers
{
    /// <summary>
    /// This project is not hooked up to a remote database so a Mock db is created in the ProductSqlService.cs file.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        IService<Product> _service;
        IProductCategoryRead<Product> _categoryReadService;

        public ProductController(IService<Product> service, IProductCategoryRead<Product> categoryReadService)
        {
            _service = service;
            _categoryReadService = categoryReadService;
        }

        /// <summary>
        /// Get a specific product based of a product Guid.
        /// </summary>
        /// <param name="id">Guid for the product being searched for.</param>
        /// <returns>Return A product.</returns>
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(Guid id)
        {
            return Ok(_service.Read(id));
        }

        /// <summary>
        /// Gets all the products i the db.
        /// </summary>
        /// <returns>Return a List of products.</returns>
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(_service.Read());
        }

        /// <summary>
        /// Gets a Category via it's Guid.
        /// </summary>
        /// <param name="id">The Guid of the ProductCategory.</param>
        /// <returns>Returns a collection of products with the ProductCategory guid.</returns>
        [HttpGet("productcategory/{id}")]
        public ActionResult<IEnumerable<Product>> GetProductByProductCategory(Guid id)
        {
            return Ok(_categoryReadService.ReadByCategory(id));
        }

        /// <summary>
        /// Creats a product object and adds it to the db.
        /// </summary>
        /// <param name="product">The Product object being created.</param>
        /// <returns>Return the project if successful.</returns>
        [HttpPost]
        public ActionResult<Product> CreateNewProduct(Product product)
        {
            return Ok(_service.Create(product));
        }

        /// <summary>
        /// Updates a Product.
        /// </summary>
        /// <param name="id">The Guid of the Product object being updated.</param>
        /// <param name="product">The new Product data.</param>
        /// <returns>Return a NotFound() if the Product does not exists. Returns NoContent().Status204NoContent response on success.</returns>
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, Product product)
        {
            if (!_service.Update(id, product))
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Deletes a Product object from the db.
        /// </summary>
        /// <param name="id">The Guid of the Product being deleted</param>
        /// <returns>Return a NotFound() if the Product does not exists. Returns NoContent().Status204NoContent response on success.</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            if (!_service.Delete(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}