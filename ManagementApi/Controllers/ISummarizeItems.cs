using ManagementApi.Models.Products;
using System.Collections.Generic;

namespace ManagementApi.Controllers
{
    public interface ISummarizeItems
    {
        GetProductSummary GetSummaryFor(List<GetProductResponseItem> items);
    }
}