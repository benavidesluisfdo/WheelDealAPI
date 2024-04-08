using WheelDealAPI.Interfaces;
using WheelDealAPI.Models.DomainModels;

namespace WheelDealAPI.Services
{
    public class PricingServices : IPricingService
    {
        private const decimal BasicFeePercentage = 0.1m; //10%
        private const decimal MinimumBasicFeeLuxury = 25;
        private const decimal MinimumBasicFeeCommon = 10;
        private const decimal MaximumBasicFeeLuxury = 200;
        private const decimal MaximumBasicFeeCommon = 50;
        private const decimal SpecialFeePercetageLuxury = 0.04m; //40%
        private const decimal SpecialFeePercetageCommon = 0.02m; //20%


        decimal IPricingService.CalculateAssociationFee(Vehicle vehicle)
        {
            if (vehicle.BasePrice <= 500)
                return 5;
            else if (vehicle.BasePrice <= 1000)
                return 10;
            else if (vehicle.BasePrice <= 3000)
                return 15;
            else
                return 20;
        }

        decimal IPricingService.CalculateBasicFee(Vehicle vehicle)
        {
            decimal minimumBasicFee = vehicle.Type == "Luxury" ? MinimumBasicFeeLuxury : MinimumBasicFeeCommon;
            decimal maximumBasicFee = vehicle.Type == "Luxury" ? MaximumBasicFeeLuxury : MaximumBasicFeeCommon;

            decimal basicFee = vehicle.BasePrice * BasicFeePercentage;            
            basicFee = Math.Max(basicFee, minimumBasicFee);
            basicFee = Math.Min(basicFee, maximumBasicFee);

            return basicFee;
        }

        decimal IPricingService.CalculateSpecialFee(Vehicle vehicle)
        {
            decimal specialFeePercetage = vehicle.Type == "Luxury" ? SpecialFeePercetageLuxury : SpecialFeePercetageCommon; //4% for luxury, 2% for commom
            return vehicle.BasePrice * specialFeePercetage;
        }
    }
}
