using Products.Core.Entities;
using System;
using Xunit;

namespace Products.Core.Tests
{
    public class ProductTestCases
    {

        [Fact]
        public void When_New_Product_Instance_Created()
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString()
            };
        
            Assert.NotNull(product);
        }

    }
}