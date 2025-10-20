using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using keyhanPostWeb.Areas.CMS.CmsInterfaces;
using keyhanPostWeb.GeneralInterfaces;
using keyhanPostWeb.GeneralService;
using keyhanPostWeb.GeneralViewModels.Identity;
using keyhanPostWeb.Models.Entities.Identity;
using keyhanPostWeb;
using keyhanPostWeb.Areas.Club.Dtos;

namespace QuineWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationRoleManager _roleManager;
        private readonly SignInManager<ApplicationUser> _signIn;
        private readonly IContentManager _IcontentManager;
 
        public AccountController(
            IApplicationUserManager userManager,
            IApplicationRoleManager roleManager,
            SignInManager<ApplicationUser> signIn
            , IContentManager IcontentManager
           
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _IcontentManager = IcontentManager;
            _signIn = signIn;
           
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            if (_signIn.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            ViewData["ReturnUrl"] = Request.Headers["Referer"].ToString();

            return PartialView("_SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModel vm)
        {
            clsResult result = new clsResult();
            result.Success = false;
            result.updateType = 1;


            if (_signIn.IsSignedIn(User))
                return NoContent();

            if (ModelState.IsValid)
            {
                var loginresult = await _signIn.PasswordSignInAsync(vm.UserName, vm.Password, vm.RememberMe, false);

                if (loginresult.Succeeded)
                {
                    // await _userManager.SetLastVisitAsync(vm.UserName);
                    result.Success = true;
                    result.Message = "ورود با موفقیت انجام شد";
                    result.returnUrl = Request.Headers["Referer"].ToString();
                }
                else
                {
                    result.Message = "نام کاربری یا رمز عبور اشتباه است";
                }
            }
            else
            {
                result.Message = "لطفا فیلدهای الزامی را پر کنید";
            }
            string jsonresult = JsonConvert.SerializeObject(result);
            return Json(jsonresult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRegister(LoginRegisterDto vm)
        {
            clsResult result = new clsResult();
            result.Success = false;
            result.updateType = 1;

            if (_signIn.IsSignedIn(User))
                return NoContent();

            if (ModelState.IsValid)
            {
                var regResult = await _userManager.UserRegisterAsync(vm.register);
                if (regResult.Succeeded)
                {
                    
                    var loginresult = await _signIn.PasswordSignInAsync(vm.register.Name, vm.register.Password, false, false);
                    if (loginresult.Succeeded)
                    {
                        //await _userManager.SetLastVisitAsync(vm.register.Name);
                        result.Success = true;
                        result.ShowMessage = false;
                        result.Message = "ورود با موفقیت انجام شد";
                        result.returnUrl = Request.Headers["Referer"].ToString();
                    }
                }
                else
                {
                    var errors = regResult.Errors.ToList();
                    foreach (var er in errors)
                    {
                        result.Message += "\n " + er.Description;
                    }
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                foreach (var er in errors)
                {
                    result.Message += "\n " + er.ErrorMessage;
                }
            }
            string jsonresult = JsonConvert.SerializeObject(result);
            return Json(jsonresult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginRegisterDto vm)
        {
            clsResult result = new clsResult();
            result.Success = false;
            result.updateType = 1;

            if (_signIn.IsSignedIn(User))
                return NoContent();

            if (ModelState.IsValid)
            {
                var loginresult = await _signIn.PasswordSignInAsync(vm.login.UserName, vm.login.Password, vm.login.RememberMe, false);

                if (loginresult.Succeeded)
                {
                    // await _userManager.SetLastVisitAsync(vm.login.UserName);
                    result.Success = true;
                    result.Message = "ورود با موفقیت انجام شد";
                    result.returnUrl = Request.Headers["Referer"].ToString();
                }
                else
                {
                    result.Message = "نام کاربری یا رمز عبور اشتباه است";
                }
            }
            else
            {
                result.Message = "لطفا فیلدهای الزامی را پر کنید";
            }
            string jsonresult = JsonConvert.SerializeObject(result);
            return Json(jsonresult);
        }
        public async Task<IActionResult> Signout(string returnUrl)
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            await _signIn.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            if (_signIn.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            ViewData["ReturnUrl"] = Request.Headers["Referer"].ToString();

            return PartialView("_SignUp");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(VmSignUp vm)
        {
            clsResult result = new clsResult();
            result.Success = false;
            result.updateType = 1;

            if (_signIn.IsSignedIn(User))
                return NoContent();

            if (ModelState.IsValid)
            {
                var regResult = await _userManager.UserRegisterAsync(vm);
                if (regResult.Succeeded)
                {
                    var loginresult = await _signIn.PasswordSignInAsync(vm.Name, vm.Password, false, false);
                    if (loginresult.Succeeded)
                    {
                        // await _userManager.SetLastVisitAsync(vm.Name);
                        result.Success = true;
                        result.ShowMessage = false;
                        result.Message = "ثبت نام شما با موفقیت انجام شد";
                        result.returnUrl = Request.Headers["Referer"].ToString();
                    }
                    else
                    {
                        var errors = regResult.Errors.ToList();
                        foreach (var er in errors)
                        {
                            result.Message += "\n " + er.Description;
                        }
                    }
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                foreach (var er in errors)
                {
                    result.Message += "\n " + er.ErrorMessage;
                }
            }
            string jsonresult = JsonConvert.SerializeObject(result);
            return Json(jsonresult);
        }

        //LoginRegisterDto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp2(LoginRegisterDto vm)
        {
            clsResult result = new clsResult();
            result.Success = false;
            result.updateType = 1;

            if (_signIn.IsSignedIn(User))
                return NoContent();

            if (ModelState.IsValid)
            {
                var regResult = await _userManager.UserRegisterAsync(vm.register);
                if (regResult.Succeeded)
                {
                    var loginresult = await _signIn.PasswordSignInAsync(vm.register.Name, vm.register.Password, false, false);
                    if (loginresult.Succeeded)
                    {
                        // await _userManager.SetLastVisitAsync(vm.Name);
                        result.Success = true;
                        result.ShowMessage = false;
                        result.Message = "ثبت نام شما با موفقیت انجام شد";
                        result.returnUrl = Request.Headers["Referer"].ToString();
                    }
                    else
                    {
                        var errors = regResult.Errors.ToList();
                        foreach (var er in errors)
                        {
                            result.Message += "\n " + er.Description;
                        }
                    }
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                foreach (var er in errors)
                {
                    result.Message += "\n " + er.ErrorMessage;
                }
            }
            string jsonresult = JsonConvert.SerializeObject(result);
            return Json(jsonresult);
        }

        //...................... User Profile 
        public async Task<IActionResult> UserProfile(string? message = null)
        {
            if (message != null)
            {
                ViewBag.msg = message;
            }
            VmUserProfile model = new VmUserProfile();
            model.UpdateProfile = await _userManager.GetUserVmAsync(User.Identity.Name);
            model.UserRoles = await _userManager.GetUserRolesByNameAsync(User.Identity.Name);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserProfile()
        {
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            VmUpdateProfile model = new VmUpdateProfile()
            {
                Email = user.Email,
                FirstName = user.FName,
                LastName = user.Family,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                userName = user.UserName,
                BirthDate = user.Birthday,
                Gender = user.Gender,
                Image = user.Avatar,
                Mobile = user.Mobile,

            };
            model.StrBirthDate = user.Birthday < DateTime.Now.AddYears(-90) ? DateTime.Now.AddYears(-30).LatinToPersian() : user.Birthday.LatinToPersian();
            return PartialView("_UpdateUserProfile", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserProfile(VmUpdateProfile user)
        {
            clsResult result = new clsResult();
            result.Success = false;
            result.ShowMessage = true;

            user.BirthDate = user.StrBirthDate?.PersianToLatin();
            if (ModelState.IsValid)
            {
                result = await _userManager.UpdateUserProfileAsync(user);
                if (result.Success)
                {
                    result.updateType = 1;
                    result.returnUrl = Request.Headers["Referer"].ToString();
                }
            }
            if (ModelState.ErrorCount > 0)
            {
                var errors = ModelState.Values.SelectMany(n => n.Errors).ToList();
                foreach (var error in errors)
                {
                    result.Message += $"<br> {error.ErrorMessage}";
                }
            }
            return Json(result.ToJsonResult());
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(VmChangePass model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            string msg = "";
            if (ModelState.IsValid)
            {
                var res = await _userManager.RemovePasswordAsync(user);
                if (res.Succeeded)
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
                    msg = "بروزرسانی رمز عبور شما با موفقیت انجام شد";
                    return RedirectToAction("UserProfile", new { message = msg });
                }
            }
            msg = "مشکلی در تغییر کلمه عبور پیش آمده است. لطفاً مجددا سعی کنید";
            return RedirectToAction("UserProfile", new { message = msg });
        }

    }
}
