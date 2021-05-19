﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementApiIntegrationTests.Products
{
    public class GettingProductList : IClassFixture<CustomWebApplicationFactory>
    {

        private readonly HttpClient _client;
        public GettingProductList(CustomWebApplicationFactory factory)
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

            Assert.Equal(3, content?.data?.Length);
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


}
