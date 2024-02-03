using Mango.Services.Web.Models.Dto;
using Mango.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Mango.Web.Services;
using Newtonsoft.Json;
using Mango.Web.Models;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService=couponService;
        }

        public  async Task <IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await _couponService.GetAllCouponAsync();
            if (response != null && response.IsSuccess)
            {
                list=JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

		public async Task<IActionResult> CouponCreate()
		{			
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["Success"] = "Coupon Created Successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(model);
        }

        public async Task<IActionResult> CouponDelete(int CouponId)
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(CouponId);
            if (response != null && response.IsSuccess)
            {
                CouponDto model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            } 
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? response = await _couponService.DeleteCouponAsync(couponDto.CouponId);
            if (response != null && response.IsSuccess)
            {
                TempData["Success"] = "Coupon Deleted Successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(couponDto);

        }
    }
}
