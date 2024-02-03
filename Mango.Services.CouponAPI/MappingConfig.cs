using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig=new MapperConfiguration(config => // this will tell that i will provide to the  Coupon Dto You Convert it into Coupon  
            {
                config.CreateMap<CouponDto, Coupon>();  // Source , Destination 
                config.CreateMap<Coupon, CouponDto>();
            });

            return mappingConfig;
        }
    }
}
