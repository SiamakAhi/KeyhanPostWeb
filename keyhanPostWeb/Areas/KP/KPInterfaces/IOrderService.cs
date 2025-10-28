using keyhanPostWeb.Areas.KP.Dto;
using keyhanPostWeb.GeneralViewModels.Order;

namespace keyhanPostWeb.Areas.KP.KPInterfaces
{
    public interface IOrderService
    {
        Task<clsResult> CreateOrderAsync(OrderCreateViewModel Vm);

        public Task<List<OrderCreateViewModel>> GetAllOrdersAsync(OrderFilterDto? filter = null);
    }
}
