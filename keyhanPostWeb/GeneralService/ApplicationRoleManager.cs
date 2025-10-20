using Microsoft.AspNetCore.Identity;
using keyhanPostWeb.GeneralInterfaces;
using keyhanPostWeb.GeneralViewModels.Identity;
using keyhanPostWeb.Models.Entities.Identity;

namespace keyhanPostWeb.GeneralService
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>, IApplicationRoleManager
    {
        private readonly IdentityErrorDescriber _error;
        private readonly ILookupNormalizer _Normalizer;
        private readonly ILogger<ApplicationRoleManager> _Logger;
        private readonly IEnumerable<IRoleValidator<ApplicationRole>> _validators;
        private readonly IRoleStore<ApplicationRole> _store;

        public ApplicationRoleManager(
                IdentityErrorDescriber error,
                ILookupNormalizer Normalizer,
                ILogger<ApplicationRoleManager> Logger,
                IEnumerable<IRoleValidator<ApplicationRole>> validators,
                IRoleStore<ApplicationRole> store)
            : base(store, validators, Normalizer, error, Logger)
        {
            _error = error;
            _Normalizer = Normalizer;
            _Logger = Logger;
            _validators = validators;
            _store = store;

        }

        public List<ApplicationRole> GetAllRole()
        {
            return Roles.ToList();
        }

        public List<RolesViewModel> RolesViewModelList()
        {
            return Roles.Select(n => new RolesViewModel
            {
                Description = n.Description,
                Id = n.Id,
                Name = n.Name,
                UsersCount = n.Users.Count
            }).ToList();
        }
    }
}
