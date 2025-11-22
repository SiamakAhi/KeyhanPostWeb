using keyhanPostWeb.Areas.KP.Dto;
using keyhanPostWeb.Areas.KP.KPInterfaces;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.GeneralViewModels.Order;
using keyhanPostWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace keyhanPostWeb.Areas.KP.KPServices
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }
       

        public async Task<clsResult> CreateOrderAsync(OrderCreateViewModel dto)
        {
            clsResult result = new clsResult();
            Order order = new Order
            {
             
                OriginCityId = dto.OriginCityId,
                DestinationCityId = dto.DestinationCityId,
                Length = dto.Length,
                Width = dto.Width,
                Height = dto.Height,
                ActualWeight = dto.ActualWeight,
                PackageTypeId=dto.PackageTypeId,

                SenderName = dto.SenderName,
                SenderPhone = dto.SenderPhone,
                SenderNationalId = dto.SenderNationalId,
                SenderAddress = dto.SenderAddress,
                OriginCountryName = "ایران",
                DestinationCountryName = "ایران",
                ReceiverName = dto.ReceiverName,
                ReceiverPhone = dto.ReceiverPhone,
                ReceiverNationalId = dto.ReceiverNationalId,
                ReceiverAddress = dto.ReceiverAddress,
                OrderType=1,
                TrackingCode = GenerateTrackingCode(),
                OrderStatusId = 1, // در انتظار بررسی
                CreatedAt = DateTime.Now
            };

            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "با موفقیت ثبت شد";
                result.Data = order.TrackingCode;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "خطایی در ثبت رخ داده است: " + ex.Message;
            }

            return result;
        }
        public async Task<clsResult> KpCreateInternationalOrderAsync(OrderCreateViewModel dto)
        {
            clsResult result = new clsResult();
            Order order = new Order
            {

               
                Length = dto.Length,
                Width = dto.Width,
                Height = dto.Height,
                ActualWeight = dto.ActualWeight,
                PackageTypeId = dto.PackageTypeId,

                SenderName = dto.SenderName,
                SenderPhone = dto.SenderPhone,
               OriginCountryName=dto.OriginCountryName,
               DestinationCountryName=dto.DestinationCountryName,

                ReceiverName = dto.ReceiverName,
                ReceiverPhone = dto.ReceiverPhone,
                
                OrderType=2,
                TrackingCode = GenerateTrackingCode(),
                OrderStatusId = 1, // در انتظار بررسی
                CreatedAt = DateTime.Now
            };

            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "با موفقیت ثبت شد";
                result.Data = order.TrackingCode;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "خطایی در ثبت رخ داده است: " + ex.Message;
            }

            return result;
        }
        private string GenerateTrackingCode()
        {
            return  DateTime.Now.Year + "-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }
        public async Task<List<getOrdersViewModel>> GetAllOrdersAsync(OrderFilterDto? filter = null)
        {
            var query = _context.Orders.Where(x=>x.OrderType==1)
                .Include(o => o.OrderStatus)
                .AsQueryable();

            if (filter != null)
            {
                if (filter.StatusId.HasValue)
                    query = query.Where(o => o.OrderStatusId == filter.StatusId);

                if (filter.OriginCityId.HasValue)
                    query = query.Where(o => o.OriginCityId == filter.OriginCityId);

                if (filter.DestinationCityId.HasValue)
                    query = query.Where(o => o.DestinationCityId == filter.DestinationCityId);

                if (!string.IsNullOrEmpty(filter.SenderName))
                    query = query.Where(o => o.SenderName.Contains(filter.SenderName));

                if (!string.IsNullOrEmpty(filter.ReceiverName))
                    query = query.Where(o => o.ReceiverName.Contains(filter.ReceiverName));

                if (filter.FromDate.HasValue)
                    query = query.Where(o => o.CreatedAt >= filter.FromDate.Value);

                if (filter.ToDate.HasValue)
                    query = query.Where(o => o.CreatedAt <= filter.ToDate.Value);
            }

            var cities = await _context.Cities.ToDictionaryAsync(c => c.Id, c => c.CityName);

            var orders = await query
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new
                {
                    o.Id,
                    o.SenderName,
                    o.ReceiverName,
                    o.SenderPhone,
                    o.ReceiverPhone,
                    o.ActualWeight,
                    o.OriginCityId,
                    o.DestinationCityId,
                    o.PackageTypeId,
                    o.CreatedAt,
                    o.TrackingCode,
                })
                .ToListAsync();

            var result = orders.Select(o => new getOrdersViewModel
            {
                SenderName = o.SenderName,
                ReceiverName = o.ReceiverName,
                SenderPhone = o.SenderPhone,
                ReceiverPhone = o.ReceiverPhone,
                ActualWeight = o.ActualWeight,
                TrackingCode=o.TrackingCode,

                OriginCityname = o.OriginCityId.HasValue && cities.ContainsKey(o.OriginCityId.Value)
                ? cities[o.OriginCityId.Value]
                : "نامشخص",
                DestinationCityname = o.DestinationCityId.HasValue && cities.ContainsKey(o.DestinationCityId.Value)
                ? cities[o.DestinationCityId.Value]
                : "نامشخص",

                // 🔹 تبدیل تاریخ میلادی به شمسی
                CreatedAt = keyhanPostWeb.GeneralService.Extension.LatinToPersian(o.CreatedAt),

                // 🔹 نمایش نوع پکیج با متن فارسی
                PackageTypeName = o.PackageTypeId switch
                {
                    1 => "کالای عادی",
                    2 => "کالای الکترونیکی",
                    3 => "پاکت",
                    4 => "کالای فاسدشدنی",
                    _ => "نامشخص"
                }
            }).ToList();

            return result;
        }
        public async Task<List<getOrdersViewModel>> GetAllInternationalOrders(OrderFilterDto? filter = null)
        {
            var query = _context.Orders.Where(x => x.OrderType == 2)
                .Include(o => o.OrderStatus)
                .AsQueryable();

            if (filter != null)
            {
                if (filter.StatusId.HasValue)
                    query = query.Where(o => o.OrderStatusId == filter.StatusId);

                if (filter.OriginCityId.HasValue)
                    query = query.Where(o => o.OriginCityId == filter.OriginCityId);

                if (filter.DestinationCityId.HasValue)
                    query = query.Where(o => o.DestinationCityId == filter.DestinationCityId);

                if (!string.IsNullOrEmpty(filter.SenderName))
                    query = query.Where(o => o.SenderName.Contains(filter.SenderName));

                if (!string.IsNullOrEmpty(filter.ReceiverName))
                    query = query.Where(o => o.ReceiverName.Contains(filter.ReceiverName));

                if (filter.FromDate.HasValue)
                    query = query.Where(o => o.CreatedAt >= filter.FromDate.Value);

                if (filter.ToDate.HasValue)
                    query = query.Where(o => o.CreatedAt <= filter.ToDate.Value);
            }

            var cities = await _context.Cities.ToDictionaryAsync(c => c.Id, c => c.CityName);

            var orders = await query
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new
                {
                    o.Id,
                    o.SenderName,
                    o.ReceiverName,
                    o.SenderPhone,
                    o.ReceiverPhone,
                    o.ActualWeight,
                    o.OriginCountryName,
                    o.DestinationCountryName,
                    o.PackageTypeId,
                    o.CreatedAt,
                    o.TrackingCode,
                    
                })
                .ToListAsync();

            var result = orders.Select(o => new getOrdersViewModel
            {
                SenderName = o.SenderName,
                ReceiverName = o.ReceiverName,
                SenderPhone = o.SenderPhone,
                ReceiverPhone = o.ReceiverPhone,
                ActualWeight = o.ActualWeight,
                TrackingCode = o.TrackingCode,
                OriginCountryName= o.OriginCountryName,
                DestinationCountryName= o.DestinationCountryName,


                // 🔹 تبدیل تاریخ میلادی به شمسی
                CreatedAt = o.CreatedAt == null
                ? "ثبت نشده"
                : (keyhanPostWeb.GeneralService.Extension.LatinToPersian(o.CreatedAt)).ToString(),

                // 🔹 نمایش نوع پکیج با متن فارسی
                PackageTypeName = o.PackageTypeId switch
                {
                    1 => "کالای عادی",
                    2 => "کالای الکترونیکی",
                    3 => "پاکت",
                    4 => "کالای فاسدشدنی",
                    5 => "کالبد متوفی",
                    6 => "حیوان زنده",
                    _ => "نامشخص"
                }
            }).ToList();

            return result;
        }
       
    }
}


