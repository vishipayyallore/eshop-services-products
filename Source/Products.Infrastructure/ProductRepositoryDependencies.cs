using Microsoft.Extensions.DependencyInjection;
using Products.Core.Interfaces;
using Products.Repository;

namespace Products.Infrastructure
{

    public static class ProductRepositoryDependencies
    {

        public static IServiceCollection ConfigureProductRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

    }

}
