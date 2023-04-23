using Microsoft.AspNetCore.Mvc.Testing;

namespace TransactionManagement.WebTests.Tests
{
    public class TransactionControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public TransactionControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Index_ShouldReturnSuccess()
        {
            // Act
            var response = await _client.GetAsync("/Transactions");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}