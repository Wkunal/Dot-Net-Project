using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig=new MapperConfiguration(config => // this will tell that i will provide to the  Coupon Dto You Convert it into Coupon  
            {
                config.CreateMap<ProductDto, Product>();  // Source , Destination 
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
