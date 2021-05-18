using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApi.Controllers
{
    public class DemoController : ControllerBase
    {

        // GET /status
        [HttpGet("/status")]
        public ActionResult GetStatus()
        {
            var response = new StatusResponse
            {
                Status = "Looks Good!",
                LastChecked = DateTime.Now
            };

            return Ok(response);
        }
    }

    public class StatusResponse
    {
        public string Status { get; set; }
        public DateTime LastChecked { get; set; }
    }
}
