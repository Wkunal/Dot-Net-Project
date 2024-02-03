using Mango.Services.Web.Models.Dto;
using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IBaseService
    { 
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
