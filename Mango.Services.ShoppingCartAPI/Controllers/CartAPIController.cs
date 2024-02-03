using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
        private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;
        private readonly AppDbContext _db;

        public CartAPIController(ResponseDto responseDto,IMapper mapper, AppDbContext db)
        {
            _responseDto = responseDto;
            _mapper = mapper;
            _db = db;
        }

        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto)
        {
            var cartHeaderFromDb = await _db.CartHeaders.FirstOrDefaultAsync(u=>u.UserId==cartDto.CartHeader.UserId);
            if (cartHeaderFromDb == null)
            {

            }
            else
            {
                //if Header is not null 
                //check if details has same product
                _db.CartDetails.FirstOrDefault(u => u.ProductId == cartDto.CartDetails.First().ProductId);
            }
        }




    }
}
