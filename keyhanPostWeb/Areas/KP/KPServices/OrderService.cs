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
        public async Task<List<OrderCreateViewModel>> GetAllOrdersAsync(OrderFilterDto? filter = null)
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

            return await query
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new OrderCreateViewModel
                {
                    
                    SenderName = o.SenderName,
                    ReceiverName = o.ReceiverName,
                    SenderPhone=o.SenderPhone,
                    ReceiverPhone=o.ReceiverPhone,
                    ActualWeight = o.ActualWeight
                })
                .ToListAsync();
        }
    }
}


