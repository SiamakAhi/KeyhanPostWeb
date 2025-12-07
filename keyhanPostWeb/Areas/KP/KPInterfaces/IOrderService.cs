using keyhanPostWeb.Areas.KP.Dto;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.GeneralViewModels.Order;
using Microsoft.AspNetCore.Mvc.Rendering;
using static keyhanPostWeb.GeneralViewModels.Order.CreateInOrderVm;
using static keyhanPostWeb.GeneralViewModels.Order.CreateOrderVm;

namespace keyhanPostWeb.Areas.KP.KPInterfaces
{
    public interface IOrderService
    {
        //-------------------------------------------order-----------------------------------------//


        //-------------------مراحل ثبت سفارش داخلی----------------------//
        Task<clsResult> CreateStep0Async(CreateOrderStep0Vm dto);

        Task<clsResult> CreateStep1Async(CreateOrderStep1Vm dto);

        Task<clsResult> CreateStep2Async(CreateOrderStep2Vm dto);

        Task<clsResult> CreateStep3Async(CreateOrderStep3Vm dto);

        Task<clsResult> CreateStep4Async(CreateOrderStep4Vm dto);

        //--------------------گرفتن اطلاعات سفارش داخلی---------------------//
        Task<short?> GetCrrentStepOrderByOrderIdAsync(int orderId);
        Task<GetOrderDetailVm?> GetOrderDetailByOrderIdAsync(int orderId);
        Task<List<GetOrdersVM>> GetAllOrdersAsync(OrderFilterDto? filter = null);


        //-------------------مراحل ثبت سفارش بین المللی----------------------//
        Task<clsResult> In_CreateStep0Async(CreateInOrderStep0Vm dto);

        Task<clsResult> In_CreateStep1Async(CreateInOrderStep1Vm dto);

        Task<clsResult> In_CreateStep2Async(CreateInOrderStep2Vm dto);

        Task<clsResult> In_CreateStep3Async(CreateInOrderStep3Vm dto);


        //--------------------گرفتن اطلاعات سفارش بین المللی---------------------//
        Task<short?> In_GetCrrentStepOrderByOrderIdAsync(int orderId);

        Task<List<GetInOrdersVm>> GetAllInOrdersAsync(InOrderFilterDto? filter = null);
        Task<GetInOrderDetailVm?> GetInOrderDetailByOrderIdAsync(int orderId);




        //--------------------بارنامه های بین المللی---------------------//
        Task<clsResult> CreateWaybillAsync(CreateWaybillDto dto);
        Task<clsResult> ChangeStatusAsync(ChangeWaybillStatusDto dto);
        Task<WaybillHistoryDto> GetWaybillHistoryAsync(string wayBillNumber);
        Task<SelectList> SelectList_WaybillStatuses();
        Task<List<GetAllInternationalWaybilDto>> GetAllWaybillsAsync(InternationalWaybillFilterDto? filter = null);
    }
}
