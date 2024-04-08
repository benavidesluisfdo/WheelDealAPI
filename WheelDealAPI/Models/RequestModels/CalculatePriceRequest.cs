namespace WheelDealAPI.Models.RequestModels
{
    public class CalculatePriceRequest
    {
        public decimal BasePrice { get; set; }
        public required string VehicleType { get; set; } // "Common" or "Luxury"
    }
}
