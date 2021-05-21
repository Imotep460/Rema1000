using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Services;
using Rema1000.Models;

namespace Rema1000.Controllers
{
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

        [HttpGet("productcategory/{id}")]
        public ActionResult<IEnumerable<Product>> GetProductByProductCategory(Guid id)
        {
            return Ok(_categoryReadService.ReadByCategory(id));
        }

        [HttpPost]
        public ActionResult<Product> CreateNewProduct(Product product)
        {
            return Ok(_service.Create(product));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, Product product)
        {
            if (!_service.Update(id, product))
            {
                return NotFound();
            }
            return NoContent();
        }

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