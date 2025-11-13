using keyhanPostWeb.Areas.KP.Dto;
using keyhanPostWeb.GeneralViewModels.Order;

namespace keyhanPostWeb.Areas.KP.KPInterfaces
{
    public interface IOrderService
    {
        Task<clsResult> CreateOrderAsync(OrderCreateViewModel Vm);
        Task<clsResult> KpCreateInternationalOrderAsync(OrderCreateViewModel dto);

        Task<List<getOrdersViewModel>> GetAllInternationalOrders(OrderFilterDto? filter = null);
        public Task<List<getOrdersViewModel>> GetAllOrdersAsync(OrderFilterDto? filter = null);
    }
}
