using keyhanPostWeb.Areas.KP.Dto;
using keyhanPostWeb.Areas.KP.KPInterfaces;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.Classes;
using keyhanPostWeb.GeneralViewModels.Order;
using keyhanPostWeb.GeneralViewModels.RepDto;
using keyhanPostWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using static keyhanPostWeb.GeneralViewModels.Order.CreateInOrderVm;
using static keyhanPostWeb.GeneralViewModels.Order.CreateOrderVm;


namespace keyhanPostWeb.Areas.KP.KPServices
{
    public class OrderService : IOrderService
       
    {
        private readonly AppDbContext _context;
        private readonly IRepresentativeService _representativeService; 

        public OrderService(AppDbContext context,IRepresentativeService representativeService)
        {
            _context = context;
            _representativeService = representativeService;
        }

        //-------------------مرحله های ثبت سفارش داخلی-------------------------//

        // مرحله0 - ثبت موبایل
        public async Task<clsResult> CreateStep0Async(CreateOrderStep0Vm dto)
        {
            clsResult result = new clsResult();

            var order = new Order
            {
                MobileForOtp = dto.Mobile,
                TrackingCode = GenerateTrackingCode(false),
                CreatedAt = DateTime.Now,
                OrderStatusId = 1 ,// وضعیت اولیه
                CurrentStep=1
            };

            _context.Orders.Add(order);

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "سفارش با موفقیت ایجاد شد.";
                result.OrderId = order.Id;
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ایجاد سفارش: " + ex.Message;
            }

            return result;
        }
        // مرحله 1 - آپدیت نوع بسته
        public async Task<clsResult> CreateStep1Async(CreateOrderStep1Vm dto)
        {
            clsResult result = new clsResult();
            var order = await _context.Orders.FindAsync(dto.OrderId);

            if (order == null)
            {
                result.Success = false;
                result.Message = "سفارش یافت نشد.";
                return result;
            }

            order.PackageTypeId = dto.PackageTypeId;
            order.CurrentStep = 2;

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "نوع بسته با موفقیت ذخیره شد.";
                result.OrderId = order.Id;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره نوع بسته: " + ex.Message;
            }

