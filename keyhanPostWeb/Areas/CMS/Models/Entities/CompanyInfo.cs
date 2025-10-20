using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class CompanyInfo
    {
        [Key]
        public short id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string? SabtNo { get; set; }
        public string? MeliNo { get; set; }
        public string? Logo { get; set; }

        // فیلدهای مربوط به شبکه‌های اجتماعی
        public string? Facebook { get; set; }    // لینک یا نام کاربری فیسبوک
        public string? Instagram { get; set; }   // لینک یا نام کاربری اینستاگرام
        public string? Twitter { get; set; }     // لینک یا نام کاربری توییتر
        public string? LinkedIn { get; set; }    // لینک یا نام کاربری لینکدین
        public string? YouTube { get; set; }     // لینک یا نام کاربری یوتیوب

        //First Address
        public string AddressName1 { get; set; }
        public string? Address1 { get; set; }
        public string? Address1_Phone1 { get; set; }
        public string? Address1_Phone2 { get; set; }
        public string? Address1_Mobile { get; set; }
        public string? Address1_fax { get; set; }
        public string? Address1_email { get; set; }

        //2nd Address
        public string? AddressName2 { get; set; }
        public string? Address2 { get; set; }
        public string? Address2_Phone1 { get; set; }
        public string? Address2_Phone2 { get; set; }
        public string? Address2_Mobile { get; set; }
        public string? Address2_fax { get; set; }
        public string? Address2_email { get; set; }
    }
}
