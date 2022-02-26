using Microsoft.Extensions.DependencyInjection;
using Products.Core.Interfaces;
using Products.Data;

namespace Products.Infrastructure
{

    public static class ProductContextDependencies
    {
        public static IServiceCollection ConfigureProductContextServices(this IServiceCollection services)
        {
            services.AddScoped<IProductContext, ProductContext>();

            return services;
        }
    }

}
