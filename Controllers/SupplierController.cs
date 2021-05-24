using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rema1000.Models;
using Rema1000.Services;

namespace Rema1000.Controllers
{
    /// <summary>
    /// Controller responsible for handling the Suppliers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        IService<Supplier> _service;

        public SupplierController(IService<Supplier> service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets the suppliers
        /// </summary>
        /// <returns>Returns a list of all the suppliers</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> GetSuppliers()
        {
            return Ok(_service.Read());
        }

        /// <summary>
        /// Gets a specific supplier via it's Guid.
        /// </summary>
        /// <param name="id">The guid of the Supplier being searched for.</param>
        /// <returns>Returns a Supplier object.</returns>
        [HttpGet("{id}")]
        public ActionResult<Supplier> GetSupplier(Guid id)
        {
            return Ok(_service.Read(id));
        }

        /// <summary>
        /// Adds a new supplier to the database.
        /// </summary>
        /// <param name="supplier">The supplier being added to the database.</param>
        /// <returns>Returns the supplier object after completion.</returns>
        [HttpPost]
        public ActionResult<Supplier> AddNewSupplier(Supplier supplier)
        {
            return Ok(_service.Create(supplier));
        }

        /// <summary>
        /// Updates a Supplier object.
        /// </summary>
        /// <param name="id">The guid of the Supplier being updated.</param>
        /// <param name="supplier">The new Supplier object data.</param>
        /// <returns>Returns Status204NoContent on Success, and returns Status404NotFound of fail.</returns>
        [HttpPut("{id}")]
        public ActionResult UpdateSupplier(Guid id, Supplier supplier)
        {
            if (!_service.Update(id, supplier))
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Attempts to delete a Supplier from the db.
        /// </summary>
        /// <param name="id">The guid of the Supplier being removed.</param>
        /// <returns>Returns Status204NoContent on success, returns Status404NotFound on fail.</returns>
        [HttpDelete]
        public ActionResult DeleteSupplier(Guid id)
        {
            if (!_service.Delete(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}