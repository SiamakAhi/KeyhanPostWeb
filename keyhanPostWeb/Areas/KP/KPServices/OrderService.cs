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

                ReceiverName = dto.ReceiverName,
                ReceiverPhone = dto.ReceiverPhone,
                ReceiverNationalId = dto.ReceiverNationalId,
                ReceiverAddress = dto.ReceiverAddress,

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
            var query = _context.Orders
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

                // 🔹 دریافت نام شهر مبدا و مقصد از دیکشنری شهرها
                OriginCityname = cities.ContainsKey(o.OriginCityId) ? cities[o.OriginCityId] : "نامشخص",
                DestinationCityname = cities.ContainsKey(o.DestinationCityId) ? cities[o.DestinationCityId] : "نامشخص",

                // 🔹 تبدیل تاریخ میلادی به شمسی
                CreatedAt = ConvertToPersianDate(o.CreatedAt),

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
        private string ConvertToPersianDate(DateTime date)
        {
            var pc = new System.Globalization.PersianCalendar();
            return $"{pc.GetYear(date):0000}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }
    }
}


