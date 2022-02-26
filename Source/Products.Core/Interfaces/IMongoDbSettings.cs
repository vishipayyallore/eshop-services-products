namespace Products.Core.Interfaces
{

    public interface IMongoDbSettings
    {
        string ConnectionString { get; }

        string DatabaseName { get; }

        string CollectionName { get; }
    }

}
