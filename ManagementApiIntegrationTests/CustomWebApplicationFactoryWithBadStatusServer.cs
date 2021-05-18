using ManagementApi;
using ManagementApi.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApiIntegrationTests
{
    public class CustomWebApplicationFactoryWithBadStatusServer : WebApplicationFactory<Startup>
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
                var stubbedServerStatus = new Mock<ILookupServerStatus>();
                stubbedServerStatus.Setup(s => s.GetMyStatus()).Throws(new StatusServerUnavailableExceptions());
                services.AddTransient<ILookupServerStatus>((_) => stubbedServerStatus.Object);

            });
        }
}
