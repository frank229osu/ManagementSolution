using ManagementApi;
using ManagementApi.Controllers;
using ManagementApi.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementAPIUnitTests
{
    public class OrderSummarizerTests
    {
        [Fact]
        public void x()
        {
            // Given
            ISummarizeItems summarizer = new StandardSummarizer(null);
            var products = new List<GetProductResponseItem>
            {
                new GetProductResponseItem(1, "Eggs", 3.99M),
                new GetProductResponseItem(2, "Beer", 7.99M)
            };


            // When
            var response = summarizer.GetSummaryFor(products);


            // Then
            Assert.Equal(2, response.NumberOfProducts);
            Assert.Equal(1, response.NumberCloseToBackorder);
        }
    }
}
