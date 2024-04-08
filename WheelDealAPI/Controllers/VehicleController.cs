using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheelDealAPI.Interfaces;
using WheelDealAPI.Models.DomainModels;
using WheelDealAPI.Models.RequestModels;
using WheelDealAPI.Models.ResponseModels;
using WheelDealAPI.Utils;

namespace WheelDealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        public VehicleController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpPost("calculate-price")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CalculatePrice([FromBody] CalculatePriceRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!ValidationUtils.IsValidVehicleType(request.VehicleType))
            {
                return BadRequest("Invalid vehicle type.");
            }

            if(!ValidationUtils.IsPositive(request.BasePrice))
            {
                return BadRequest("Base price must be positive.");
            }

            var newVehicle = new Vehicle
            {
                BasePrice = request.BasePrice,
                Type = request.VehicleType,
            };

            (decimal totalPrice, List<FeeDetail> feeDetails) = _calculationService.CalculateTotalPrice(newVehicle);

            var response = new CalculatePriceResponse
            {
                TotalPrice = totalPrice,
                FeeDetails = feeDetails
            };

            return Ok(response);
        }
    }
}
