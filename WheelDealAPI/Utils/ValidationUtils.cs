namespace WheelDealAPI.Utils
{
    public class ValidationUtils
    {
        public static bool IsValidVehicleType(string vehicleType)
        {
            // Perform validation logic for vehicle type (e.g., check if it's "Common" or "Luxury")
            return vehicleType == "Common" || vehicleType == "Luxury";
        }

        public static bool IsPositive(decimal value)
        {
            // Perform validation logic to check if a decimal value is positive
            return value > 0;
        }

    }
}
