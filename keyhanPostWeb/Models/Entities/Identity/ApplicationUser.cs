using Microsoft.AspNetCore.Identity;
using keyhanPostWeb.Models.Entities.Identity;


namespace keyhanPostWeb.Models.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string Family { get; set; }
        public short Gender { get; set; } = 2;
        public string Mobile { get; set; }
        public string? Avatar { get; set; } = "";
        public DateTime Birthday { get; set; } = DateTime.Now.AddYears(-20);
        public DateTime LastVisitDate { get; set; } = DateTime.Now;
        public DateTime RegistrDate { get; set; } = DateTime.Now;
        public bool IsEmployee { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int? PersonId { get; set; }

        public virtual List<ApplicationUserRole> Roles { get; set; }



    }
}
