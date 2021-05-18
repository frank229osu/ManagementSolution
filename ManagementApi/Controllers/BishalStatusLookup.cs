using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManagementApi.Controllers
{
    public class BishalStatusLookup : ILookupServerStatus
    {
        private readonly HttpClient _client;

        public BishalStatusLookup(HttpClient client)
        {
            _client = client;
        }

        public async Task<StatusResponse> GetMyStatus()
        {
            try
            {
                var response = await _client.GetAsync("http://localhost:1338/statuscheck");

                return await response.Content.ReadAsAsync<StatusResponse>();
            }
            catch (Exception)
            {

                throw new StatusServerUnavailableExceptions();
            }
        }
    }
}
