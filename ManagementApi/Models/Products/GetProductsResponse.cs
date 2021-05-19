using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApi.Models.Products
{
  

    //public class GetProductsResponse
    //{
    //    public GetProductsResponseItem[] data { get; set; }
    //}

    //public class GetProductsResponseItem
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public decimal price { get; set; }
    //}

    public record GetProductResponseItem(int Id, string Name, decimal Price);
    public record GetProductsResponse(List<GetProductResponseItem> Data, GetProductSummary Summary);

    public record GetProductSummary(int NumberOfProducts, int NumberCloseToBackorder);
}
