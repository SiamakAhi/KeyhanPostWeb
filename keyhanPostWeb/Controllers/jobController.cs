
using keyhanPostWeb;
using keyhanPostWeb.Areas.CMS.CmsInterfaces;
using keyhanPostWeb.Areas.CMS.Dtos;
using keyhanPostWeb.Areas.KP.KPInterfaces;
using keyhanPostWeb.Areas.KP.KPservices;
using keyhanPostWeb.GeneralService;
using keyhanPostWeb.GeneralViewModels.RepDto;
using keyhanPostWeb.Models.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Controllers
{
    //[Authorize]
    public class JobController : Controller
    {
        private readonly IRepresentativeService _jobService;
        private readonly IContentManager _IcontentManager;
        private readonly SignInManager<ApplicationUser> _signIn;
        private readonly IApplicationUserManager _userManager;

        public JobController(IRepresentativeService representativeService
           , IContentManager contentManager,
            SignInManager<ApplicationUser> signIn
            , IApplicationUserManager userManager)
        {
            _jobService = representativeService;
            _IcontentManager = contentManager;
            _signIn = signIn;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateJobRequest_step1()
        {
            // دریافت اطلاعات پایه برای نمایش در فرم
            ViewBag.EntityTypes = await _jobService.GetEntityTypesAsync();
            ViewBag.Intro = await _jobService.SelectList_Introductions();
            ViewBag.Education = await _jobService.SelectList_EducationsAsync();
            ViewBag.user = User.Identity.Name;
            return PartialView("_CreateJobRequest_step1");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJobRequest_step1(RepApplicantCreateDto_Step1 dto)
        {
            clsResult result = new clsResult();


            if (ModelState.IsValid)
            {
                result = await _jobService.SubmitRequest_Step1Async(dto);

                if (result.Success)
                {
                    result.ShowMessage = false;
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
        public async Task<IActionResult> CreateJobRequest_step2()
        {
            var model = new VmRepresentativeRequest();
            model.Details = await _jobService.GetRequestDetailsByUserAsync(User.Identity.Name);
            return PartialView("_CreateJobRequest_step2", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJobRequest_step2(VmRepresentativeRequest dto)
        {
            clsResult result = new clsResult();

            if (ModelState.IsValid)
            {
                result = await _jobService.SubmitRequest_Step2Async(dto.dtoStep2);

                if (result.Success)
                {
                    try
                    {
                        var requestData = await _jobService.GetRequestDetailsByUserAsync(User.Identity.Name);
                        List<string> cc = new List<string>();
                        cc.Add("keyhanpost50@gmail.com");
                        await EmailService.SendRepApplicantDetails(requestData, "vazinkia@gmail.com", cc);
                    }
                    catch (System.Exception x)
                    {
                        string msg = x.Message;
                        throw;
                    }
                    result.ShowMessage = false;
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
        public async Task<IActionResult> CreateJobRequest_step3()
        {
            var model = new VmRepresentativeRequest();
            model.Details = await _jobService.GetRequestDetailsByUserAsync(User.Identity.Name);
            return PartialView("_CreateJobRequest_step3", model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateJobRequest()
        {

            VmSiteContent model = new VmSiteContent();
            model.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            model.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            var cinfo = await _IcontentManager.GetCompanyInfo();
            model.AllSection = await _IcontentManager.GetAllSection();
            model.ServicePages = await _IcontentManager.GetServicePages();

            ViewBag.emailAddress = await _IcontentManager.GetEmailAddresses();
            //
            model.jobRequest = new VmRepresentativeRequest();
            model.jobRequest.Details = await _jobService.GetRequestDetailsByUserAsync(User.Identity.Name);
            if (model.jobRequest.Details != null)
                model.jobRequest.CurrentStep = model.jobRequest.Details.CurrentStep;
            else
                model.jobRequest.CurrentStep = 0;

            model.jobRequest.dtoStep1 = new RepApplicantCreateDto_Step1();
            model.jobRequest.dtoStep2 = new RepApplicantCreateDto_Step2();
            //
            // دریافت اطلاعات پایه برای نمایش در فرم
            ViewBag.EntityTypes = await _jobService.GetEntityTypesAsync();
            ViewBag.Education = await _jobService.SelectList_EducationsAsync();
            ViewBag.Intro = await _jobService.SelectList_Introductions();
            // Step2
            ViewBag.JobRequestType = await _jobService.GetJobRequestType(); //Ok
            ViewBag.Cities = await _jobService.SelectList_Cities();
            ViewBag.AgencyTypes = await _jobService.GetAgencyTypesAsync();
            ViewBag.Experiences = await _jobService.GetExperiencesAsync();
            ViewBag.VehicleAvailabilities = await _jobService.GetVehicleAvailabilitiesAsync();
            ViewBag.VehicleType = await _jobService.GetVehicleTypesAsync();
            ViewBag.PropertyTypes = await _jobService.GetPropertyTypesAsync();
            ViewBag.DocumentTypes = await _jobService.GetDocumentTypesAsync();


            return View(model);
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitJobRequest(RepApplicantCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                // اگر داده‌های ورودی معتبر نیستند، اطلاعات پایه دوباره بارگیری شوند
                ViewBag.EntityTypes = await _jobService.GetEntityTypesAsync();
                ViewBag.AgencyTypes = await _jobService.GetAgencyTypesAsync();
                ViewBag.Experiences = await _jobService.GetExperiencesAsync();
                ViewBag.VehicleAvailabilities = await _jobService.GetVehicleAvailabilitiesAsync();
                ViewBag.PropertyTypes = await _jobService.GetPropertyTypesAsync();
                ViewBag.DocumentTypes = await _jobService.GetDocumentTypesAsync();
                return View("CreateJobRequest", dto);
            }

            var result = await _jobService.SubmitRequestAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View("CreateJobRequest", dto);
            }

            // در صورت موفقیت، به صفحه داشبورد یا صفحه‌ای دیگر هدایت کنید
            TempData["SuccessMessage"] = result.Message;
            return Redirect(result.returnUrl ?? "/Applicant/Dashboard");
        }

        //[HttpGet]
        //public async Task<IActionResult> GetJobRequestDetails()
        //{
        //    string userName = User.Identity.Name;
        //    if (string.IsNullOrEmpty(userName))
        //        return NoContent();

        //    var detailDto = await _jobService.GetRequestDetailsByUserAsync(userName);
        //    if (detailDto == null) return NoContent();
        //    if (detailDto.CurrentStep == 1)


        //        return View(detailDto);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateJobRequestStatus(RepApplicantStatusUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("داده‌های ورودی نامعتبر هستند.");
            }

            var result = await _jobService.UpdateRequestStatusAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View("Error");
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("GetJobRequestDetails", new { applicantId = dto.ApplicantId });
        }
    }
}
