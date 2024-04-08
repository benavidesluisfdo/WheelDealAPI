namespace WheelDealAPI.Models.ResponseModels
{
    public class CalculatePriceResponse
    {
        public decimal TotalPrice { get; set; }
        public List<FeeDetail> FeeDetails { get; set; }

        public CalculatePriceResponse()
        {
            FeeDetails = new List<FeeDetail>();
        }
    }
}
