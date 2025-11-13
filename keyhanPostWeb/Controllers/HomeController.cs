using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using keyhanPostWeb.Areas.CMS.CmsInterfaces;
using keyhanPostWeb.Areas.CMS.Dtos;
using keyhanPostWeb.Classes;
using keyhanPostWeb.GeneralService;
using keyhanPostWeb.Models.Entities.Identity;

namespace KeyhanPost.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentManager _IcontentManager;
        private readonly SignInManager<ApplicationUser> _signIn;
        private readonly IApplicationUserManager _userManager;
     

        public HomeController(ILogger<HomeController> logger
            , IContentManager IcontentManager,
             SignInManager<ApplicationUser> signIn
            , IApplicationUserManager userManager
         
            )
        {
            _logger = logger;
            _IcontentManager = IcontentManager;
            _signIn = signIn;
            _userManager = userManager;
           
        }
        //== Rasool Trading ...............................................................
        public IActionResult Home()
        {
            if (!_signIn.IsSignedIn(User))
                return RedirectToAction("SignIn", "Account");
            return View();
        }

        //=========================================
        public async Task<IActionResult> Index(string msg = "")
        {

            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            var cinfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.Projects = await _IcontentManager.GetProjects();
            siteContent.LastNews = _IcontentManager.GetBlogs().Result.Take(4).ToList();
            //siteContent.Products = await _IcontentManager.GetVmProductAndServices();
         
            siteContent.ServicePages = await _IcontentManager.GetServicePages();

            ViewBag.emailAddress = await _IcontentManager.GetEmailAddresses();
            return View(siteContent);
        }
    



        public async Task<IActionResult> ContactUs()
        {
            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.ServicePages = await _IcontentManager.GetServicePages();
            siteContent.LastNews = _IcontentManager.GetBlogs().Result.Take(4).ToList();
            ViewBag.emailAddress = await _IcontentManager.GetEmailAddresses();

            return View(siteContent);
        }
        public async Task<IActionResult> AboutUs()
        {
            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.LastNews = _IcontentManager.GetBlogs().Result.Take(4).ToList();
            return View(siteContent);
        }


        public async Task<IActionResult> ServicePage(int id)
        {
            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.ServicePages = await _IcontentManager.GetServicePages();
            siteContent.ServicePage = await _IcontentManager.ServiceFindAsync(id);
            return View(siteContent);
        }

        public async Task<IActionResult> Projects()
        {
            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.Projects = await _IcontentManager.GetProjects();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            return View(siteContent);
        }
        public async Task<IActionResult> ProjectDetails(int ProjectID)
        {
            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.Projects = await _IcontentManager.GetProjects(ProjectID);
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            return View(siteContent);
        }

        //
        //=============== Blog
        public async Task<IActionResult> blog(int pageID = 1, string category = "")
        {
            List<VmBlog> Blogs = await _IcontentManager.GetBlogs("", true, false, true);
            List<VmBlog> allBlogs = await _IcontentManager.GetBlogs(category);
            Vm_BlogPagination blogPgain = new Vm_BlogPagination();
            int take = 3;
            int skip = (pageID - 1) * take;
            decimal ListCount = allBlogs.Count;

            blogPgain.RowPerPage = take;
            blogPgain.CurrentPage = pageID;
            blogPgain.PageCount = (int)Math.Ceiling(ListCount / (decimal)take);
            blogPgain.Blogs = allBlogs.Skip(skip).Take(take).ToList();

            VmSiteContent siteContent = new VmSiteContent();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.NewsCategories = await _IcontentManager.CategoriesStatistic();
            siteContent.LastNews = Blogs.Skip(skip).Take(5).ToList();
            siteContent.Blogs = blogPgain;

            //Current category
            ViewBag.cat = category;

            return View(siteContent);
        }

        public async Task<IActionResult> blogDetails(int BlogID)
        {
            List<VmBlog> Blogs = await _IcontentManager.GetBlogs("", true, false, true);

            VmSiteContent siteContent = new VmSiteContent();
            //siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.NewsCategories = await _IcontentManager.CategoriesStatistic();
            siteContent.LastNews = Blogs.Take(6).ToList();
            siteContent.BlogDetails = await _IcontentManager.FindBlogAsync(BlogID);
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.BlogComments = await _IcontentManager.GetBlogComments(BlogID);

            return View(siteContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlogComment(VmSiteContent vm)
        {
            if (ModelState.IsValid)
            {
                vm.VmBlogComment.Approve = true;
                await _IcontentManager.AddNewsComment(vm.VmBlogComment);
            }
            return RedirectToAction("blogDetails", new { BlogID = vm.VmBlogComment.BlogID });
        }

        //
        //=============== Services
        public async Task<IActionResult> Services()
        {
            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            //siteContent.ProductCategories = await _IcontentManager.GetProductCategories();

            return View(siteContent);
        }

        public async Task<IActionResult> ServiceDetails(int servideID)
        {
            VmSiteContent siteContent = new VmSiteContent();
            var AllSection = await _IcontentManager.GetAllSection();

            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = AllSection;
            siteContent.SectionItem = AllSection.Where(n => n.SectionID == 2).FirstOrDefault().listItems.Where(i => i.Id == servideID).SingleOrDefault();
            siteContent.Products = await _IcontentManager.GetVmProductAndServices(servideID);
            // siteContent.ProductCategories = await _IcontentManager.GetProductCategories();
            ViewBag.CategoryId = servideID;

            return View(siteContent);
        }

        public async Task<IActionResult> Comingsoon(string msg = "")
        {
            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.Projects = await _IcontentManager.GetProjects();
            siteContent.LastNews = _IcontentManager.GetBlogs().Result.Take(3).ToList();

            return View(siteContent);
        }

        public async Task<IActionResult> Products(int CategoryId)
        {

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            ViewBag.emailAddress = await _IcontentManager.GetEmailAddresses();
            return PartialView("_SendEmail");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(SendEmailDto model)
        {
            if (model == null)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                var emailInfo = await _IcontentManager.CRMEmail_GetByIdAsync(model.EmailToId);
                model.EmailSubject = emailInfo[0];
                model.EmailTo = emailInfo[1];
                try
                {
                    EmailSender.SendByKeyhanpost(model);
                }
                catch (Exception ex)
                {
                    ResultDto res = new ResultDto
                    {
                        isSuccess = false,
                        Message = "پیام شما ارسال نشد. \n ممکن است به دلیل شلوغ بودن سرورها باشد. لطقاً مجددا دکمه ارسال را بزنید.",
                        returnUrl = Url.Action("Index", "Home", new { Area = "" })
                    };
                    string resJson = JsonConvert.SerializeObject(res);
                    return Json(resJson);
                }

                ResultDto result = new ResultDto
                {
                    isSuccess = true,
                    Message = "ضمن تشکر از ارتباط شما \n پیامتان با موفقیت ارسال شد.",
                    returnUrl = Url.Action("Index", "Home", new { Area = "" })
                };

                string jsonresult = JsonConvert.SerializeObject(result);
                return Json(jsonresult);
            }
            else
            {

                ResultDto res = new ResultDto
                {
                    isSuccess = false,
                    Message = "اطلاعات را بدرستی وارد نمائید",
                    returnUrl = Url.Action("Index", "Home", new { Area = "" })
                };
                foreach (var error in ModelState.Values.SelectMany(er => er.Errors))
                {
                    res.Message += "\n" + error.ErrorMessage;
                }
                string resJson = JsonConvert.SerializeObject(res);
                return Json(resJson);
            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pakages(int cid)
        {

            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            var cinfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.LastNews = _IcontentManager.GetBlogs().Result.Take(4).ToList();
         

            return View(siteContent);
        }
        public async Task<IActionResult> AllPakages(int cid)
        {

            VmSiteContent siteContent = new VmSiteContent();
            siteContent.CompanyInfo = await _IcontentManager.GetCompanyInfo();
            var cinfo = await _IcontentManager.GetCompanyInfo();
            siteContent.AllSection = await _IcontentManager.GetAllSection();
            siteContent.LastNews = _IcontentManager.GetBlogs().Result.Take(4).ToList();
           

            return View(siteContent);
        }

        public IActionResult loginOrRejister()
        {
            int check = 0;
            return PartialView("_loginOrRejister");
        }
        public IActionResult KPIndex()
        {
           
            return View();
        }
        public IActionResult Representative()
        {

            return View();
        }
        public IActionResult KPOrder()
        {

            return View();
        }
        public IActionResult KpAboutUs()
        {

            return View();
        }
        public IActionResult KpCallUs()
        {

            return View();
        }
        public IActionResult KpInternationalTracking()
        {

            return View();
        }
        public IActionResult KpChat()
        {

            return View();
        }
        public IActionResult KpOurService()
        {

            return View();
        }
        public IActionResult KpDomesticServices()
        {
            return View();
        }

        public IActionResult KpInternationalServices()
        {
            return View();
        }
        public IActionResult KpBlog()
        {

            return View();
        }
    }
}
