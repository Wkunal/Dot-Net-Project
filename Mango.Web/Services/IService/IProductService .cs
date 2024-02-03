using Mango.Services.Web.Models.Dto;
using Mango.Web.Models;

namespace Mango.Web.Services.IService
{
    public interface IProductService
    {
        //Task<ResponseDto?> GetProductAsync(string couponCode);
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}
