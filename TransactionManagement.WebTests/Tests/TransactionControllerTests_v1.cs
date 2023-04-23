using AngleSharp.Html.Dom;
using RazorPagesProject.Tests.Helpers;
using System.Net;
using TransactionManagement.DAL.DataAccess;
using TransactionManagement.WebTests.Factories;
using TransactionManagement.WebTests.Helpers;

namespace TransactionManagement.WebTests.Tests
{
    public class TransactionControllerTests_v1 : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public TransactionControllerTests_v1(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();
                db.Transactions.Add(new DAL.Entities.TransactionEntity
                {
                    Amount = 10
                });
                db.SaveChanges();
            }
        }

        [Fact]
        public async Task Index_ShouldReturnSuccess()
        {
            // Act
            var response = await _client.GetAsync("/Transactions");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Delete_ShouldReturnSuccess()
        {
            // Arrange

            var defaultPage = await _client.GetAsync("/Transactions/Delete/1");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

            // Act
            var response = await _client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form"),
        (IHtmlInputElement)content.QuerySelector("input[type=submit]"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}