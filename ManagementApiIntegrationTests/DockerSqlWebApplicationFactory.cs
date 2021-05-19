using ManagementApi;
using ManagementApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApiIntegrationTests
{
    public class DockerSqlWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                var descriptor = services.First(s => s.ServiceType == typeof(DbContextOptions<ManagementDataContext>));

                services.Remove(descriptor);

                services.AddDbContext<ManagementDataContext>(options =>
                {
                    options.UseSqlServer("server=.;database=management_test;user=sa;password=TokyoJoe138!");
                });
            });

        }
    }
}
