
using keyhanPostWeb.Areas.KP.KPInterfaces;
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using keyhanPostWeb.GeneralViewModels.RepDto;
using keyhanPostWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.KP.KPservices
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly AppDbContext _db;

        public RepresentativeService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// ثبت درخواست جدید
        /// </summary>
        /// 
        public async Task<clsResult> SubmitRequest_Step1Async(RepApplicantCreateDto_Step1 dto)
        {
            try
            {
                // بررسی تکرار شماره ملی
                var existingApplicant = await _db.RepApplicants
                    .FirstOrDefaultAsync(a => a.NationalId == dto.NationalId);

                if (existingApplicant != null)
                {
                    return new clsResult
                    {
                        Success = false,
                        Message = "درخواست با این شناسه ملی قبلاً ثبت شده است.",
                        ShowMessage = true
                    };
                }

                var applicant = new RepApplicant();

                // مقداردهی مستقل هر ویژگی
                applicant.Id = dto.Id;
                applicant.ApplicantName = dto.ApplicantName;
                applicant.Username = dto.Username;
                applicant.MobileNumber = dto.MobileNumber;
                applicant.Email = dto.Email;
                applicant.NationalId = dto.NationalId;
                applicant.Address = dto.Address;
                applicant.EntityTypeId = dto.EntityTypeId;
                applicant.IntroductionId = dto.IntroDuctionId;
                applicant.EducationId = dto.EducationDegreeId;
                // تولید کد پیگیری ساده و قابل یادآوری
                applicant.TrackingCode = GenerateTrackingCode();

                applicant.RequestDate = DateTime.Now;
                applicant.RequestStatusId = 20; // وضعیت در حال تکمیل درخواست"
                applicant.Approved = false; // درخواست در ابتدا تایید نشده
                applicant.currentStep = 1;
                _db.RepApplicants.Add(applicant);
                await _db.SaveChangesAsync();

                return new clsResult
                {
                    Success = true,
                    Message = "درخواست با موفقیت ثبت شد.",
                    returnUrl = "/Applicant/Dashboard",
                    updateType = 1,
                    ShowMessage = false
                };
            }
            catch (Exception ex)
            {
                return new clsResult
                {
                    Success = false,
                    Message = "خطا در ثبت درخواست: " + ex.Message,
                    ShowMessage = true
                };
            }
        }

        public async Task<clsResult> SubmitRequest_Step2Async(RepApplicantCreateDto_Step2 dto)
        {
            try
            {
                var applicant = await _db.RepApplicants.FindAsync(dto.Id);

                if (applicant == null)
                {
                    return new clsResult
                    {
                        Success = false,
                        Message = "اطلاعات یافت نشد",
                        ShowMessage = true
                    };
                }
                applicant.JobRequestId = dto.JobRequestId;
                applicant.AgencyTypeId = dto.AgencyTypeId;
                applicant.ExperienceId = dto.ExperienceId;
                applicant.VehicleAvailabilityId = dto.VehicleAvailabilityId;
                applicant.VehicleTypeId = dto.VehicleTypeId;
                applicant.PropertyTypeId = dto.PropertyTypeId;
                applicant.CityId = dto.CityId;
                applicant.BranchAddress = dto.BranchAddress;
                applicant.JobSeekerRemarks = dto.AdditionalDesc;

                applicant.RequestStatusId = 10;
                applicant.currentStep = 2;
                _db.RepApplicants.Update(applicant);
                await _db.SaveChangesAsync();

                return new clsResult
                {
                    Success = true,
                    Message = "درخواست با موفقیت ثبت شد.",
                    returnUrl = "/Applicant/Dashboard",
                    updateType = 1,
                    ShowMessage = false
                };
            }
            catch (Exception ex)
            {
                return new clsResult
                {
                    Success = false,
                    Message = "خطا در ثبت درخواست: " + ex.Message,
                    ShowMessage = true
                };
            }
        }
        public async Task<clsResult> SubmitRequestAsync(RepApplicantCreateDto dto)
        {
            try
            {
                // بررسی تکرار شماره ملی
                var existingApplicant = await _db.RepApplicants
                    .FirstOrDefaultAsync(a => a.NationalId == dto.NationalId);

                if (existingApplicant != null)
                {
                    return new clsResult
                    {
                        Success = false,
                        Message = "درخواست با این شناسه ملی قبلاً ثبت شده است.",
                        ShowMessage = true
                    };
                }

                var applicant = new RepApplicant();

                // مقداردهی مستقل هر ویژگی
                applicant.Id = dto.Id;
                applicant.ApplicantName = dto.ApplicantName;
                applicant.Username = dto.Username;
                applicant.MobileNumber = dto.MobileNumber;
                applicant.Email = dto.Email;
                applicant.NationalId = dto.NationalId;
                applicant.Address = dto.Address;
                applicant.EntityTypeId = dto.EntityTypeId;
                applicant.AgencyTypeId = dto.AgencyTypeId;
                applicant.ExperienceId = dto.ExperienceId;
                applicant.VehicleAvailabilityId = dto.VehicleAvailabilityId;
                applicant.PropertyTypeId = dto.PropertyTypeId;

                // تولید کد پیگیری ساده و قابل یادآوری
                applicant.TrackingCode = GenerateTrackingCode();

                applicant.RequestDate = DateTime.Now;
                applicant.RequestStatusId = 1001; // وضعیت اولیه "نقص مدارک"
                applicant.Approved = false; // درخواست در ابتدا تایید نشده

                _db.RepApplicants.Add(applicant);
                await _db.SaveChangesAsync();

                return new clsResult
                {
                    Success = true,
                    Message = "درخواست با موفقیت ثبت شد.",
                    returnUrl = "/Applicant/Dashboard",
                    updateType = 1,
                    ShowMessage = true
                };
            }
            catch (Exception ex)
            {
                return new clsResult
                {
                    Success = false,
                    Message = "خطا در ثبت درخواست: " + ex.Message,
                    ShowMessage = true
                };
            }
        }

        /// <summary>
        /// مشاهده جزئیات درخواست
        /// </summary>
        public async Task<RepApplicantDetailDto> GetRequestDetailsAsync(Guid applicantId)
        {
            var applicant = await _db.RepApplicants
                .Include(a => a.EntityType)
                .Include(a => a.AgencyType)
                .Include(a => a.RequestStatus)
                .Include(a => a.Experience)
                .Include(a => a.VehicleAvailability)
                .Include(a => a.PropertyType)
                .Include(a => a.EducationDegree)
                .Include(a => a.City).ThenInclude(n => n.Province)
                .Include(a => a.Introduction)
                .Include(a => a.VehicleType)
                .FirstOrDefaultAsync(a => a.Id == applicantId);

            if (applicant == null)
            {
                return null; // در صورت عدم وجود درخواست، مقدار null بازگردانده می‌شود
            }

            var detailDto = new RepApplicantDetailDto
            {
                Id = applicant.Id,
                ApplicantName = applicant.ApplicantName,
                Username = applicant.Username,
                MobileNumber = applicant.MobileNumber,
                Email = applicant.Email,
                NationalId = applicant.NationalId,
                Address = applicant.Address,
                TrackingCode = applicant.TrackingCode,
                RequestDate = applicant.RequestDate.Value,
                EntityType = applicant.EntityType?.EntityTitle,
                AgencyType = applicant.AgencyType?.AgencyTitle,
                RequestStatus = applicant.RequestStatus?.StatusTitle,
                Experience = applicant.Experience?.ExperienceTitle,
                VehicleAvailability = applicant.VehicleAvailability?.AvailabilityTitle,
                PropertyType = applicant.PropertyType?.PropertyTitle,
                TrackingNumber = applicant.TrackingCode,
                BranchAddress = applicant.BranchAddress,
                CurrentStep = applicant.currentStep,
                EducationDegree = applicant.EducationDegree?.DegreeTitle,
                Introduction = applicant.Introduction?.Title,
                CityName = applicant.City?.Province?.ProvinceName + " - " + applicant.City?.CityName,
                VehicleType = applicant.VehicleType?.VehicleTitle,
                OtherDesc = applicant.JobSeekerRemarks,
                Experience_Score = applicant.Experience?.Score,
                AgencyType_Score = applicant.AgencyType?.Score,
                EducationDegree_Score = applicant.EducationDegree?.Score,
                PropertyType_Score = applicant.PropertyType?.Score,
                VehicleAvailability_Score = applicant.VehicleAvailability?.Score,

                TotalScore = applicant.TotalScore,
                UploadedDocuments = _db.RepUploadedDocuments
                    .Where(d => d.ApplicantId == applicant.Id)
                    .Select(d => d.FilePath).ToList()
            };

            return detailDto; // بازگرداندن dto در صورت موفقیت
        }
        public async Task<RepApplicantDetailDto> GetRequestDetailsByUserAsync(string usetName)
        {
            var applicant = await _db.RepApplicants
                .Include(a => a.EntityType)
                .Include(a => a.AgencyType)
                .Include(a => a.RequestStatus)
                .Include(a => a.Experience)
                .Include(a => a.VehicleAvailability)
                .Include(a => a.PropertyType)
                .Include(a => a.EducationDegree)
                .Include(a => a.City).ThenInclude(n => n.Province)
                .Include(a => a.Introduction)
                .Include(a => a.VehicleType)
                .FirstOrDefaultAsync(a => a.Username == usetName);

            if (applicant == null)
            {
                return null; // در صورت عدم وجود درخواست، مقدار null بازگردانده می‌شود
            }

            var detailDto = new RepApplicantDetailDto
            {
                Id = applicant.Id,
                ApplicantName = applicant.ApplicantName,
                Username = applicant.Username,
                MobileNumber = applicant.MobileNumber,
                Email = applicant.Email,
                NationalId = applicant.NationalId,
                Address = applicant.Address,
                TrackingCode = applicant.TrackingCode,
                RequestDate = applicant.RequestDate.Value,
                EntityType = applicant.EntityType?.EntityTitle,
                AgencyType = applicant.AgencyType?.AgencyTitle,
                RequestStatus = applicant.RequestStatus?.StatusTitle,
                Experience = applicant.Experience?.ExperienceTitle,
                VehicleAvailability = applicant.VehicleAvailability?.AvailabilityTitle,
                PropertyType = applicant.PropertyType?.PropertyTitle,
                TrackingNumber = applicant.TrackingCode,
                BranchAddress = applicant.BranchAddress,
                CurrentStep = applicant.currentStep,
                EducationDegree = applicant.EducationDegree?.DegreeTitle,
                Introduction = applicant.Introduction?.Title,
                CityName = applicant.City?.Province?.ProvinceName + " - " + applicant.City?.CityName,
                VehicleType = applicant.VehicleType?.VehicleTitle,
                OtherDesc = applicant.JobSeekerRemarks,
                Experience_Score = applicant.Experience?.Score,
                AgencyType_Score = applicant.AgencyType?.Score,
                EducationDegree_Score = applicant.EducationDegree?.Score,
                PropertyType_Score = applicant.PropertyType?.Score,
                VehicleAvailability_Score = applicant.VehicleAvailability?.Score,

                TotalScore = applicant.TotalScore,
                UploadedDocuments = _db.RepUploadedDocuments
                    .Where(d => d.ApplicantId == applicant.Id)
                    .Select(d => d.FilePath).ToList()
            };

            return detailDto; // بازگرداندن dto در صورت موفقیت
        }

        public async Task<bool> UserHasRequerstAsync(string userName)
        {
            bool HasRequerst = await _db.RepApplicants.AnyAsync(n => n.Username == userName);
            return HasRequerst;
        }
        /// <summary>
        /// تغییر وضعیت درخواست
        /// </summary>
        public async Task<clsResult> UpdateRequestStatusAsync(RepApplicantStatusUpdateDto dto)
        {
            var applicant = await _db.RepApplicants.FirstOrDefaultAsync(a => a.Id == dto.ApplicantId);
            if (applicant == null)
            {
                return new clsResult
                {
                    Success = false,
                    Message = "درخواست یافت نشد.",
                    ShowMessage = true
                };
            }

            applicant.RequestStatusId = dto.NewStatusId;
            applicant.EvaluationNote = dto.EvaluationNote;
            await _db.SaveChangesAsync();

            return new clsResult
            {
                Success = true,
                Message = "وضعیت درخواست با موفقیت به‌روزرسانی شد.",
                updateType = 2, // فرض کنید به‌روزرسانی با AJAX نیاز است
                updateTargetId = "#RequestStatusElement",
                ShowMessage = true
            };
        }

        /// <summary>
        /// متد برای دریافت اطلاعات پایه به صورت SelectList
        /// </summary>
        /// 
        public async Task<SelectList> SelectList_Cities()
        {
            var cities = await _db.Cities
                .Include(n => n.Province)
                .Select(n => new { id = n.Id, cityName = n.CityName, provinceName = n.Province.ProvinceName })
                .ToListAsync();

            var groupedCities = cities.GroupBy(n => n.provinceName)
                .Select(group => new SelectListGroup() { Name = group.Key })
                .ToList();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var group in groupedCities)
            {
                var groupItems = cities.Where(c => c.provinceName == group.Name)
                    .Select(c => new SelectListItem()
                    {
                        Text = c.cityName,
                        Value = c.id.ToString(),
                        Group = group
                    })
                    .ToList();
                items.AddRange(groupItems);
            }
            return new SelectList(items, "Value", "Text", "Group.Name", "Group.Name");
        }
       public SelectList SelectList_Countries()
{
            var items = new List<SelectListItem>
{
    new SelectListItem { Value = "تهران - فرودگاه امام خمینی", Text = "تهران - فرودگاه امام خمینی" },
    new SelectListItem { Value = "چین", Text = "چین" },
    new SelectListItem { Value = "امارات", Text = "امارات" },
    new SelectListItem { Value = "ترکیه", Text = "ترکیه" },
    new SelectListItem { Value = "آلمان", Text = "آلمان" },
    new SelectListItem { Value = "فرانسه", Text = "فرانسه" },
    new SelectListItem { Value = "ایتالیا", Text = "ایتالیا" },
    new SelectListItem { Value = "انگلیس", Text = "انگلیس" },
    new SelectListItem { Value = "هلند", Text = "هلند" },
    new SelectListItem { Value = "بلژیک", Text = "بلژیک" },
    new SelectListItem { Value = "اتریش", Text = "اتریش" },
    new SelectListItem { Value = "سوئیس", Text = "سوئیس" },
    new SelectListItem { Value = "کانادا", Text = "کانادا" },
    new SelectListItem { Value = "آمریکا", Text = "آمریکا" },
    new SelectListItem { Value = "روسیه", Text = "روسیه" },
    new SelectListItem { Value = "هند", Text = "هند" },
    new SelectListItem { Value = "ژاپن", Text = "ژاپن" },
    new SelectListItem { Value = "کره جنوبی", Text = "کره جنوبی" },
    new SelectListItem { Value = "عراق", Text = "عراق" },
    new SelectListItem { Value = "قطر", Text = "قطر" },
    new SelectListItem { Value = "عربستان", Text = "عربستان" },
    new SelectListItem { Value = "کویت", Text = "کویت" },
    new SelectListItem { Value = "بحرین", Text = "بحرین" },
    new SelectListItem { Value = "عمان", Text = "عمان" },
    new SelectListItem { Value = "سوئد", Text = "سوئد" },
    new SelectListItem { Value = "نروژ", Text = "نروژ" },
    new SelectListItem { Value = "دانمارک", Text = "دانمارک" },
    new SelectListItem { Value = "اسپانیا", Text = "اسپانیا" },
    new SelectListItem { Value = "استرالیا", Text = "استرالیا" }
};


            return new SelectList(items, "Value", "Text");
}


    
        public async Task<SelectList> SelectList_Introductions()
        {
            var cities = await _db.RepIntroductionMethods.Select(n => new { id = n.Id, name = n.Title }).ToListAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in cities)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = item.name,
                    Value = item.id.ToString()
                };
                items.Add(selectListItem);
            }
            return new SelectList(items, "Value", "Text");
        }
        public async Task<SelectList> SelectList_EducationsAsync()
        {
            var cities = await _db.EducationDegrees.Select(n => new { id = n.Id, name = n.DegreeTitle }).ToListAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in cities)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = item.name,
                    Value = item.id.ToString()
                };
                items.Add(selectListItem);
            }
            return new SelectList(items, "Value", "Text");
        }
        public async Task<SelectList> GetEntityTypesAsync()
        {
            var entities = await _db.RepEntityTypes.Select(e => new { e.Id, e.EntityTitle }).ToListAsync();
            return new SelectList(entities, "Id", "EntityTitle");
        }
        public async Task<SelectList> GetAgencyTypesAsync()
        {
            var agencies = await _db.RepAgencyTypes.Select(a => new { a.Id, a.AgencyTitle }).ToListAsync();
            return new SelectList(agencies, "Id", "AgencyTitle");
        }
        public async Task<SelectList> GetRequestStatusesAsync()
        {
            var statuses = await _db.RepRequestStatuses.Select(s => new { s.Id, s.StatusTitle }).ToListAsync();
            return new SelectList(statuses, "Id", "StatusTitle");
        }
        public async Task<SelectList> GetJobRequestType()
        {
            var statuses = await _db.RepJobRequests.Select(s => new { s.Id, s.JobTitle }).ToListAsync();
            return new SelectList(statuses, "Id", "JobTitle");
        }
        public async Task<SelectList> GetExperiencesAsync()
        {
            var experiences = await _db.RepExperiences.Select(e => new { e.Id, e.ExperienceTitle }).ToListAsync();
            return new SelectList(experiences, "Id", "ExperienceTitle");
        }
        public async Task<SelectList> GetVehicleAvailabilitiesAsync()
        {
            var vehicles = await _db.RepVehicleAvailabilities.Select(v => new { v.Id, v.AvailabilityTitle }).ToListAsync();
            return new SelectList(vehicles, "Id", "AvailabilityTitle");
        }
        public async Task<SelectList> GetVehicleTypesAsync()
        {
            var vehicles = await _db.RepVehicleTypes.Select(v => new { v.Id, v.VehicleTitle }).ToListAsync();
            return new SelectList(vehicles, "Id", "VehicleTitle");
        }
        public async Task<SelectList> GetPropertyTypesAsync()
        {
            var properties = await _db.RepPropertyTypes.Select(p => new { p.Id, p.PropertyTitle }).ToListAsync();
            return new SelectList(properties, "Id", "PropertyTitle");
        }
        public async Task<SelectList> GetDocumentTypesAsync()
        {
            var documents = await _db.RepDocumentTypes.Select(d => new { d.Id, d.DocumentTitle }).ToListAsync();
            return new SelectList(documents, "Id", "DocumentTitle");
        }

        /// <summary>
        /// تولید کد پیگیری ساده و قابل یادآوری
        /// </summary>
        private string GenerateTrackingCode()
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
