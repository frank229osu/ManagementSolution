using ManagementApi.Data;
using ManagementApi.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApi.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly ManagementDataContext _context;

        public ProductsController(ManagementDataContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public async Task<ActionResult> GetProduction()
        {
            //var response = new GetProductsResponse(
            //    new List<GetProductResponseItem>
            //    {
            //        new GetProductResponseItem(1, "eggs", 2.39M),
            //        new GetProductResponseItem(1, "bread", 2.39M),
            //        new GetProductResponseItem(1, "beer", 7.39M)
            //    }
            //    );
            var items = await _context.Products
                .Select(product => new GetProductResponseItem(product.Id, product.Name, product.Price))
                .ToListAsync();

            var response = new GetProductsResponse(items);

            return Ok(response);
        }
    }
}
