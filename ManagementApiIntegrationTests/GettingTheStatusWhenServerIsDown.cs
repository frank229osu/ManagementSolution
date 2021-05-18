using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementApiIntegrationTests
{
    public class GettingTheStatusWhenServerIsDown : IClassFixture<CustomWebApplicationFactoryWithBadStatusServer>
    {

        private readonly HttpClient _client;

        public GettingTheStatusWhenServerIsDown(CustomWebApplicationFactoryWithBadStatusServer factory)
        {
            _client = factory.CreateDefaultClient();

        }

        [Fact]
        public async Task CorrectResponseWhenTheStatusServerIsDown()
        {
            var response = await _client.GetAsync("/status");

            var entity = await response.Content.ReadAsAsync<ErrorStatus>();

            Assert.Equal("Unavailable", entity.status);
            Assert.Equal("The Status Server is Temporarily Unavailble. Try Again Later", entity.errorReason);
        }
    }


    public class ErrorStatus
    {
        public string status { get; set; }
        public string errorReason { get; set; }
    }

}
