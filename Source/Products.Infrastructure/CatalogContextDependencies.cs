using Microsoft.Extensions.DependencyInjection;
using Products.Core.Interfaces;
using Products.Data;

namespace Products.Infrastructure
{

    public static class CatalogContextDependencies
    {
        public static IServiceCollection ConfigureCatalogContextServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogContext, CatalogContext>();

            return services;
        }
    }

}
