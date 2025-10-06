using GrainBroker.Entities;
using GrainBroker.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrainBroker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliers = await _supplierService.GetSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> CreateSupplier(CreateSupplierRequest request)
        {
            var supplier = new Supplier
            {
                SupplierName = request.Name,
                SupplierLocation = request.Location
                //ContactInformation = request.ContactInformation
            };

            var createdSupplier = await _supplierService.CreateSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetSuppliers), new { id = createdSupplier.Id }, createdSupplier);
        }
    }
}