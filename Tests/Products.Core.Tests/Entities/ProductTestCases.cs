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
                Id = Guid.NewGuid().ToString(),

                Name = "Some Product",

                Category = "Some Category",

                Summary = "Some Summary",

                Description = "Some Description",

                ImageFile = "Some ImageFile",

                Price = 1.0m,

                CreatedDateTime = DateTime.Now,

                ModifiedDateTime = DateTime.Now
            };

            // TODO: Add more asserts
            Assert.NotNull(product);
        }

    }
}