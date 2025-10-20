using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmCompanyInfo
    {

        public Int16 id { get; set; }

        [Display(Name = "نام کوتاه")]
        public string ShortName { get; set; } = "";

        [Display(Name = "نام کامل")]
        public string FullName { get; set; } = "";

        [Display(Name = "شماره ثبت")]
        public string SabtNo { get; set; } = "";

        [Display(Name = "شناسه ملی")]
        public string MeliNo { get; set; } = "";

        public string? Facebook { get; set; }    // لینک یا نام کاربری فیسبوک
        public string? Instagram { get; set; }   // لینک یا نام کاربری اینستاگرام
        public string? Twitter { get; set; }     // لینک یا نام کاربری توییتر
        public string? LinkedIn { get; set; }    // لینک یا نام کاربری لینکدین
        public string? YouTube { get; set; }     // لینک یا نام کاربری یوتیوب

        //First Address
        [Display(Name = "عنوان آدرس")]
        public string? AddressName1 { get; set; } = "";

        [Display(Name = "آدرس")]
        public string? Address1 { get; set; } = "";

        [Display(Name = "تلفن 1")]
        public string? Address1_Phone1 { get; set; } = "";

        [Display(Name = "تلفن 2")]
        public string? Address1_Phone2 { get; set; } = "";

        [Display(Name = "شماره همراه")]
        public string? Address1_Mobile { get; set; } = "";

        [Display(Name = "تلفکس")]
        public string? Address1_fax { get; set; } = "";

        [Display(Name = "پست الکترونیک")]
        public string? Address1_email { get; set; } = "";

        //2nd Address

        [Display(Name = "عنوان آدرس")]
        public string? AddressName2 { get; set; } = "";

        [Display(Name = "آدرس")]
        public string? Address2 { get; set; } = "";

        [Display(Name = "تلفن 1")]
        public string? Address2_Phone1 { get; set; } = "";

        [Display(Name = "تلفن 2")]
        public string? Address2_Phone2 { get; set; } = "";

        [Display(Name = "شماره همراه")]
        public string? Address2_Mobile { get; set; } = "";

        [Display(Name = "تلفکس")]
        public string? Address2_fax { get; set; } = "";

        [Display(Name = "پست الکترونیک")]
        public string? Address2_email { get; set; } = "";


    }
}
