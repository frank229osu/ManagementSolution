using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApi.Controllers
{
    public class BishalStatusLookup : ILookupServerStatus
    {
        public Task<StatusResponse> GetMyStatus()
        {
            return Task.FromResult(new StatusResponse
            {
                Status = "Looks Good To Me!",
                LastChecked = DateTime.Now
            });
        }
    }
}
