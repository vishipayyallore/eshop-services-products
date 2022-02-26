using MongoDB.Driver;
using Products.Core.Entities;

namespace Products.Core.Interfaces
{

    public interface ICatalogContext
    {

        IMongoCollection<Product> Products { get; }

    }

}
