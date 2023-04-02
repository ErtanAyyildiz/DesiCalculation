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
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;
        private readonly IValidator<CarrierConfiguration> _validator;

        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService, IValidator<CarrierConfiguration> validator)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _validator = validator;
        }

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetListCarrierConfig([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedDataCarrierConfig = _carrierConfigurationService.GetPagedData(validFilter);
            if (pagedDataCarrierConfig != null)
            {
                return Ok(new PagedResponse<List<CarrierConfiguration>>(pagedDataCarrierConfig, validFilter.PageNumber, validFilter.PageSize));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateCarrierConfig(int carrierId, int carrierMaxDesi, int carrierMinDesi, decimal carrierCost)
        {
            CarrierConfiguration carrierConfig = new ()
            {
                CarrierId = carrierId,
                CarrierMaxDesi = carrierMaxDesi,
                CarrierMinDesi = carrierMinDesi,
                CarrierCost = carrierCost
            };
            var validationResult = _validator.Validate(carrierConfig);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            _carrierConfigurationService.Add(carrierConfig);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeletCarrierConfig(int carrierId)
        {
            var order = _carrierConfigurationService.GetByID(carrierId);
            _carrierConfigurationService.Remove(order);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateCarrierConfig(int carrierConfigId,int carrierId, int carrierMaxDesi, int carrierMinDesi, decimal carrierCost)
        {
            CarrierConfiguration carrierConfig = new()
            {
                CarrierConfigurationId=carrierConfigId,
                CarrierId = carrierId,
                CarrierMaxDesi = carrierMaxDesi,
                CarrierMinDesi = carrierMinDesi,
                CarrierCost = carrierCost
            };
            _carrierConfigurationService.Update(carrierConfig);
            return Ok();
        }
    }
}
