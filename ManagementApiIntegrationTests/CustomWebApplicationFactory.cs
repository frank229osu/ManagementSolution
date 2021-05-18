using ManagementApi;
using ManagementApi.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApiIntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // when this is called, the startup ConfigureServices method is already called.
            // We are going to reach in, find that service, and replace it with a stub.

            builder.ConfigureServices((services) =>
            {
                var descriptor = services.Single(services =>
                {
                    return services.ServiceType == typeof(ILookupServerStatus);
                });

                services.Remove(descriptor);
                services.AddTransient<ILookupServerStatus, StubbedServerStatus>();

            });
        }
    }

    public class StubbedServerStatus : ILookupServerStatus
    {
        public Task<ManagementApi.Controllers.StatusResponse> GetMyStatus()
        {
            return Task.FromResult(new ManagementApi.Controllers.StatusResponse
            {
                Status = "TACOS ARE GOOD",
                LastChecked = new DateTime(1969,4,20,23,59,00)
            })l
        }
    }
}
