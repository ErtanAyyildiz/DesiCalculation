using Enoca.Business.Abstracts;
using Enoca.DataAccess.Wrappers;
using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IValidator<Order> _orderValidator;
        private readonly IOrderService _orderService;
        private readonly ICarrierService _carrierService;

        public OrderController(IValidator<Order> orderValidator, IOrderService orderService, ICarrierService carrierService)
        {
            _orderValidator = orderValidator;
            _orderService = orderService;
            _carrierService = carrierService;
        }

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetListOrder([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedDataOrder = _orderService.GetPagedData(validFilter);
            if (pagedDataOrder != null)
            {
                return Ok(new PagedResponse<List<Order>>(pagedDataOrder, validFilter.PageNumber, validFilter.PageSize));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateOrder(int orderDesi, int carrierId)
        {

            Order order = new()
            {
                OrderDesi = orderDesi,
                OrderDate = DateTime.Now,
                CarrierId = carrierId //Seçilen Kargo Firması
            };
            var carrier = _carrierService.GetCarrierByOrder(order.CarrierId);
            order.OrderCarrierCost = order.OrderDesi * carrier.CarrierPlusDesiCost;
            var validationResult = _orderValidator.Validate(order);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            _orderService.Add(order);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteOrder(int orderId)
        {
            var order = _orderService.GetByID(orderId);
            _orderService.Remove(order);
            return Ok();
        }
    }
}
