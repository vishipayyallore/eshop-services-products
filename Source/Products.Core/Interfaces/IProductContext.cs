using MongoDB.Driver;
using Products.Core.Entities;

namespace Products.Core.Interfaces
{

    public interface IProductContext
    {

        IMongoCollection<Product> Products { get; }

    }

}
