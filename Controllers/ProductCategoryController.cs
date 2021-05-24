using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Rema1000.Models;
using Rema1000.Services;

namespace Rema1000.Controllers
{
    /// <summary>
    /// Controller responsible for handling the ProductCategories.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        IService<ProductCategory> _service;
        IProductCategoryRead<ProductCategory> _productCategoryReadService;

        public ProductCategoryController(IService<ProductCategory> service, IProductCategoryRead<ProductCategory> productCategoryReadService)
        {
            _service = service;
            _productCategoryReadService = productCategoryReadService;
        }

        /// <summary>
        /// Gets the information of the Categories.
        /// </summary>
        /// <returns>Returns a collection of the Categories.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return Ok(_service.Read());
        }

        /// <summary>
        /// Gets a collection of ProductCategories in a Department.
        /// </summary>
        /// <param name="id">The Guid of the Department.</param>
        /// <returns>Returns a collecttion of ProductCategories found in a Department.</returns>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProductCategory>> GetProductCategoryDepartment(Guid id)
        {
            return Ok(_productCategoryReadService.ReadByCategory(id));
        }

        /// <summary>
        /// Creates a new ProductCategory.
        /// </summary>
        /// <param name="productCategory">The ProductCategory object being passed to the database.</param>
        /// <returns>Returns the created ProductCategory.</returns>
        [HttpPost]
        public ActionResult<ProductCategory> AddNewProductCategory(ProductCategory productCategory)
        {
            return Ok(_service.Create(productCategory));
        }

        /// <summary>
        /// Updates a ProductCategory.
        /// </summary>
        /// <param name="id">The Guid of the ProductCategory being updated.</param>
        /// <param name="productCategory">The new ProductCategory data.</param>
        /// <returns>Return Status204NoContent on success else returns Status404NotFound if it fails.</returns>
        [HttpPut("{id}")]
        public ActionResult UpdateProductCategory(Guid id, ProductCategory productCategory)
        {
            if (!_service.Update(id, productCategory))
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Deletes a ProductCategory
        /// </summary>
        /// <param name="id">The guid of the ProductCategory being deleted.</param>
        /// <returns>Returns Status204NoContent on success, else returns Status404NotFound if it fails.</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteProductCategory(Guid id)
        {
            if (!_service.Delete(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}