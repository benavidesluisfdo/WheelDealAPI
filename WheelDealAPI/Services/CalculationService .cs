using WheelDealAPI.Interfaces;
using WheelDealAPI.Models.DomainModels;
using WheelDealAPI.Models.ResponseModels;

namespace WheelDealAPI.Services
{
    public class CalculationService : ICalculationService
    {
        private const decimal StorageFee = 100;

        private readonly IPricingService _pricingService;
        public CalculationService(IPricingService pricingService) 
        {
            _pricingService = pricingService;
        }

        public (decimal totalPrice, List<FeeDetail> feeDetails) CalculateTotalPrice(Vehicle vehicle)
        {
            decimal basicFee = _pricingService.CalculateBasicFee(vehicle);
            decimal specialFee = _pricingService.CalculateSpecialFee(vehicle);
            decimal associationFee = _pricingService.CalculateAssociationFee(vehicle);
            decimal storageFee = StorageFee;

            decimal totalPrice = CalculateTotalPrice(vehicle.BasePrice, basicFee, specialFee, associationFee, storageFee);

            List<FeeDetail> feeDetails = GenerateFeeDetails(basicFee, specialFee, associationFee, storageFee);

            return (totalPrice, feeDetails);
        }

        private decimal CalculateTotalPrice(decimal basePrice, decimal basicFee, decimal specialFee, decimal associationFee, decimal storageFee)
        {
            return basePrice + basicFee + specialFee + associationFee + storageFee;
        }

        private List<FeeDetail> GenerateFeeDetails(decimal basicFee, decimal specialFee, decimal associationFee, decimal storageFee)
        {
            var feeDetails = new List<FeeDetail>
            {
                new FeeDetail { Name = "Basic Fee", Amount = basicFee },
                new FeeDetail { Name = "Special Fee", Amount = specialFee },
                new FeeDetail { Name = "Association Fee", Amount = associationFee },
                new FeeDetail { Name = "Storage Fee", Amount = storageFee },
            };

            return feeDetails;
        }
    }
}
