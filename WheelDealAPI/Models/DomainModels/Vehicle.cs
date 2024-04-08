namespace WheelDealAPI.Models.DomainModels
{
    public class Vehicle
    {
        public decimal BasePrice { get; set; }
        public required string Type { get; set; } // "Common" or "Luxury"

        //Constructors
        public Vehicle() { }
        public Vehicle(decimal basePrice, string type)
        {
            BasePrice = basePrice;
            Type = type;
        }
    }
}
