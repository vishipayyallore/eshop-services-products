namespace Products.Core.Common
{

    public static class Constants
    {

        public static class MongoDbConnectionDetails
        {
            public static string CollectionName { get; } = "MongoDbSettings:CollectionName";

            public static string ConnectionString { get; } = "MongoDbSettings:ConnectionString";

            public static string DatabaseName { get; } = "MongoDbSettings:DatabaseName";
        }

    }

}
