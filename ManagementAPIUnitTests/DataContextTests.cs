using ManagementApi;
using ManagementApi.Data;
using ManagementApi.Models.Products;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementAPIUnitTests
{
    public class DataContextTests
    {

        [Fact]
        public void Tacos()
        {
            // Arrange
            IList<Product> products = new List<Product>
            {
               new Product { Id=1, Name ="beer", Price=3.99M},
               new Product { Id=2, Name ="beer", Price=3.99M},
               new Product { Id=3, Name ="beer", Price=3.99M},
               new Product { Id=4, Name ="beer", Price=3.99M},
            };

            var stubbedContext = new Mock<ManagementDataContext>(new DbContextOptions<ManagementDataContext>());
            stubbedContext.Setup(c => c.Products).ReturnsDbSet(products);
            var summarizer = new StandardSummarizer(stubbedContext.Object);
            // Act
            var response = summarizer.GetSummaryQueryable();

            Assert.Equal(4, response.NumberOfProducts);
            Assert.Equal(1, response.NumberCloseToBackorder);
        }
    }
}
