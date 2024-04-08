using WheelDealAPI.Models.DomainModels;
using WheelDealAPI.Models.ResponseModels;

namespace WheelDealAPI.Interfaces
{
    public interface ICalculationService
    {
        public (decimal totalPrice, List<FeeDetail> feeDetails) CalculateTotalPrice(Vehicle vehicle);
    }
}
