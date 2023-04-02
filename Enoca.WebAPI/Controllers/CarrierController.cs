using Enoca.Business.Abstracts;
using Enoca.Business.Validators;
using Enoca.DataAccess.Wrappers.Filters;
using Enoca.DataAccess.Wrappers;
using Enoca.Entity.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace Enoca.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IValidator<Carrier> _carrierValidator;
        private readonly ICarrierService _carrierService;

        public CarrierController(IValidator<Carrier> carrierValidator, ICarrierService carrierService)
        {
            _carrierValidator = carrierValidator;
            _carrierService = carrierService;
        }

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetListCarrier([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedDataCarrier = _carrierService.GetPagedData(validFilter);
            if (pagedDataCarrier != null)
            {
                return Ok(new PagedResponse<List<Carrier>>(pagedDataCarrier, validFilter.PageNumber, validFilter.PageSize));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateCarrier(string carrierName, bool carrierIsActive, int carrierPlusDesiCost,int carrierConfigurationId)
        {
            Carrier carrier = new Carrier()
            {
                CarrierName = carrierName,
                CarrierIsActive = carrierIsActive,
                CarrierConfigurationId = carrierConfigurationId,
                CarrierPlusDesiCost = carrierPlusDesiCost
            };
            var validationResult = _carrierValidator.Validate(carrier);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            _carrierService.Add(carrier);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeletCarrier(int carrierId)
        {
            var order = _carrierService.GetByID(carrierId);
            _carrierService.Remove(order);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateCarrier(int carrierId,string carrierName,bool carrierActive,int carrierPlusDesiCost,int? carrierConfigurationId)
        {
            Carrier carrier = new()
            {
                CarrierId = carrierId,
                CarrierName = carrierName,
                CarrierIsActive = carrierActive,
                CarrierPlusDesiCost = carrierPlusDesiCost,
                CarrierConfigurationId = carrierConfigurationId
            };
            _carrierService.Update(carrier);
            return Ok();
        }
    }
}