            return result;
        }
        // مرحله 2 - آپدیت شهر مبدا، مقصد، وزن و ابعاد
        public async Task<clsResult> CreateStep2Async(CreateOrderStep2Vm dto)
        {
            clsResult result = new clsResult();
            var order = await _context.Orders.FindAsync(dto.OrderId);

            if (order == null)
            {
                result.Success = false;
                result.Message = "سفارش یافت نشد.";
                return result;
            }

            order.OriginCityId = dto.OriginCityId;
            order.DestinationCityId = dto.DestinationCityId;
            order.Length = dto.Length;
            order.Width = dto.Width;
            order.Height = dto.Height;
            order.ActualWeight = dto.ActualWeight;
            order.DeliveryVehicleType = dto.DeliveryVehicleType;
            order.CurrentStep = 3;

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "اطلاعات با موفقیت ذخیره شد.";
                result.OrderId = order.Id;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره اطلاعات بسته: " + ex.Message;
            }

            return result;
        }
        // مرحله 3 - آپدیت اطلاعات فرستنده
        public async Task<clsResult> CreateStep3Async(CreateOrderStep3Vm dto)
        {
            clsResult result = new clsResult();
            var order = await _context.Orders.FindAsync(dto.OrderId);

            if (order == null)
            {
                result.Success = false;
                result.Message = "سفارش یافت نشد.";
                return result;
            }

            order.SenderEntityTypeId = dto.SenderEntityTypeId;
            order.SenderFirstName = dto.SenderFirstName;
            order.SenderLastName = dto.SenderLastName;
            order.SenderNationalId = dto.SenderNationalId;
            order.SenderMobile = dto.SenderMobile;
            order.SenderPhone = dto.SenderPhone;
            order.SenderAddress = dto.SenderAddress;
            order.SenderCompanyName = dto.SenderCompanyName;
            order.SenderCompanyNationalId = dto.SenderCompanyNationalId;
            order.CurrentStep = 4;

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "اطلاعات فرستنده با موفقیت ذخیره شد.";
                result.OrderId = order.Id;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره اطلاعات فرستنده: " + ex.Message;
            }

            return result;
        }
        // مرحله 4 - آپدیت اطلاعات گیرنده
        public async Task<clsResult> CreateStep4Async(CreateOrderStep4Vm dto)
        {
            clsResult result = new clsResult();
            var order = await _context.Orders.FindAsync(dto.OrderId);

            if (order == null)
            {
                result.Success = false;
                result.Message = "سفارش یافت نشد.";
                return result;
            }
            order.ReceiverEntityTypeId = dto.ReceiverEntityTypeId;
            order.ReceiverFirstName = dto.ReceiverFirstName;
            order.ReceiverLastName = dto.ReceiverLastName;
            order.ReceiverNationalId = dto.ReceiverNationalId;
            order.ReceiverMobile = dto.ReceiverMobile;
            order.ReceiverPhone = dto.ReceiverPhone;
            order.ReceiverAddress = dto.ReceiverAddress;
            order.ReceiverCompanyName = dto.ReceiverCompanyName;
            order.ReceiverCompanyNationalId = dto.ReceiverCompanyNationalId;
            order.OrderStatusId = 2;
            order.CurrentStep = 5;

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "اطلاعات گیرنده با موفقیت ذخیره شد.";
                result.OrderId = order.Id;
                result.Data = order.TrackingCode;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره اطلاعات گیرنده: " + ex.Message;
            }

            return result;
        }
        //-------------------GetOrders-------------------------//
        public async Task<short?> GetCrrentStepOrderByOrderIdAsync(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return null;

            return order.CurrentStep;
        }
        public async Task<GetOrderDetailVm?> GetOrderDetailByOrderIdAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.SenderEntityType)
                .Include(o => o.ReceiverEntityType)
                .Where(o => o.Id == orderId)
                .Select(o => new
                {
                    o.Id,
                    o.MobileForOtp,
                    o.PackageTypeId,
                    o.OriginCityId,
                    o.DestinationCityId,
                    o.Length,
                    o.Width,
                    o.Height,
                    o.ActualWeight,
                    o.DeliveryVehicleType,
                    SenderEntityTypeName = o.SenderEntityType != null ? o.SenderEntityType.EntityTitle : null,
                    o.SenderFirstName,
                    o.SenderLastName,
                    o.SenderNationalId,
                    o.SenderMobile,
                    o.SenderPhone,
                    o.SenderAddress,
                    o.SenderCompanyName,
                    o.SenderCompanyNationalId,
                    ReceiverEntityTypeName = o.ReceiverEntityType != null ? o.ReceiverEntityType.EntityTitle : null,
                    o.ReceiverFirstName,
                    o.ReceiverLastName,
                    o.ReceiverNationalId,
                    o.ReceiverMobile,
                    o.ReceiverPhone,
                    o.ReceiverAddress,
                    o.ReceiverCompanyName,
                    o.ReceiverCompanyNationalId,
                    OrderStatusName = o.OrderStatus != null ? o.OrderStatus.Title : null,
                    o.TrackingCode,
                    o.CreatedAt
                })
                .FirstOrDefaultAsync();

            if (order == null)
                return null;

            // گرفتن نام شهر مبدا و مقصد
            var cityIds = new List<int?>(2) { order.OriginCityId, order.DestinationCityId };
            var cities = await _context.Cities
                .Where(c => cityIds.Contains(c.Id))
                .ToDictionaryAsync(c => c.Id, c => c.CityName);

            string? originCityName = order.OriginCityId.HasValue && cities.ContainsKey(order.OriginCityId.Value)
                ? cities[order.OriginCityId.Value]
                : null;

            string? destinationCityName = order.DestinationCityId.HasValue && cities.ContainsKey(order.DestinationCityId.Value)
                ? cities[order.DestinationCityId.Value]
                : null;

            // تبدیل نوع وسیله حمل به متن
            string? deliveryVehicleTypeName = order.DeliveryVehicleType switch
            {
                1 => "وانت",
                2 => "موتور",
                _ => "نامشخص"
            };

            // تبدیل PackageTypeId به نام خوانا
            string packageTypeName = order.PackageTypeId switch
            {
                1 => "کالای عادی",
                2 => "کالای الکترونیکی",
                3 => "پاکت",
                4 => "کالای فاسدشدنی",
                5 => "کالبد متوفی",
                6 => "حیوان خانگی",
                _ => "نامشخص"
            };

            var vm = new GetOrderDetailVm
            {
                Id = order.Id,
                MobileForOtp = order.MobileForOtp,
                PackageTypeName= packageTypeName,
                PackageTypeId = order.PackageTypeId,
                OriginCityName = originCityName,
                DestinationCityName = destinationCityName,

                Length = order.Length,
                Width = order.Width,
                Height = order.Height,
                ActualWeight = order.ActualWeight,
                DeliveryVehicleType = deliveryVehicleTypeName,

                SenderEntityType = order.SenderEntityTypeName,
                SenderFirstName = order.SenderFirstName,
                SenderLastName = order.SenderLastName,
                SenderNationalId = order.SenderNationalId,
                SenderMobile = order.SenderMobile,
                SenderPhone = order.SenderPhone,
                SenderAddress = order.SenderAddress,
                SenderCompanyName = order.SenderCompanyName,
                SenderCompanyNationalId = order.SenderCompanyNationalId,

                ReceiverEntityType = order.ReceiverEntityTypeName,
                ReceiverFirstName = order.ReceiverFirstName,
                ReceiverLastName = order.ReceiverLastName,
                ReceiverNationalId = order.ReceiverNationalId,
                ReceiverMobile = order.ReceiverMobile,
                ReceiverPhone = order.ReceiverPhone,
                ReceiverAddress = order.ReceiverAddress,
                ReceiverCompanyName = order.ReceiverCompanyName,
                ReceiverCompanyNationalId = order.ReceiverCompanyNationalId,

                OrderStatus = order.OrderStatusName,

                TrackingCode = order.TrackingCode,
                CreatedAt = order.CreatedAt
            };

            return vm;
        }
        public async Task<List<GetOrdersVM>> GetAllOrdersAsync(OrderFilterDto? filter = null)
        {
            var query = _context.Orders.AsQueryable();

            // --------------------- فیلترها ---------------------
            if (filter != null)
            {
                if (filter.StatusId.HasValue)
                    query = query.Where(o => o.OrderStatusId == filter.StatusId);

                if (filter.OriginCityId.HasValue)
                    query = query.Where(o => o.OriginCityId == filter.OriginCityId);

                if (filter.DestinationCityId.HasValue)
                    query = query.Where(o => o.DestinationCityId == filter.DestinationCityId);

                if (!string.IsNullOrEmpty(filter.SenderName))
                {
                    query = query.Where(o =>
                        o.SenderFirstName.Contains(filter.SenderName) ||
                        o.SenderLastName.Contains(filter.SenderName));
                }

                if (!string.IsNullOrEmpty(filter.ReceiverName))
                {
                    query = query.Where(o =>
                        o.ReceiverFirstName.Contains(filter.ReceiverName) ||
                        o.ReceiverLastName.Contains(filter.ReceiverName));
                }

                if (filter.FromDate.HasValue)
                    query = query.Where(o => o.CreatedAt.Date >= filter.FromDate.Value.Date);

                if (filter.ToDate.HasValue)
                    query = query.Where(o => o.CreatedAt.Date <= filter.ToDate.Value.Date);

            }

            // --------------------- گرفتن سفارش‌ها ---------------------
            var orders = await query
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new
                {
                    o.Id,
                    o.TrackingCode,
                    o.CreatedAt,
                    o.OriginCityId,
                    o.SenderFirstName,
                    o.SenderLastName,
                    o.ReceiverFirstName,
                    o.ReceiverLastName,
                    o.DestinationCityId,
                    o.SenderMobile,
                    o.ReceiverMobile,
                    o.PackageTypeId,
                    o.ActualWeight
                })
                .ToListAsync();

            // اگر سفارش خالی باشد، ادامه لازم نیست
            if (!orders.Any())
                return new List<GetOrdersVM>();

            // --------------------- گرفتن فقط شهرهای لازم ---------------------
            var neededCityIds = orders
                .SelectMany(o => new[] { o.OriginCityId, o.DestinationCityId }) // جمع مبدا و مقصد
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .Distinct()
                .ToList();

            var cities = await _context.Cities
                .Where(c => neededCityIds.Contains(c.Id))
                .ToDictionaryAsync(c => c.Id, c => c.CityName);

            // --------------------- تبدیل به ViewModel ---------------------
            var result = orders.Select(o => new GetOrdersVM
            {
                OrderId = o.Id,
                TrackingCode = o.TrackingCode,
                CreatedAt = o.CreatedAt,

                ReceiverName = $"{o.ReceiverFirstName} {o.ReceiverLastName}".Trim(),
                SenderName = $"{o.SenderFirstName} {o.SenderLastName}".Trim(),

                OriginCityName = o.OriginCityId.HasValue && cities.ContainsKey(o.OriginCityId.Value)
                    ? cities[o.OriginCityId.Value]
                    : null,

                DestinationCityName = o.DestinationCityId.HasValue && cities.ContainsKey(o.DestinationCityId.Value)
                    ? cities[o.DestinationCityId.Value]
                    : null,

                SenderMobile = o.SenderMobile,
                ReceiverMobile = o.ReceiverMobile,

                PackageTypeName = o.PackageTypeId switch
                {
                    1 => "کالای عادی",
                    2 => "کالای الکترونیکی",
                    3 => "پاکت",
                    4 => "کالای فاسدشدنی",
                    5 => "کالبد متوفی",
                    6 => "حیوان خانگی",
                    _ => "نامشخص"
                },

                ActualWeight = o.ActualWeight
            }).ToList();

            return result;
        }
        //-------------------مرحله های ثبت سفارش بین المللی-------------------------//

        // مرحله0 - ثبت موبایل
        public async Task<clsResult> In_CreateStep0Async(CreateInOrderStep0Vm dto)
        {
            clsResult result = new clsResult();

            var order = new InternationalOrder
            {
                MobileForOtp = dto.Mobile,
                TrackingCode = GenerateTrackingCode(false),
                CreatedAt = DateTime.Now,
                OrderStatusId = 1,// وضعیت اولیه
                CurrentStep = 1
            };

            _context.InternationalOrders.Add(order);

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "سفارش با موفقیت ایجاد شد.";
                result.OrderId = order.Id;
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ایجاد سفارش: " + ex.Message;
            }

            return result;
        }
        // مرحله 1 - آپدیت نوع بسته
        public async Task<clsResult> In_CreateStep1Async(CreateInOrderStep1Vm dto)
        {
            clsResult result = new clsResult();
            var order = await _context.InternationalOrders.FindAsync(dto.OrderId);

            if (order == null)
            {
                result.Success = false;
                result.Message = "سفارش یافت نشد.";
                return result;
            }

            order.PackageTypeId = dto.PackageTypeId;
            order.CurrentStep = 2;

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "نوع بسته با موفقیت ذخیره شد.";
                result.OrderId = order.Id;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره نوع بسته: " + ex.Message;
            }

            return result;
        }
        // مرحله 2 - // مرحله 2 - آپدیت کشور مبدا، مقصد، وزن و ابعاد
        public async Task<clsResult> In_CreateStep2Async(CreateInOrderStep2Vm dto)
        {
            clsResult result = new clsResult();
            var order = await _context.InternationalOrders.FindAsync(dto.OrderId);

            if (order == null)
            {
                result.Success = false;
                result.Message = "سفارش یافت نشد.";
                return result;
            }

            order.OriginCountryName = dto.OriginCountryName;
            order.DestinationCountryName = dto.DestinationCountryName;
            order.Length = dto.Length;
            order.Width = dto.Width;
            order.Height = dto.Height;
            order.ActualWeight = dto.ActualWeight;
            order.CurrentStep = 3;

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "اطلاعات با موفقیت ذخیره شد.";
                result.OrderId = order.Id;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره اطلاعات: " + ex.Message;
            }

            return result;
        }
        // مرحله 3 - // مرحله 3- آپدیت اطلاعات درخواست کننده
        public async Task<clsResult> In_CreateStep3Async(CreateInOrderStep3Vm dto)
        {
            clsResult result = new clsResult();
            var order = await _context.InternationalOrders.FindAsync(dto.OrderId);

            if (order == null)
            {
                result.Success = false;
                result.Message = "سفارش یافت نشد.";
                return result;
            }

            order.RequesterFirstName = dto.RequesterFirstName;
            order.RequesterLastName = dto.RequesterLastName;
            order.RequesterMobile = dto.RequesterMobile;
            order.RequesterPhone = dto.RequesterPhone;
            order.RequesterCityId = dto.RequesterCityId;
            order.CurrentStep = 4;
            order.OrderStatusId = 2;

            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "اطلاعات با موفقیت ذخیره شد.";
                result.OrderId = order.Id;
                result.Data = order.TrackingCode;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره اطلاعات: " + ex.Message;
            }

            return result;
        }
        //-------------------Get International Orders-------------------------//
        public async Task<short?> In_GetCrrentStepOrderByOrderIdAsync(int orderId)
        {
            var order = await _context.InternationalOrders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return null;

            return order.CurrentStep;
        }
        private string GenerateTrackingCode(bool isInternational)
        {
            string prefix = isInternational ? "INT" : "DOM"; // Domestic

            return $"{prefix}-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
        }
        public async Task<List<GetInOrdersVm>> GetAllInOrdersAsync(InOrderFilterDto? filter = null)
        {
            var query = _context.InternationalOrders.AsQueryable();

            // --------------------- اعمال فیلترها --------------------- //
            if (filter != null)
            {
                if (filter.StatusId.HasValue)
                    query = query.Where(o => o.OrderStatusId == filter.StatusId);

                if (!string.IsNullOrWhiteSpace(filter.RequesterName))
                {
                    query = query.Where(o =>
                        (o.RequesterFirstName + " " + o.RequesterLastName).Contains(filter.RequesterName));
                }

                if (!string.IsNullOrEmpty(filter.OriginCountryName))
                    query = query.Where(o => o.OriginCountryName.Contains(filter.OriginCountryName));

                if (!string.IsNullOrEmpty(filter.DestinationCountryName))
                    query = query.Where(o => o.DestinationCountryName.Contains(filter.DestinationCountryName));

                if (filter.FromDate.HasValue)
                    query = query.Where(o => o.CreatedAt.Date >= filter.FromDate.Value.Date);

                if (filter.ToDate.HasValue)
                    query = query.Where(o => o.CreatedAt.Date <= filter.ToDate.Value.Date);
            }

            // --------------------- دریافت سفارش‌ها --------------------- //
            var orders = await query
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new
                {
                    o.Id,
                    o.CreatedAt,
                    o.TrackingCode,
                    o.PackageTypeId,
                    o.OriginCountryName,
                    o.DestinationCountryName,
                    o.ActualWeight,
                    o.RequesterFirstName,
                    o.RequesterLastName,
                    o.RequesterMobile,
                    o.RequesterCityId
                })
                .ToListAsync();

            if (!orders.Any())
                return new List<GetInOrdersVm>();

            var cities = await _context.Cities
                .ToDictionaryAsync(x => x.Id, x => x.CityName);

            // --------------------- تبدیل به ViewModel --------------------- //
            var result = orders.Select(o => new GetInOrdersVm
            {
                Id = o.Id,
                TrackingCode = o.TrackingCode,
                CreatedAt = o.CreatedAt,

                PackageTypeName = o.PackageTypeId switch
                {
                    1 => "کالای عادی",
                    2 => "کالای الکترونیکی",
                    3 => "پاکت",
                    4 => "کالای فاسد شدنی",
                    5 => "کالبد متوفی",
                    6 => "حیوان خانگی",
                    _ => "نامشخص"
                },

                OriginCountryName = o.OriginCountryName,
                DestinationCountryName = o.DestinationCountryName,
                ActualWeight = o.ActualWeight,

                RequesterName = $"{o.RequesterFirstName} {o.RequesterLastName}".Trim(),
                RequesterMobile = o.RequesterMobile,

                RequesterCityName = o.RequesterCityId.HasValue && cities.ContainsKey(o.RequesterCityId.Value)
                    ? cities[o.RequesterCityId.Value]
                    : null
            }).ToList();

            return result;
        }
        public async Task<GetInOrderDetailVm?> GetInOrderDetailByOrderIdAsync(int orderId)
        {
            var order = await _context.InternationalOrders
                .Include(o => o.OrderStatus)
                .Where(o => o.Id == orderId)
                .Select(o => new
                {
                    o.Id,
                    o.MobileForOtp,
                    o.PackageTypeId,

                    o.OriginCountryName,
                    o.DestinationCountryName,

                    o.Length,
                    o.Width,
                    o.Height,
                    o.ActualWeight,

                    o.RequesterFirstName,
                    o.RequesterLastName,
                    o.RequesterMobile,
                    o.RequesterPhone,
                    o.RequesterCityId,

                    OrderStatusName = o.OrderStatus != null ? o.OrderStatus.Title : null,
                    o.TrackingCode,
                    o.CreatedAt
                })
                .FirstOrDefaultAsync();

            if (order == null)
                return null;

            // گرفتن نام شهر درخواست‌کننده
            string? requesterCityName = null;
            if (order.RequesterCityId.HasValue)
            {
                requesterCityName = await _context.Cities
                    .Where(c => c.Id == order.RequesterCityId.Value)
                    .Select(c => c.CityName)
                    .FirstOrDefaultAsync();
            }

            // تبدیل PackageTypeId به نام خوانا
            string packageTypeName = order.PackageTypeId switch
            {
                1 => "کالای عادی",
                2 => "کالای الکترونیکی",
                3 => "پاکت",
                4 => "کالای فاسد شدنی",
                5 => "کالبد متوفی",
                6 => "حیوان خانگی",
                _ => "نامشخص"
            };

            // ساخت ViewModel نهایی
            var vm = new GetInOrderDetailVm
            {
                MobileForOtp = order.MobileForOtp,
                PackageTypeName = packageTypeName,

                OriginCountryName = order.OriginCountryName,
                DestinationCountryName = order.DestinationCountryName,

                Length = order.Length,
                Width = order.Width,
                Height = order.Height,
                ActualWeight = order.ActualWeight,

                RequesterName = $"{order.RequesterFirstName} {order.RequesterLastName}".Trim(),
                RequesterMobile = order.RequesterMobile,
                RequesterPhone = order.RequesterPhone,
                RequesterCityName = requesterCityName,

                OrderStatus = order.OrderStatusName ?? "نامشخص",
                TrackingCode = order.TrackingCode,
                CreatedAt = order.CreatedAt
            };

            return vm;
        }
        //---------------------------WaybillService ---------------------------------//

        
        //تولید شماره بارنامه//
        private string GenerateWaybillNumber()
        {
         
            return $"KP-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
        }
        // ---------------------------------------------------------
        // 1) ثبت بارنامه جدید
        // ---------------------------------------------------------
        public async Task<clsResult> CreateWaybillAsync(CreateWaybillDto dto)
        {
            clsResult result = new clsResult();

            int lastCounter = await _context.InternationalWaybill
                .AsNoTracking()
                .MaxAsync(x => (int?)x.WaybillCounter) ?? 0;

            int newCounter = lastCounter + 1;

            // بررسی وضعیت اولیه
            var status = await _context.WaybillStatus
                .FirstOrDefaultAsync(x => x.Id == dto.StatusId);

            if (status == null)
            {
                result.Success = false;
                result.Message = "وضعیت انتخاب شده معتبر نیست.";
                return result;
            }

            // اگر متد GenerateWaybillNumber فقط پیشوند KP- تولید می‌کند
            string generatedWaybillNumber = GenerateWaybillNumber() + newCounter;

            // ساخت بارنامه ✅
            var waybill = new InternationalWaybill
            {
                WaybillNumber = generatedWaybillNumber,   // ✅ درست شد
                PackageCount = dto.PackageCount,
                PackageWeight = dto.PackageWeight,
                OriginCountryName = dto.OriginCountryName,
                DestinationCountryName = dto.DestinationCountryName,
                SenderName = dto.SenderName,
                ReceiverName = dto.ReceiverName,
                CurrentStatus = status.Title,
                CurrentStatusId = status.Id,
                CreateAt = dto.CreateAt,
                WaybillCounter = newCounter,            
            };

            try
            {
                _context.InternationalWaybill.Add(waybill);
                await _context.SaveChangesAsync();

                var history = new WaybillStatusHistory
                {
                    WaybillId = waybill.Id,
                    StatusId = status.Id,
                    ChangedAt = dto.CreateAt,
                };

                _context.WaybillStatusHistory.Add(history);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "بارنامه با موفقیت ثبت شد.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در ذخیره اطلاعات: " + ex.Message;
            }

            return result;
        }



        // ---------------------------------------------------------
        // 2) ویرایش وضعیت بارنامه (ثبت رکورد جدید)
        // ---------------------------------------------------------
        public async Task<clsResult> ChangeStatusAsync(ChangeWaybillStatusDto dto)
        {
            clsResult result = new clsResult();

            // پیدا کردن بارنامه
            var waybill = await _context.InternationalWaybill
                .FirstOrDefaultAsync(x => x.Id == dto.WaybillId);

            if (waybill == null)
            {
                result.Success = false;
                result.Message = "بارنامه یافت نشد.";
                return result;
            }

            // پیدا کردن وضعیت جدید
            var status = await _context.WaybillStatus
                .FirstOrDefaultAsync(x => x.Id == dto.NewStatusId);

            if (status == null)
            {
                result.Success = false;
                result.Message = "وضعیت انتخاب شده معتبر نیست.";
                return result;
            }

            try
            {
                // ✅ جلوگیری از ثبت تکراری وضعیت برای این بارنامه
                bool isDuplicate = await _context.WaybillStatusHistory
                    .AnyAsync(x => x.WaybillId == dto.WaybillId
                                && x.StatusId == dto.NewStatusId);

                if (isDuplicate)
                {
                    result.Success = false;
                    result.Message = "این وضعیت قبلاً برای این بارنامه ثبت شده است.";
                    return result;
                }
                // تغییر وضعیت جاری بارنامه
                waybill.CurrentStatus = status.Title;
                waybill.CurrentStatusId = status.Id;

                // ساخت رکورد تاریخچه
                var history = new WaybillStatusHistory
                {
                    WaybillId = dto.WaybillId,
                    StatusId = dto.NewStatusId,
                    ChangedAt =dto.ChangedAt
                };

                _context.WaybillStatusHistory.Add(history);

                // ذخیره تغییرات
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "وضعیت با موفقیت تغییر کرد.";
           
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "خطا در تغییر وضعیت: " + ex.Message;
            }

            return result;
        }


        // ---------------------------------------------------------
        // 3) رهگیری بارنامه با شماره بارنامه
        // ---------------------------------------------------------
        public async Task<WaybillHistoryDto> GetWaybillHistoryAsync(string waybillNumber)
        {
            var waybill = await _context.InternationalWaybill
                .FirstOrDefaultAsync(x => x.WaybillNumber == waybillNumber);

            if (waybill == null)
                return null;

            var history = await _context.WaybillStatusHistory
                .Where(x => x.WaybillId == waybill.Id)
                .Include(x => x.Status)
                .OrderBy(x => x.ChangedAt)
                .ToListAsync();

            return new WaybillHistoryDto
            {
                WaybillNumber = waybill.WaybillNumber,
                CurrentStatus = waybill.CurrentStatus,
                OriginCountryName = waybill.OriginCountryName,
                DestinationCountryName = waybill.DestinationCountryName,
                SenderName = waybill.SenderName,
                ReceiverName = waybill.ReceiverName,
                PackageCount = waybill.PackageCount,
                PackageWeight = waybill.PackageWeight,
                CreateAt=waybill.CreateAt,
                
                

                History = history.Select(x => new WaybillHistoryItemDto
                {
                    Title = x.Status.Title,
                    TitleEn = x.Status.TitleEn,
                    Description = x.Status.Description,
                    ChangedAt = x.ChangedAt,
                    Color = x.Status.Title switch
                    {
                        "ارتباط با فرستنده" => "#0284c7",        // آبی روشن
                        "دريافت مرسوله" => "#0ea5e9",             // آبی
                        "ورود مرسوله به هاب مبدا" => "#6366f1",  // بنفش
                        "خروج از هاب به فرودگاه" => "#4f46e5",   // نیلی
                        "خروج از فرودگاه" => "#f59e0b",          // زرد
                        "ورود به فرودگاه مقصد" => "#d97706",     // نارنجی
                        "در حال ارزیابی گمرک" => "#84cc16",      // سبز لیمویی
                        "خروج از گمرک" => "#22c55e",             // سبز
                        "ورود به هاب مقصد" => "#16a34a",         // سبز تیره
                        "در حال تحويل دادن" => "#f97316",        // نارنجی پررنگ
                        "تحويل داده شد" => "#10b981",            // سبز موفقیت
                        _ => "#6b7280"                           // خاکستری (پیش‌فرض)
                    }

                }).ToList()
            };
        }


        public async Task<SelectList> SelectList_WaybillStatuses()
        {
            var statuses = await _context.WaybillStatus
                .Select(s => new
                {
                    id = s.Id,
                    title = s.Title,
                    titleEn = s.TitleEn
                })
                .ToListAsync();

            var items = statuses
                .Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.title 
                })
                .ToList();

            return new SelectList(items, "Value", "Text");
        }
        public async Task<List<GetAllInternationalWaybilDto>> GetAllWaybillsAsync(InternationalWaybillFilterDto? filter = null)
        {
            var query = _context.InternationalWaybill.AsQueryable();
            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.WaybillNumber))
                query = query.Where(x => x.WaybillNumber.Contains(filter.WaybillNumber));

            if (!string.IsNullOrWhiteSpace(filter.OriginCountryName))
                query = query.Where(x => x.OriginCountryName.Contains(filter.OriginCountryName));

            if (!string.IsNullOrWhiteSpace(filter.DestinationCountryName))
                query = query.Where(x => x.DestinationCountryName.Contains(filter.DestinationCountryName));

            if (!string.IsNullOrWhiteSpace(filter.SenderName))
                query = query.Where(x => x.SenderName.Contains(filter.SenderName));

            if (!string.IsNullOrWhiteSpace(filter.ReceiverName))
                query = query.Where(x => x.ReceiverName.Contains(filter.ReceiverName));

            if (filter.CurrentStatusId.HasValue)
                query = query.Where(x => x.CurrentStatusId == filter.CurrentStatusId.Value);
          
            if (filter.ExcludeStatusId.HasValue)
                query = query.Where(x => x.CurrentStatusId != filter.ExcludeStatusId.Value);
               }
            var result = await query
                .OrderByDescending(x => x.CreateAt)
                .Select(x => new GetAllInternationalWaybilDto
                {
                    Id = x.Id,
                    WaybillNumber = x.WaybillNumber,
                    PackageCount = x.PackageCount,
                    PackageWeight = x.PackageWeight,
                    OriginCountryName = x.OriginCountryName,
                    DestinationCountryName = x.DestinationCountryName,
                    SenderName = x.SenderName,
                    ReceiverName = x.ReceiverName,
                    CurrentStatus = x.CurrentStatus,
                    CreateAt = x.CreateAt
                })
                .ToListAsync();

            return result;
        }
       



    }
}


