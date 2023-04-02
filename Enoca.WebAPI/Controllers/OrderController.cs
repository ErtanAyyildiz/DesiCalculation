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
        private readonly ICarrierConfigurationService _carrierConfigService;

        public OrderController(IValidator<Order> orderValidator, IOrderService orderService, ICarrierService carrierService, ICarrierConfigurationService carrierConfigService)
        {
            _orderValidator = orderValidator;
            _orderService = orderService;
            _carrierService = carrierService;
            _carrierConfigService = carrierConfigService;
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
            var carrierConfig=_carrierConfigService.GetCarrierConfigurationByCarrierId(carrierId);
            var carrier = _carrierService.GetCarrierByOrder(carrierId);

            var minDesi = carrierConfig.CarrierMinDesi;
            var maxDesi = carrierConfig.CarrierMaxDesi;
            var carrierCost = carrierConfig.CarrierCost;
            var carrierPlusCost = carrier.CarrierPlusDesiCost;
            var orderDesii = orderDesi;

            if (orderDesii>=minDesi && orderDesii<=maxDesi)
            {
                order.OrderCarrierCost= carrierCost;
            }
            else
            {
                var closestCarrier = _carrierConfigService.ClosestCarrierConfig(orderDesii);
                var diff = orderDesii - closestCarrier.CarrierMaxDesi;
                var carrierCosts = closestCarrier.CarrierCost + (diff * carrierPlusCost);

                order.OrderCarrierCost= carrierCosts;
            }

            var validationResult = _orderValidator.Validate(order);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            _orderService.Add(order);

            return Ok("Islem Basari ile olusturuldu");
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
