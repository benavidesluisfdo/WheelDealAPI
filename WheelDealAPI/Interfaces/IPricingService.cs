using WheelDealAPI.Models.DomainModels;

namespace WheelDealAPI.Interfaces
{
    public interface IPricingService
    {
        decimal CalculateBasicFee(Vehicle vehicle);
        decimal CalculateSpecialFee(Vehicle vehicle);
        decimal CalculateAssociationFee(Vehicle vehicle);
    }
}
