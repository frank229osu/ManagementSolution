using ManagementApi.Controllers;
using ManagementApi.Data;
using ManagementApi.Models.Products;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApi
{
    public class StandardSummarizer : ISummarizeItems
    {

        private readonly ManagementDataContext _context;

        public StandardSummarizer(ManagementDataContext context)
        {
            _context = context;
        }

        public GetProductSummary GetSummaryFor(List<GetProductResponseItem> items)
        {
           
            // do all that real grown-up programming to figure out the back-order situation here.
            return new GetProductSummary(items.Count, 1);
            
        }

        public GetProductSummary GetSummaryQueryable() 
        {
            var response = _context.Products.ToList();
            return new GetProductSummary(response.Count, 1);
        }
    }
}