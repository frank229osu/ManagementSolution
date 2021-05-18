using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApi.Controllers
{
    public class DemoController : ControllerBase
    {
        private readonly ILookupServerStatus _statusLookup;

        public DemoController(ILookupServerStatus statusLookup)
        {
            _statusLookup = statusLookup;
        }


        // GET /status
        [HttpGet("/status")]
        public async Task<ActionResult<StatusResponse>> GetStatus()
        {
            StatusResponse response = await _statusLookup.GetMyStatus();

            return Ok(response);
        }
    }

    public class StatusResponse
    {
        public string Status { get; set; }
        public DateTime LastChecked { get; set; }
    }
}
