using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementApiIntegrationTests.Products
{
    public class GettingProductList : IClassFixture<DockerSqlWebApplicationFactory>
    {

        private readonly HttpClient _client;
        public GettingProductList(DockerSqlWebApplicationFactory factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task ASuccessStatusCode()
        {
            var response = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task HasCorrectEntity()
        {
            var response = await _client.GetAsync("/products");

            var content = await response.Content.ReadAsAsync<GetProductsResponse>();

            Assert.True(content?.data?.Length > 0);
        }

        [Fact]
        public async Task AddingaProduct()
        {
            // begin a transaction
            // POST /products
            var response = await _client.PostAsJsonAsync("/products",
                new { name = "Test Product 1", price = 8.99M });


            // assert on it
            Assert.True(response.IsSuccessStatusCode);


            var product = await response.Content.ReadAsAsync<PostProductResponse>();

            Assert.Equal("Test Product 1", product.name);
            Assert.Equal(8.99M, product.price);

        }
    }




    public class GetProductsResponse
    {
        public GetProductsResponseItem[] data { get; set; }
    }

    public class GetProductsResponseItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }



    public class PostProductResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }


}
