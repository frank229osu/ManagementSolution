using ManagementApi.Models.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApi.Controllers
{
    public class ProductsController : ControllerBase
    {

        [HttpGet("products")]
        public async Task<ActionResult> GetProduction()
        {
            var response = new GetProductsResponse(
                new List<GetProductResponseItem>
                {
                    new GetProductResponseItem(1, "eggs", 2.39M),
                    new GetProductResponseItem(1, "bread", 2.39M),
                    new GetProductResponseItem(1, "beer", 7.39M)
                }
                );
            return Ok(response);
        }
    }
}
