using GrainBroker.Entities;
using GrainBroker.Entities.DTOs;
using GrainBroker.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrainBroker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FulfillmentController : ControllerBase
    {
        private readonly IFulfillmentService _fulfillmentService;

        public FulfillmentController(IFulfillmentService fulfillmentService)
        {
            _fulfillmentService = fulfillmentService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderFulfillment>> CreateFulfillment(CreateFulfillmentRequest request)
        {
            try
            {
                var fulfillment = await _fulfillmentService.CreateFulfillmentAsync(
                    request.OrderId,
                    request.SupplierId,
                    request.SuppliedAmount,
                    request.CostOfDelivery
                );

                return CreatedAtAction(
                    nameof(GetFulfillment),
                    new { id = fulfillment.Id },
                    fulfillment
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderFulfillment>> GetFulfillment(Guid id)
        {
            var fulfillment = await _fulfillmentService.GetFulfillmentByIdAsync(id);

            if (fulfillment == null)
            {
                return NotFound();
            }

            return Ok(fulfillment);
        }

        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<OrderFulfillment>> GetFulfillmentByOrder(Guid orderId)
        {
            var fulfillment = await _fulfillmentService.GetFulfillmentByOrderIdAsync(orderId);

            if (fulfillment == null)
            {
                return NotFound();
            }

            return Ok(fulfillment);
        }

        [HttpGet("supplier/{supplierId}")]
        public async Task<ActionResult<IEnumerable<OrderFulfillment>>> GetFulfillmentsBySupplier(Guid supplierId)
        {
            var fulfillments = await _fulfillmentService.GetFulfillmentsBySupplierIdAsync(supplierId);
            return Ok(fulfillments);
        }

        /// <summary>
        /// Finds suitable suppliers that have enough stock to fulfill the specified order
        /// </summary>
        /// <param name="request">The order ID to find suppliers for</param>
        /// <returns>List of suppliers with sufficient stock</returns>
        [HttpPost("find-suppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> FindSuitableSuppliers([FromBody] FindSuppliersForOrderRequest request)
        {
            try
            {
                var suppliers = await _fulfillmentService.FindSuitableSuppliersForOrderAsync(request.OrderId);
                return Ok(suppliers);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}