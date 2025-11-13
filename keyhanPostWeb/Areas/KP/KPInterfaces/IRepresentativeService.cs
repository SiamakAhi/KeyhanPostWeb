
using keyhanPostWeb.GeneralViewModels.RepDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.KP.KPInterfaces
{
    public interface IRepresentativeService
    {
        Task<clsResult> SubmitRequest_Step1Async(RepApplicantCreateDto_Step1 dto);
        Task<clsResult> SubmitRequest_Step2Async(RepApplicantCreateDto_Step2 dto);
        Task<clsResult> SubmitRequestAsync(RepApplicantCreateDto dto);
        Task<RepApplicantDetailDto> GetRequestDetailsAsync(Guid applicantId);
        Task<RepApplicantDetailDto> GetRequestDetailsByUserAsync(string usetName);
        Task<bool> UserHasRequerstAsync(string userName);
        Task<clsResult> UpdateRequestStatusAsync(RepApplicantStatusUpdateDto dto);
        Task<SelectList> SelectList_Cities();
        SelectList SelectList_Countries();
        Task<SelectList> SelectList_Introductions();
        Task<SelectList> SelectList_EducationsAsync();
        Task<SelectList> GetEntityTypesAsync();
        Task<SelectList> GetAgencyTypesAsync();
        Task<SelectList> GetRequestStatusesAsync();
        Task<SelectList> GetJobRequestType();
        Task<SelectList> GetExperiencesAsync();
        Task<SelectList> GetVehicleAvailabilitiesAsync();
        Task<SelectList> GetVehicleTypesAsync();
        Task<SelectList> GetPropertyTypesAsync();
        Task<SelectList> GetDocumentTypesAsync();
    }
}
