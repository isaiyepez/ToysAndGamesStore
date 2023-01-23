using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using ToysAndGamesAPI.Entities;
using Xunit.Abstractions;

namespace ApiIntegrationTests
{
    public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Program> _factory;

        public ApiIntegrationTests(ITestOutputHelper outputHelper,
            WebApplicationFactory<Program> factory) 
        {
            _factory = factory;
            _outputHelper = outputHelper;
        }

        [Fact]
        public async void TestGetProducts()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var response = await client.GetAsync("/api/products/getproducts");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotEmpty(responseContent);
            Assert.NotNull(responseContent);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));

        }


        [Fact]
        public async void TestGetSingleProduct()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var response = await client.GetAsync("/api/products/getproduct/1");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotEmpty(responseContent);
            Assert.NotNull(responseContent);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));

        }

        [Fact]
        public async void TestPostProduct()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var product = new Product()
            {
                Name = "Barbie Tester",
                Description = "Stressed doll that hates developing team -they just send crap! (product added in test case)",
                AgeRestriction = 5,
                Company = "Mattel",
                Price = 80
            };

            var serializedProduct = JsonConvert.SerializeObject(product);
            var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/products/addproduct", content);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);           

        }

        [Fact]
        public async void TestPatchProduct()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var product = new Product()
            {
                Id = 1019,
                Name = "Barbie Tester",
                Description = "Stressed doll that hates developing team -they just send crap! (product patched in test case)",
                AgeRestriction = 5,
                Company = "Mattel",
                Price = 80
            };

            var serializedProduct = JsonConvert.SerializeObject(product);
            var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
            var response = await client.PatchAsync("/api/products/updateproduct", content);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

    }
}