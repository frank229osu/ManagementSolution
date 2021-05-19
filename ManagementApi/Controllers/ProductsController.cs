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
        private readonly ISummarizeItems _summarizer;

        public ProductsController(ManagementDataContext context)
        {
            _context = context;
        }

        [HttpPost("products")]
        public async Task<ActionResult> AddAProduct([FromBody] GetProductResponseItem item)
        {
            // validation 

            var productToSave = new Product
            {
                Name = item.Name,
                Price = item.Price
            };
            _context.Products.Add(productToSave);
            await _context.SaveChangesAsync();
            var response = new GetProductResponseItem(
                productToSave.Id,
                productToSave.Name, productToSave.Price
                );

            return StatusCode(201, response);
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

            GetProductSummary summary = _summarizer.GetSummaryFor(items);
            var response = new GetProductsResponse(items, summary);

            return Ok(response);
        }
    }
}
