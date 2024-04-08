using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using WheelDealAPI.Models.ResponseModels;

namespace WheelDealAPI.Test
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task OK_PositiveResultTestAsync()
        {
            var httpClient = _factory.CreateClient();

            // Arrange
            var request = new
            {
                BasePrice = 1000,
                VehicleType = "Common"
            };

            // Act
            var response = await httpClient.PostAsJsonAsync("/api/vehicle/calculate-price", request);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Read and assert response
            var content = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<CalculatePriceResponse>(content);

            Assert.NotNull(responseObj);
            Assert.True(responseObj.TotalPrice > 0); // Assuming totalPrice should always be positive
        }

        [Fact]
        public async Task BadRequest_TestAsync()
        {
            var httpClient = _factory.CreateClient();

            // Arrange
            var request = new
            {
                BasePrice = 1000,
                VehicleType = "Expensive"
            };

            // Act
            var response = await httpClient.PostAsJsonAsync("/api/vehicle/calculate-price", request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            // Read and assert response
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("Invalid vehicle type.", content);
        }
    }
}