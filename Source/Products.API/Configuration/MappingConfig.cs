using AutoMapper;
using Products.Core.Dtos;
using Products.Core.Entities;

namespace Products.API.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public class MappingConfig
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                _ = config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }

    }

}
