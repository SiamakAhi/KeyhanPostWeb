using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using keyhanPostWeb.Areas.CMS.CmsInterfaces;
using keyhanPostWeb.Areas.CMS.Dtos;
using Newtonsoft.Json;

namespace keyhanPostWeb.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize]
    public class ContentManagerController : Controller
    {
        private readonly IContentManager _IContentManager;

        public ContentManagerController(IContentManager IContentManager)
        {
            _IContentManager = IContentManager;
       
        }
        public async Task<IActionResult> Index()
        {

            List<VmSitePages> pagesAndSection = await _IContentManager.GetPagesList();
            return View(pagesAndSection);
        }

        [HttpGet]
        public IActionResult CreateSection(int SectionID, string PageTitle)
        {
            ViewBag.SectionID = SectionID;
            ViewData["SectionTitle"] = PageTitle;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSection(VmSectionContent vm)
        {

            if (ModelState.IsValid)
            {
                await _IContentManager.CreateSection(vm);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditTheContent(int SectionID, string PageTitle)
        {
            VmSectionContent theContent = await _IContentManager.GetTheContent(SectionID);
            ViewBag.SectionID = SectionID;
            ViewData["SectionTitle"] = PageTitle;

            return View(theContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTheContent(VmSectionContent vm)
        {
            if (ModelState.IsValid)
            {
                await _IContentManager.EditSection(vm);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [ActionName("CreateAnItem")]
        public async Task<IActionResult> CreateAnItem(int SectionID)
        {
            var TheContent = await _IContentManager.GetTheContent(SectionID);
            ViewBag.ContentID = TheContent.Id;
            ViewBag.SectionID = TheContent.SectionID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateAnItem")]
        public async Task<IActionResult> CreateAnItem(VmSectionListItem vm)
        {

            if (ModelState.IsValid)
            {
                await _IContentManager.CreateSectionItem(vm);
                var TheContent = await _IContentManager.GetTheContent(vm.SectionID);
                return RedirectToAction("EditTheContent", new { SectionID = TheContent.SectionID, PageTitle = TheContent.SectionName });
            }
            return View();
        }


        public async Task<IActionResult> DeleteItem(int ItemID, int sectionID)
        {
            await _IContentManager.DeleteSectionItem(ItemID);
            var TheContent = await _IContentManager.GetTheContent(sectionID);
            return RedirectToAction("EditTheContent", new { SectionID = TheContent.SectionID, PageTitle = TheContent.SectionName });
        }

        [HttpGet]
        public async Task<IActionResult> EditAnItem(int ItemID)
        {
            VmSectionListItem ViewModel = await _IContentManager.FindItemAsync(ItemID);
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnItem(VmSectionListItem vm)
        {

            if (ModelState.IsValid)
            {
                await _IContentManager.EditSectionItem(vm);
                var TheContent = await _IContentManager.GetTheContent(vm.SectionID);
                return RedirectToAction("EditTheContent", new { SectionID = TheContent.SectionID, PageTitle = TheContent.SectionName });
            }
            return View();
        }

        //Compani info. and Address
        [HttpGet]
        public async Task<IActionResult> CompanyInfo()
        {
            VmCompanyInfo CompanyInfo = new VmCompanyInfo();

            if (await _IContentManager.CompanyInfoHasData())
            {
                CompanyInfo = await _IContentManager.GetCompanyInfo();
            }

            return View(CompanyInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanyInfo(VmCompanyInfo vm)
        {

            if (ModelState.IsValid)
            {
                await _IContentManager.UpdateCompanyInfo(vm);
            }
            return View();
        }

        //=============================================Products Category

        [HttpGet]
        public async Task<IActionResult> ProductCategory()
        {
            List<VmProductCategory> categories = await _IContentManager.GetProductCategories();

            //اگر درخواست ajax بود
            var IsAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (IsAjax)
                return PartialView("_ProductCategory", categories);

            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return PartialView("_AddCategory");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(VmProductCategory vm)
        {
            if (ModelState.IsValid)
            {
                await _IContentManager.AddProductCategory(vm);
            }
            return PartialView("_AddCategory", vm);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            VmProductCategory cat = await _IContentManager.GetTheCategory(id);

            return PartialView("_UpdateCategory", cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(VmProductCategory vm)
        {
            if (ModelState.IsValid)
            {
                ViewData["result"] = await _IContentManager.UpdateProductCategory(vm);
            }
            return PartialView("_UpdateCategory", vm);
        }

        public async Task<IActionResult> deleteCategory(int id)
        {
            await _IContentManager.DeleteProduCategory(id);

            return RedirectToAction("ProductCategory");
        }
        //..........................................................................

        //=============================================Products And Services
        public async Task<IActionResult> ProductsManager(int pageId = 1, int row = 10)
        {
            var lstProducts = await _IContentManager.GetVmProductAndServices(null, null);

            VmProductsListView lst = new VmProductsListView();
            int take = row;
            int skip = (pageId - 1) * take;
            decimal ListCount = lstProducts.Count();
            lst.PageCount = pageId;
            lst.PageCount = (int)Math.Ceiling(ListCount / (decimal)take);
            lst.productAndServices = lstProducts.Skip(skip).Take(take).ToList();
            lst.RowPerPage = row;

            return View(lst);
        }

 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(VmProductAndService vm)
        {
            ViewBag.CategoryList = new SelectList(await _IContentManager.GetProductCategories(), "Id", "CategoryName");
          
            if (ModelState.IsValid)
            {
                ViewData["result"] = await _IContentManager.AddNewProductInfo(vm);
            }
            return RedirectToAction("ProductsManager");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProductInfo(int ProductID)
        {
            ViewBag.CategoryList = new SelectList(await _IContentManager.GetProductCategories(), "Id", "CategoryName");
           
            VmProductAndService pr = await _IContentManager.GetVmProductAndService(ProductID);
            return View(pr);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductInfo(VmProductAndService vm)
        {
            ViewBag.CategoryList = new SelectList(await _IContentManager.GetProductCategories(), "Id", "CategoryName");

            if (ModelState.IsValid)
            {
                ViewData["result"] = await _IContentManager.UpdateProductInfo(vm);
            }
            return RedirectToAction("ProductsManager");
        }


        [HttpGet]
        public async Task<IActionResult> AddProductImage(int ProductId)
        {
            VmProductAndServiceImages vm = new VmProductAndServiceImages();
            var product = (await _IContentManager.GetVmProductAndServices()).Where(n => n.ProductID == ProductId).SingleOrDefault();
            vm.CategoryID = product.ProductID;
            vm.ProductName = product.ShortTitle;
            vm.CategoryName = product.CategoryName;
            vm.ProductID = product.ProductID;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductImage(VmProductAndServiceImages vm)
        {
            if (ModelState.IsValid)
            {
                ViewData["result"] = await _IContentManager.AddNewProductImage(vm);
            }
            return RedirectToAction("ProductsManager");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(int ImageID)
        {
            VmProductAndServiceImages vm = await _IContentManager.GetProductImage(ImageID);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductImage(VmProductAndServiceImages vm)
        {
            if (ModelState.IsValid)
            {
                ViewData["result"] = await _IContentManager.UpdateProductImage(vm);
            }
            return RedirectToAction("ProductsManager");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeAvalable(int Id)
        {
            await _IContentManager.ChangeProductAvalable(Id);
            return RedirectToAction("ProductsManager");
        }

        [HttpGet]
        public async Task<IActionResult> AlowShowPrice(int ProductID)
        {
            await _IContentManager.ChangeAlowShowPrice(ProductID);
            return RedirectToAction("ProductsManager");
        }
        public async Task<IActionResult> DeleteProduct(int ProductID)
        {
            await _IContentManager.DeleteProduct(ProductID);

            return RedirectToAction("ProductsManager");
        }

        //============ All Projects
        public async Task<IActionResult> Projects(int pageId = 1, int? catID = null)
        {

            var lstProjects = await _IContentManager.GetProjects(null);

            Vm_Projects lst = new Vm_Projects();
            int take = 40;
            int skip = (pageId - 1) * take;
            decimal ListCount = lstProjects.Count();
            lst.PageCount = pageId;
            lst.PageCount = (int)Math.Ceiling(ListCount / (decimal)take);
            lst.Projects = lstProjects.Skip(skip).Take(take).ToList();
            lst.RowPerPage = 40;

            return View(lst);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewProject()
        {
            ViewBag.ProductAndServicesList = await _IContentManager.SelectList_Product();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewProject(VmProject vm)
        {
            if (ModelState.IsValid)
            {
                if (Convert.ToBoolean(await _IContentManager.AddNewProjectInfo(vm)))
                {
                    return RedirectToAction("Projects");
                }
            }
            ViewBag.ProductAndServicesList = await _IContentManager.SelectList_Product();
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
            VmProject vm = await _IContentManager.GetTheProject(id);
            ViewBag.ProductAndServicesList = await _IContentManager.SelectList_Product();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProject(VmProject vm)
        {
            if (ModelState.IsValid)
            {
                if (Convert.ToBoolean(await _IContentManager.UpdateProjectInfo(vm)))
                {
                    return RedirectToAction("Projects");
                }
            }
            ViewBag.ProductAndServicesList = await _IContentManager.SelectList_Product();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddProjectImage(int id)
        {
            ProjectVm vm = new ProjectVm();
            vm.ProjectInfo = await _IContentManager.GetTheProject(id);
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProjectImage(ProjectVm n)
        {
            ProjectVm vm = new ProjectVm();
            if (ModelState.IsValid)
            {
                await _IContentManager.AddNewProjectImage(n.ProjectImage);

            }

            return RedirectToAction("AddProjectImage", new { id = n.ProjectImage.ProjectId });
        }

        public async Task<IActionResult> DeleteProjectImage(int id, int pid)
        {
            await _IContentManager.DeleteProjectImage(id);

            return RedirectToAction("AddProjectImage", new { id = pid });
        }
        // Blog ======================================================================================================= Blog

        [HttpGet]
        public IActionResult AddBlogCategory()
        {
            return PartialView("_AddBlogCategory");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlogCategory(VmBlogCategory vm)
        {
            clsResult result = new clsResult();
            result.Success = false;

            if (ModelState.IsValid)
            {
                result = await _IContentManager.AddBlogCategory(vm);
                if (result.Success)
                {
                    result.updateType = 1;
                    result.returnUrl = Request.Headers["Referer"].ToString();
                }
            }
            string jsonResult = JsonConvert.SerializeObject(result);
            return Json(jsonResult);
        }

        [HttpGet]
        public async Task<IActionResult> BlogsCategory()
        {

            VmBlogCategories model = new VmBlogCategories();
            model.Category = new VmBlogCategory();
            model.Categories = await _IContentManager.GetBlogCategories();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> BlogsManager()
        {
            Vm_BlogPagination blogs = new Vm_BlogPagination();
            blogs.Blogs = await _IContentManager.GetBlogs();
            return View(blogs);
        }

        [HttpGet]
        [ActionName("AddNews")]
        public IActionResult AddNews()
        {
            ViewBag.Categories = new SelectList(_IContentManager.GetCategoriesList(), "name", "name");
            return View();
        }

        [HttpPost]
        [ActionName("AddNews")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNews(VmBlog vm)
        {
            if (ModelState.IsValid)
            {
                await _IContentManager.AddNews(vm);
                return RedirectToAction("BlogsManager");
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> EditNews(int blogID)
        {
            ViewBag.Categories = new SelectList(_IContentManager.GetCategoriesList(), "name", "name");
            VmBlogForEdit vm = await _IContentManager.FindBlogAsync(blogID);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNews(VmBlogForEdit vm)
        {
            if (ModelState.IsValid)
            {
                vm.Sender = "مدیر سایت";
                await _IContentManager.UpdateNews(vm);
                return RedirectToAction("BlogsManager");
            }
            return View(vm);
        }

        public async Task<IActionResult> ChangeApprove(int blogID)
        {
            await _IContentManager.NewsApprove(blogID);
            return RedirectToAction("BlogsManager");
        }

        public async Task<IActionResult> DeleteNews(int blogID)
        {
            await _IContentManager.DeleteNews(blogID);
            return RedirectToAction("BlogsManager");
        }
        public async Task<IActionResult> RemoveImage(int blogID, int ImageNumber)
        {
            await _IContentManager.DeleteAdditionalNewsimage(blogID, ImageNumber);
            return RedirectToAction("BlogsManager");
        }

        //...
        public IActionResult BlogCommentManagement(List<VmBlogComment> Comm)
        {
            List<VmBlogComment> Comments = new List<VmBlogComment>();
            if (Comm.Count > 0 && Comm != null)
                Comments = Comm;

            return View(Comments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogCommentManagement(int BlogId)
        {
            List<VmBlogComment> Comments = await _IContentManager.GetBlogComments(BlogId);
            return View(Comments);
        }

        public async Task<IActionResult> ApproveCom(int ComId, int BlogId)
        {
            await _IContentManager.NewsCommentApprove(ComId);
            List<VmBlogComment> Comments = await _IContentManager.GetBlogComments(BlogId);
            return RedirectToAction("BlogCommentManagement", new { Comm = Comments });
        }

        public async Task<IActionResult> ServiceContent()
        {
            List<ServicePageViewModel> model = new List<ServicePageViewModel>();

            model = await _IContentManager.GetServicePages();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(ServicePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Int16 res = await _IContentManager.CreateNewServiceAsync(model);
                if (res == 1)
                    return RedirectToAction("ServiceContent");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateServiceInfo(int id)
        {
            ServicePageViewModel model = await _IContentManager.ServiceFindAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateServiceInfo(ServicePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Int16 res = await _IContentManager.UpdateServiceInfoAsync(model);
                if (res == 1)
                    return RedirectToAction("ServiceContent");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteServiceInfo(int id)
        {
            Int16 res = await _IContentManager.DeleteServiceAsync(id);
            return RedirectToAction("ServiceContent");
        }
    }
}