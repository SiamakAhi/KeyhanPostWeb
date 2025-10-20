using Microsoft.AspNetCore.Identity;

namespace keyhanPostWeb.Models.Entities.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string Name) : base(Name)
        {

        }
        public ApplicationRole(string Name, string description) : base(Name)
        {
            Description = description;

        }

        public string Description { get; set; }
        public virtual List<ApplicationUserRole> Users { get; set; }
    }
}
