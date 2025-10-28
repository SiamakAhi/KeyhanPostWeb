using keyhanPostWeb.Areas.CMS.Dtos;
using keyhanPostWeb.Areas.KP.Dto;
using keyhanPostWeb.Areas.KP.KPInterfaces;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.GeneralViewModels.Order;
using keyhanPostWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace keyhanPostWeb.Controllers
{
   
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly AppDbContext _context;
        private readonly IRepresentativeService _representativeService;

        public OrdersController(IOrderService orderService, AppDbContext context, IRepresentativeService representativeService)
        {
            _orderService = orderService;
            _context = context;
           _representativeService = representativeService; 
        }
        [HttpGet]
        public async  Task< IActionResult> KpCreateOrder()
        {
            var cities = await _representativeService.SelectList_Cities();

            // ساخت ViewModel
            var order = new OrderCreateViewModel
            {
                Cities = cities
            };

            // مدل کلی صفحه (VmSiteContent)
            var vm = new VmSiteContent
            {
                OrderCreate = order
            };

            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> KpCreateOrder(VmSiteContent model)
        {
            clsResult result = new clsResult();
            var ordervm = model.OrderCreate;

            try
            {
                result = await _orderService.CreateOrderAsync(ordervm);

                if (result.Success)
                {
                    result.Message = "سفارش شما با موفقیت ثبت شد ✅";
                    result.ShowMessage = true;
                    result.updateType = 1;
                    result.returnUrl = Url.Action("KPOrder", "Home"); // آدرس صفحه ثبت سفارش
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطایی در هنگام ثبت سفارش رخ داده است: " + ex.Message;
            }

          
            return Json(result);
        }

        public IActionResult OrderSummary(OrderCreateViewModel model)
        {
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders(OrderFilterDto? filter = null)
        {
            // دریافت لیست سفارش‌ها با اعمال فیلتر
            var orders = await _orderService.GetAllOrdersAsync(filter);

           
            var vm = new VmSiteContent
            {
                OrderCreate = orders?.FirstOrDefault()
            };

            return View(vm);
        }

    }
}
