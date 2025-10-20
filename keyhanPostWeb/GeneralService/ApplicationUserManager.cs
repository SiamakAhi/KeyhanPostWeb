using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using keyhanPostWeb.GeneralInterfaces;
using keyhanPostWeb.GeneralViewModels.Identity;
using keyhanPostWeb.Models;
using keyhanPostWeb.Models.Entities.Identity;

namespace keyhanPostWeb.GeneralService
{
    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        private readonly PersianIdentityError _errors;
        private readonly ILookupNormalizer _lookupNormalizer;
        private readonly ILogger<ApplicationUserManager> _logger;
        private readonly IOptions<IdentityOptions> _option;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IEnumerable<IPasswordValidator<ApplicationUser>> _passwordValidator;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IEnumerable<IUserValidator<ApplicationUser>> _userValidators;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IPersonService _PersonService;

        public ApplicationUserManager(
            PersianIdentityError errors,
        ILookupNormalizer lookupNormalizer,
        ILogger<ApplicationUserManager> logger,
        IOptions<IdentityOptions> option,
        IPasswordHasher<ApplicationUser> passwordHasher,
        IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidator,
        IServiceProvider serviceProvider,
        IUserStore<ApplicationUser> userStore,
        IEnumerable<IUserValidator<ApplicationUser>> userValidators,
        SignInManager<ApplicationUser> signInManager,
        AppDbContext db,
        IWebHostEnvironment env,
        IApplicationRoleManager roleManager,
        IPersonService PersonService

            )
            : base(userStore, option, passwordHasher, userValidators, passwordValidator, lookupNormalizer, errors, serviceProvider, logger)
        {

            _errors = errors;
            _lookupNormalizer = lookupNormalizer;
            _logger = logger;
            _option = option;
            _passwordHasher = passwordHasher;
            _passwordValidator = passwordValidator;
            _serviceProvider = serviceProvider;
            _userStore = userStore;
            _userValidators = userValidators;
            _signInManager = signInManager;
            _db = db;
            _env = env;
            _roleManager = roleManager;
            _PersonService = PersonService;
        }


        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await Users.ToListAsync();
        }
        public async Task<List<UsersViewModel>> GetAllUsersWithRolesAsync()
        {
            return await _db.Users.Include(n => n.Roles).Select(user => new UsersViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FName,
                LastName = user.Family,
                BirthDate = user.Birthday,
                IsActive = user.IsActive,
                LastVisitDateTime = user.LastVisitDate,
                Image = user.Avatar,
                RegisterDate = user.RegistrDate,
                Gender = user.Gender,
                Roles = user.Roles.Select(u => new VmRole
                {
                    Id = u.RoleId,
                    Name = u.Role.Name,
                    Description = u.Role.Description
                }).ToList(),
            }).ToListAsync();
        }
        public async Task<List<UsersViewModel>> GetEmployeesAsync(bool isActive = true)
        {
            return await Users.Where(n =>
            n.IsEmployee == true
            && (isActive == true ? n.IsActive == isActive : n.Id != null)
            ).Select(user => new UsersViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FName,
                LastName = user.Family,
                BirthDate = user.Birthday,
                IsActive = user.IsActive,
                LastVisitDateTime = user.LastVisitDate,
                Image = user.Avatar,
                RegisterDate = user.RegistrDate,
                Gender = user.Gender,

            }).ToListAsync();
        }
        public async Task<string[]> GetUserRolesAsync(ApplicationUser user)
        {
            string[] roles;
            var usr = await Users.FirstOrDefaultAsync(n => n.Id == user.Id);
            roles = usr.Roles.Select(r => r.Role.Name).ToArray();
            return roles;
        }
        public string[] GetUserRoles(string UserId)
        {
            string[] roles;
            roles = Users.FirstOrDefault(n => n.Id == UserId).Roles.Select(r => r.Role.Name).ToArray();
            return roles;
        }
        public UsersViewModel UserInfo(string UserName)
        {
            var user = Users.Include(r => r.Roles).SingleOrDefault(u => u.UserName == UserName);
            UsersViewModel vm = new UsersViewModel
            {
                FirstName = user.FName,
                LastName = user.Family,
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id,
                BirthDate = user.Birthday,
                Gender = user.Gender,
                Image = user.Avatar,
                PhoneNumber = user.PhoneNumber,
                LastVisitDateTime = user.LastVisitDate,
                IsActive = user.IsActive,
                PersonId = user.PersonId,
            };

            if (user.Roles != null)
            {
                string[] RolesID = user.Roles.Select(n => n.RoleId).ToArray();

                vm.Roles = _db.Roles.Where(n => RolesID.Contains(n.Id)).Select(n => new VmRole
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description
                }).ToList();
            }

            return vm;
        }

        public UsersViewModel UserInfoById(string UserId)
        {
            var user = Users.Include(r => r.Roles).SingleOrDefault(u => u.Id == UserId);
            UsersViewModel vm = new UsersViewModel
            {
                FirstName = user.FName,
                LastName = user.Family,
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id,
                BirthDate = user.Birthday,
                Gender = user.Gender,
                Image = user.Avatar,
                PhoneNumber = user.PhoneNumber,
                LastVisitDateTime = user.LastVisitDate,
                IsActive = user.IsActive,
            };

            if (user.Roles != null)
            {
                string[] RolesID = user.Roles.Select(n => n.RoleId).ToArray();

                vm.Roles = _db.Roles.Where(n => RolesID.Contains(n.Id)).Select(n => new VmRole
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description
                }).ToList();
            }

            return vm;
        }
        public async Task<string> GetFullNameAsync(ApplicationUser user)
        {
            await Task.CompletedTask;
            return user.FName + " " + user.Family;
        }
        public string GetFullName(ApplicationUser user)
        {
            return user.FName + " " + user.Family;
        }
        public async Task<int> GetActiveUsersCount()
        {
            return await Users.Where(n => n.IsActive == true).CountAsync();
        }
        public string NormalizeKey(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> AddEmployeeAsync(VmRegisterUser emp)
        {
            ApplicationUser user = new ApplicationUser();
            user.FName = emp.FName;
            user.Family = emp.LName;
            user.PhoneNumber = emp.Mobile;
            user.Email = emp.email;
            user.UserName = emp.Name;
            user.IsActive = true;
            user.IsEmployee = true;
            user.RegistrDate = DateTime.Now;

            var result = await CreateAsync(user, emp.Password);
            if (emp.Roles.Length > 0 && result.Succeeded)
            {
                foreach (var r in emp.Roles)
                {
                    await AddToRoleAsync(user, r);
                }
            }

            return result;
        }

        public async Task<IdentityResult> UpdateProfile(VmUpdateProfile model)
        {
            IdentityResult result = new IdentityResult();
            // Save User Avatar
            string fileName = "";
            string SavePath = "";
            if (model.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = string.Concat("Avatar_", model.userName, FileExtension);
                SavePath = $"{_env.WebRootPath}/img/avatars/{fileName}";

                using (var stm = new FileStream(SavePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stm);
                }
            }

            ApplicationUser user = await Users.Where(u => u.Id == model.Id).SingleOrDefaultAsync();

            user.Email = model.Email;
            try
            {
                user.Birthday = model.BirthDate.Value;
            }
            catch
            {
            }

            user.Family = model.LastName;
            user.FName = model.FirstName;
            user.Gender = model.Gender.Value;
            user.Mobile = model.Mobile;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            if (fileName != "")
                user.Avatar = fileName;
            try
            {
                _db.Users.Update(user);
                await _db.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public async Task<clsResult> UpdateUserProfileAsync(VmUpdateProfile model)
        {
            clsResult result = new clsResult();
            // Save User Avatar
            string fileName = "";
            string SavePath = "";
            if (model.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = string.Concat("Avatar_", model.userName, FileExtension);
                SavePath = $"{_env.WebRootPath}/img/avatars/{fileName}";

                using (var stm = new FileStream(SavePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stm);
                }
            }

            ApplicationUser user = await Users.Where(u => u.Id == model.Id).SingleOrDefaultAsync();

            user.Email = model.Email;
            try
            {
                user.Birthday = model.BirthDate.Value;
            }
            catch
            {
            }

            user.Family = model.LastName;
            user.FName = model.FirstName;
            user.Gender = model.Gender.Value;
            user.Mobile = model.Mobile;
            user.Email = model.Email;
            user.PhoneNumber = model.Mobile;

            if (fileName != "")
                user.Avatar = fileName;
            try
            {
                _db.Users.Update(user);
                await _db.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception)
            {
                result.Message = "در عملیات بروزرسانی اطاعات کاربری خطایی رخ داده است";
                result.Success = false;
            }
            return result;
        }

        public async Task<IdentityResult> SetLastVisitAsync(string UserName)
        {
            ApplicationUser user = Users.Where(n => n.UserName == UserName).SingleOrDefault();
            user.LastVisitDate = DateTime.Now;
            var result = await UpdateUserAsync(user);
            return result;
        }
        public async Task<VmUpdateProfile> GetUserVmAsync(string UserName)
        {
            ApplicationUser u = await Users.Where(n => n.UserName == UserName).SingleOrDefaultAsync();
            VmUpdateProfile vm = new VmUpdateProfile();
            vm.BirthDate = u.Birthday;
            try { vm.StrBirthDate = u.Birthday.mdToLongPersianDate(); } catch { }
            vm.Email = u.Email;
            vm.FirstName = u.FName;
            vm.Gender = u.Gender;
            vm.Id = u.Id;
            vm.Image = u.Avatar;
            vm.LastName = u.Family;
            vm.PhoneNumber = u.PhoneNumber;
            vm.userName = u.UserName;
            vm.Mobile = u.Mobile;
            return vm;
        }

        public async Task<IdentityResult> SignUpAsync(VmSignUp usr)
        {
            string[] rols = { "Member" };
            usr.Roles = rols;

            ApplicationUser user = new ApplicationUser();
            user.FName = usr.FName;
            user.Family = usr.LName;
            user.PhoneNumber = usr.Mobile;
            user.UserName = usr.Name;
            user.IsActive = true;
            user.IsEmployee = false;
            user.RegistrDate = DateTime.Now;
            user.Email = "temp@ot.ir";


            var result = await CreateAsync(user, usr.Password);
            if (usr.Roles.Length > 0 && result.Succeeded)
            {
                ApplicationRole role = await _roleManager.FindByNameAsync("Member");
                if (role == null)
                {
                    role = new ApplicationRole()
                    {
                        Name = "Member",
                        Description = "عضو"
                    };

                    await _roleManager.CreateAsync(role);
                }

                await AddToRoleAsync(user, "Member");

            }

            return result;
        }

        public async Task<IdentityResult> UserRegisterAsync(VmSignUp usr)
        {

            ApplicationUser user = new ApplicationUser();
            user.FName = usr.FName;
            user.Family = usr.LName;
            user.PhoneNumber = usr.Mobile;
            user.UserName = usr.Name;
            user.IsActive = true;
            user.IsEmployee = false;
            user.RegistrDate = DateTime.Now;
            user.Mobile = usr.Mobile;
            user.Email = usr.Email;



            var result = await CreateAsync(user, usr.Password);
            if (usr.Roles.Length > 0 && result.Succeeded)
            {
                foreach (var Role in usr.Roles)
                {
                    ApplicationRole role = await _roleManager.FindByNameAsync(Role);
                    if (role == null)
                    {
                        role = new ApplicationRole()
                        {
                            Name = Role,
                            Description = "عضو"
                        };

                        await _roleManager.CreateAsync(role);
                    }

                    await AddToRoleAsync(user, Role);
                }
            }

            return result;
        }

        public async Task<List<VmRole>> GetUserRolesByNameAsync(string userName)
        {
            var user = await Users.Include(n => n.Roles).SingleOrDefaultAsync(n => n.UserName == userName);

            List<VmRole> roles = new List<VmRole>();
            if (user != null)
            {
                var Roles = await _db.UserRoles
               .Where(n => n.UserId == user.Id)
               .Join(_db.Roles, n => n.RoleId, r => r.Id, (n, r) => new VmRole
               {
                   Id = n.RoleId,
                   Description = r.Description,
                   Name = r.Name,
               }).ToListAsync();

                roles.AddRange(Roles);
            }


            return roles;
        }

    }
}
