using System.Diagnostics.CodeAnalysis;
using Xunit;
using static Products.Core.Common.Constants;

namespace Products.Core.Tests.Common
{

    [ExcludeFromCodeCoverage]
    public class ConstantsTests
    {

        [Fact]
        public void When_Contants_File_Is_Accessed()
        {
            Assert.NotNull(MongoDbConnectionDetails.ConnectionString);

            Assert.NotNull(MongoDbConnectionDetails.DatabaseName);

            Assert.NotNull(MongoDbConnectionDetails.CollectionName);
        }

    }
}
