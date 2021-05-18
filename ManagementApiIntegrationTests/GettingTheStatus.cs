using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementApiIntegrationTests
{
    public class GettingTheStatus : IClassFixture<CustomWebApplicationFactory>
    {

        private readonly HttpClient _client;

        public GettingTheStatus(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateDefaultClient();
        }


        // Has a 200 Ok.
        [Fact]
        public async Task HasSuccessStatusCode()
        {
            var response = await _client.GetAsync("/status"); // notice we don't have a hostname or port? cool.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        // Has data in JSON format
        [Fact]
        public async Task FormattedAsJson()
        {
            var response = await _client.GetAsync("/status");

            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }


        // Has the right data (status, dateAndTime)

        [Fact]
        public async Task HasCorrectEntity()
        {
            var response = await _client.GetAsync("/status");

            var entity = await response.Content.ReadAsAsync<StatusResponse>();

            Assert.Equal("Looks Good!", entity.status);
            Assert.Equal(DateTime.Now, entity.lastChecked);
        }
    }


    public class StatusResponse
    {
        public string status { get; set; }
        public DateTime lastChecked { get; set; }
    }






}
