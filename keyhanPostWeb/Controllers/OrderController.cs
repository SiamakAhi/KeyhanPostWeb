using keyhanPostWeb.Areas.CMS.Dtos;
using keyhanPostWeb.Areas.KP.Dto;
using keyhanPostWeb.Areas.KP.KPInterfaces;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.GeneralViewModels.Order;
using keyhanPostWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keyhanPostWeb.GeneralService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace keyhanPostWeb.Controllers
{

    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly AppDbContext _context;
        private readonly IRepresentativeService _jobService;
        private readonly IRepresentativeService _representativeService;

        public OrdersController(IOrderService orderService, AppDbContext context, IRepresentativeService representativeService, IRepresentativeService jobService)
        {
            _orderService = orderService;
            _context = context;
            _representativeService = representativeService;
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> KpCreateOrder(int? orderId = null)
        {
            // دریافت لیست شهرها
            var allowedCityIds = new List<int> { 25, 57, 65, 89 };
            var originCities = await _representativeService.SelectList_Cities_FilteredByIds(allowedCityIds);
            var cities = await _representativeService.SelectList_Cities();
            ViewBag.EntityTypes = await _jobService.GetEntityTypesAsync();
            var model = new CreateOrderVm
            {

                OriginCities = originCities,
                Cities = cities
            };
            // اگر orderId نال است، کاربر تازه وارد شده و در Step0 است
            if (orderId == null)
            {
                model.Step = 0;
            }
            else
            {
                // تلاش برای یافتن سفارش
                var ordersStep = await _orderService.GetCrrentStepOrderByOrderIdAsync(orderId.Value);

                if (ordersStep == null)
                {
                    // اگر پیدا نشد، به مرحله صفر برگرد
                    model.Step = 0;
                    model.OrderId = null;
                }
                else
                {
                    // اینجا می‌توانید بر اساس وضعیت سفارش Step صحیح را تعیین کنید
                    model.Step = ordersStep ?? 0;
                    ViewBag.orderId = orderId;
                }
            }


            var vm = new VmSiteContent
            {
                OrderCreate = model
            };

            return View(vm);

        }
        [HttpPost]
        public async Task<IActionResult> KpCreateOrderStep0(VmSiteContent model)
        {
            // فقط مدل مرحله 0 را validate کن
            ModelState.Clear();
            TryValidateModel(model.OrderCreate.Step0Vm, "OrderCreate.Step0Vm");

            if (!ModelState.IsValid)
            {
                // اگر ورودی اشتباه بود، دوباره همان View را با مدل فعلی برگردان
                return View("KpCreateOrder", model);
            }

            try
            {
                var ordervm = model.OrderCreate.Step0Vm;
                var result = await _orderService.CreateStep0Async(ordervm);

                if (result.Success)
                {
                    TempData["ValidationErrors"] = string.Join("<br>",
                   ModelState.Values
                  .SelectMany(v => v.Errors)
                  .Select(e => e.ErrorMessage));
                    return RedirectToAction("KpCreateOrder", new { orderId = result.OrderId });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateOrder", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> KpCreateOrderStep1(VmSiteContent model)
        {
            // فقط مدل مرحله 1 را validate کن
            ModelState.Clear();
            TryValidateModel(model.OrderCreate.Step1Vm, "OrderCreate.Step1Vm");

            if (!ModelState.IsValid)
            {
                TempData["ValidationErrors"] = string.Join("<br>",
               ModelState.Values
             .SelectMany(v => v.Errors)
             .Select(e => e.ErrorMessage));
                return View("KpCreateOrder", model);
            }

            try
            {
                var ordervm = model.OrderCreate.Step1Vm;
                var result = await _orderService.CreateStep1Async(ordervm);

                if (result.Success)
                {
                    // هدایت به اکشن اصلی برای بارگذاری مرحله بعد
                    return RedirectToAction("KpCreateOrder", new { orderId = result.OrderId });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateOrder", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> KpCreateOrderStep2(VmSiteContent model)
        {

            ModelState.Clear();
            TryValidateModel(model.OrderCreate.Step2Vm, "OrderCreate.Step2Vm");

            if (!ModelState.IsValid)
            {
                var orderId = model.OrderCreate.Step2Vm.OrderId;
                TempData["ValidationErrors"] = string.Join("<br>",
                ModelState.Values
              .SelectMany(v => v.Errors)
              .Select(e => e.ErrorMessage));
                return RedirectToAction("KpCreateOrder", new { orderId = orderId });
            }

            try
            {
                var ordervm = model.OrderCreate.Step2Vm;
                var result = await _orderService.CreateStep2Async(ordervm);

                if (result.Success)
                {
                    // هدایت به اکشن اصلی برای بارگذاری مرحله بعد
                    return RedirectToAction("KpCreateOrder", new { orderId = result.OrderId });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateOrder", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> KpCreateOrderStep3(VmSiteContent model)
        {

            ModelState.Clear();
            TryValidateModel(model.OrderCreate.Step3Vm, "OrderCreate.Step3Vm");

            if (!ModelState.IsValid)
            {
                var orderId = model.OrderCreate.Step3Vm.OrderId;
                TempData["ValidationErrors"] = string.Join("<br>",
        ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
                return RedirectToAction("KpCreateOrder", new { orderId = orderId });
            }

            try
            {
                var ordervm = model.OrderCreate.Step3Vm;
                var result = await _orderService.CreateStep3Async(ordervm);

                if (result.Success)
                {
                    // هدایت به اکشن اصلی برای بارگذاری مرحله بعد
                    return RedirectToAction("KpCreateOrder", new { orderId = result.OrderId });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateOrder", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> KpCreateOrderStep4(VmSiteContent model)
        {

            ModelState.Clear();
            TryValidateModel(model.OrderCreate.Step4Vm, "OrderCreate.Step4Vm");

            if (!ModelState.IsValid)
            {
                var orderId = model.OrderCreate.Step4Vm.OrderId;
                TempData["ValidationErrors"] = string.Join("<br>",
        ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
                return RedirectToAction("KpCreateOrder", new { orderId = orderId });
            }

            try
            {
                var ordervm = model.OrderCreate.Step4Vm;
                var result = await _orderService.CreateStep4Async(ordervm);

                if (result.Success)
                {

                    // کد رهگیری را داخل مدل بگذار
                    ViewBag.TrackingCode = result.Data;
                    model.OrderCreate.Step = 5;
                    return View("KpCreateOrder", model);
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateOrder", model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetOrderDetail(int orderId)
        {

            var model = await _orderService.GetOrderDetailByOrderIdAsync(orderId);
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetOrders([FromQuery] OrderFilterDto? filter)
        {
            ViewBag.Cities = await _representativeService.SelectList_Cities();

            filter.FromDate = filter.StrFromDate?.PersianToLatin();
            filter.ToDate = filter.StrToDate?.PersianToLatin();


            var orders = await _orderService.GetAllOrdersAsync(filter);



            return View(orders);
        }

        [Authorize]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> NewOrders()
        {
            var filter = new OrderFilterDto { StatusId = 1 };
            var orders = await _orderService.GetAllOrdersAsync(filter);

            var vm = new VmSiteContent
            {
                GetOrderVm = orders
            };

            return View(vm);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CurrentOrders()
        {
            var filter = new OrderFilterDto { StatusId = 2 };
            var orders = await _orderService.GetAllOrdersAsync(filter);

            var vm = new VmSiteContent
            {
                GetOrderVm = orders
            };

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> ArchivedOrders()
        {
            var filter = new OrderFilterDto { StatusId = 3 };
            var orders = await _orderService.GetAllOrdersAsync(filter);

            var vm = new VmSiteContent
            {
                GetOrderVm = orders
            };

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CanceledOrders()
        {
            var filter = new OrderFilterDto { StatusId = 4 };
            var orders = await _orderService.GetAllOrdersAsync(filter);

            var vm = new VmSiteContent
            {
                GetOrderVm = orders
            };

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> KpCreateInternationalOrder(int? orderId = null)
        {
            var contries = _representativeService.SelectList_Countries();
            var cities = await _representativeService.SelectList_Cities();
            var model = new CreateInOrderVm
            {
                contries = contries,
                Cities = cities
            };
            // اگر orderId نال است، کاربر تازه وارد شده و در Step0 است
            if (orderId == null)
            {
                model.Step = 0;
            }
            else
            {
                // تلاش برای یافتن سفارش
                var ordersStep = await _orderService.In_GetCrrentStepOrderByOrderIdAsync(orderId.Value);

                if (ordersStep == null)
                {
                    // اگر پیدا نشد، به مرحله صفر برگرد
                    model.Step = 0;
                    model.OrderId = null;
                }
                else
                {
                    // اینجا می‌توانید بر اساس وضعیت سفارش Step صحیح را تعیین کنید
                    model.Step = ordersStep ?? 0;
                    ViewBag.orderId = orderId;
                }
            }
            var vm = new VmSiteContent
            {
                InOrderCreate = model
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> KpCreateInOrderStep0(VmSiteContent model)
        {
            // فقط مدل مرحله 0 را validate کن
            ModelState.Clear();
            TryValidateModel(model.InOrderCreate.InStep0Vm, "InOrderCreate.InStep0Vm");

            if (!ModelState.IsValid)
            {
                // اگر ورودی اشتباه بود، دوباره همان View را با مدل فعلی برگردان
                return View("KpCreateInternationalOrder", model);
            }

            try
            {
                var ordervm = model.InOrderCreate.InStep0Vm;
                var result = await _orderService.In_CreateStep0Async(ordervm);

                if (result.Success)
                {
                    TempData["ValidationErrors"] = string.Join("<br>",
                   ModelState.Values
                  .SelectMany(v => v.Errors)
                  .Select(e => e.ErrorMessage));
                    return RedirectToAction("KpCreateInternationalOrder", new { orderId = result.OrderId });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateInternationalOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateInternationalOrder", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> KpCreateInOrderStep1(VmSiteContent model)
        {
            // فقط مدل مرحله 1 را validate کن
            ModelState.Clear();
            TryValidateModel(model.InOrderCreate.InStep1Vm, "InOrderCreate.InStep1Vm");

            if (!ModelState.IsValid)
            {
                TempData["ValidationErrors"] = string.Join("<br>",
               ModelState.Values
             .SelectMany(v => v.Errors)
             .Select(e => e.ErrorMessage));
                return View("KpCreateInternationalOrder", model);
            }

            try
            {
                var ordervm = model.InOrderCreate.InStep1Vm;
                var result = await _orderService.In_CreateStep1Async(ordervm);

                if (result.Success)
                {
                    // هدایت به اکشن اصلی برای بارگذاری مرحله بعد
                    return RedirectToAction("KpCreateInternationalOrder", new { orderId = result.OrderId });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateInternationalOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateInternationalOrder", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> KpCreateInOrderStep2(VmSiteContent model)
        {

            ModelState.Clear();
            TryValidateModel(model.InOrderCreate.InStep2Vm, "InOrderCreate.InStep2Vm");

            if (!ModelState.IsValid)
            {
                var orderId = model.InOrderCreate.InStep2Vm.OrderId;
                TempData["ValidationErrors"] = string.Join("<br>",
                ModelState.Values
              .SelectMany(v => v.Errors)
              .Select(e => e.ErrorMessage));
                return RedirectToAction("KpCreateInternationalOrder", new { orderId = orderId });
            }

            try
            {
                var ordervm = model.InOrderCreate.InStep2Vm;
                var result = await _orderService.In_CreateStep2Async(ordervm);

                if (result.Success)
                {
                    // هدایت به اکشن اصلی برای بارگذاری مرحله بعد
                    return RedirectToAction("KpCreateInternationalOrder", new { orderId = result.OrderId });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateInternationalOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateInternationalOrder", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> KpCreateInOrderStep3(VmSiteContent model)
        {

            ModelState.Clear();
            TryValidateModel(model.InOrderCreate.InStep3Vm, "InOrderCreate.InStep3Vm");

            if (!ModelState.IsValid)
            {
                var orderId = model.OrderCreate.Step4Vm.OrderId;
                TempData["ValidationErrors"] = string.Join("<br>",
        ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
                return RedirectToAction("KpCreateInternationalOrder", new { orderId = orderId });
            }

            try
            {
                var ordervm = model.InOrderCreate.InStep3Vm;
                var result = await _orderService.In_CreateStep3Async(ordervm);

                if (result.Success)
                {

                    // کد رهگیری را داخل مدل بگذار
                    ViewBag.TrackingCode = result.Data;
                    model.InOrderCreate.Step = 4;
                    return View("KpCreateInternationalOrder", model);
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("KpCreateInternationalOrder", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی رخ داده است: " + ex.Message);
                return View("KpCreateInternationalOrder", model);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetInOrderDetail(int orderId)
        {

            var model = await _orderService.GetInOrderDetailByOrderIdAsync(orderId);
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetInOrders([FromQuery] InOrderFilterDto? filter)
        {
            var countries = _representativeService.SelectList_Countries();

            ViewBag.Countries = countries;

            filter.FromDate = filter.StrFromDate?.PersianToLatin();
            filter.ToDate = filter.StrToDate?.PersianToLatin();

            var orders = await _orderService.GetAllInOrdersAsync(filter);



            return View(orders);
        }


        //-----------------------------بارنامه های بین المللی------------------------------//

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateWaybill()
        {
            var countries = _representativeService.SelectList_Countries();
            var statuses = _orderService.SelectList_WaybillStatuses().Result;

            ViewBag.Statuses = statuses;
            ViewBag.Countries = countries;

            return PartialView("_CreateWayBill", new CreateWaybillDto());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateWayBill(CreateWaybillDto dto)
        {
            clsResult result = new clsResult();

            if (ModelState.IsValid)
            {
                dto.CreateAt = dto.StrCreateAt.PersianToLatin();
                result = await _orderService.CreateWaybillAsync(dto);

                if (result.Success)
                {
                    result.ShowMessage = true;
                    result.returnUrl = Request.Headers["Referer"].ToString();
                    result.updateType = 1;

                    string jsonResult = JsonConvert.SerializeObject(result);
                    return Json(jsonResult);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(n => n.Errors).ToList();
                foreach (var er in errors)
                {
                    result.Message += $"\n {er.ErrorMessage}";
                }
            }

            result.Success = false;
            result.ShowMessage = true;

            string json_Result = JsonConvert.SerializeObject(result);
            return Json(json_Result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAllWaybill([FromQuery] InternationalWaybillFilterDto? filter)
        {
            var countries = _representativeService.SelectList_Countries();

            ViewBag.Countries = countries;

            
            var data = await _orderService.GetAllWaybillsAsync(filter);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetCurrentWayBills([FromQuery] InternationalWaybillFilterDto? filter)
        {
            var countries = _representativeService.SelectList_Countries();

            ViewBag.Countries = countries;
           
            filter.ExcludeStatusId = 11;
            var data = await _orderService.GetAllWaybillsAsync(filter);
            return View(data);
        }
      
        [HttpGet]
        public async Task<IActionResult> GetWaybillHistory(string wayBillNumber)
        {
           
            var vm = new VmSiteContent();
            vm.WaybillHistory = await _orderService.GetWaybillHistoryAsync(wayBillNumber);
            return View("KPIndex", vm);

        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult ChangeStatus(int waybillId)
        {
            var statuses = _orderService.SelectList_WaybillStatuses().Result;

            ViewBag.Statuses = statuses;

            return PartialView("_ChangeStatus", new ChangeWaybillStatusDto
            {
                WaybillId = waybillId
            });
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> ChangeStatus(ChangeWaybillStatusDto dto)
        {
            clsResult result = new clsResult();

            if (ModelState.IsValid)
            {
                dto.ChangedAt = dto.StrChangedAt.PersianToLatin();
                result = await _orderService.ChangeStatusAsync(dto);

                if (result.Success)
                {
                    result.ShowMessage = true;
                    result.returnUrl = Request.Headers["Referer"].ToString();
                    result.updateType = 1;
                    

                    string jsonResult = JsonConvert.SerializeObject(result);
                    return Json(jsonResult);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(n => n.Errors).ToList();
                foreach (var er in errors)
                {
                    result.Message += $"\n {er.ErrorMessage}";
                }
            }

            result.Success = false;
            result.ShowMessage = true;

            string json_Result = JsonConvert.SerializeObject(result);
            return Json(json_Result);
        }

       

    }



}