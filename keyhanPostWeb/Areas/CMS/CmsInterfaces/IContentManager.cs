using Microsoft.AspNetCore.Mvc.Rendering;
using keyhanPostWeb.Areas.CMS.Dtos;

namespace keyhanPostWeb.Areas.CMS.CmsInterfaces
{
    public interface IContentManager
    {
        Task<VmSectionContent> GetTheContent(int sectionID);
        Task<Int16> CreateSection(VmSectionContent vmSection);
        Task<Int16> EditSection(VmSectionContent vmSection);
        Task<List<VmSectionListItem>> GetSectionItems(int id);
        Task<VmSectionListItem> FindItemAsync(int Id);
        Task<Int16> CreateSectionItem(VmSectionListItem Item);
        Task<Int16> DeleteSectionItem(int id);
        Task<Int16> EditSectionItem(VmSectionListItem Item);
        Task<List<VmSitePages>> GetPagesList();
        Task<string> GetSectionTitle(int SectionID);
        Task<List<VmSectionContent>> GetAllSection();
        //.......................................................................................

        //Company Information
        Task<bool> CompanyInfoHasData();
        Task<VmCompanyInfo> GetCompanyInfo();
        Task<Int16> UpdateCompanyInfo(VmCompanyInfo n);
        Task<Int16> AddCompanyInfo(VmCompanyInfo n);
        //......................................................................................

        //Products Category
        Task<List<VmProductCategory>> GetProductCategories(bool IsActive = true);
        Task<VmProductCategory> GetTheCategory(int Id);
        Task<Int16> AddProductCategory(VmProductCategory n);
        Task<Int16> UpdateProductCategory(VmProductCategory n);
        Task<Int16> UpdateProductCategory(int Id);
        Task<Int16> DeleteProduCategory(int Id);
        Task<SelectList> SelectList_ProductCategories();
        //...................................................................................

        //Products
        Task<List<VmProductAndService>> GetVmProductAndServices(int? CategoryID = null, bool? IsProduct = null);
        Task<VmProductAndService> GetVmProductAndService(int Id);
        Task<Int16> AddNewProductInfo(VmProductAndService n);
        Task<Int16> UpdateProductInfo(VmProductAndService n);
        Task<Int16> ChangeProductViewInHome(int Id);
        Task<Int16> ChangeProductAvalable(int Id);
        Task<Int16> ChangeAlowShowPrice(int Id);
        Task<Int16> AddNewProductImage(VmProductAndServiceImages n);
        Task<Int16> UpdateProductImage(VmProductAndServiceImages n);
        Task<Int16> DeleteProductImage(int Id);
        Task<Int16> DeleteProduct(int Id);
        Task<Int16> SetAsMainProductImage(int Id);
        Task<VmProductAndServiceImages> GetProductImage(int Id);
        Task<Int16> DeleteAdditionalNewsimage(int Id, int imageNumber);
        Task<SelectList> SelectList_Product(int? CategoryID = null);
        //...................................................................................

        // Services
        Task<Int16> CreateNewServiceAsync(ServicePageViewModel vm);
        Task<Int16> UpdateServiceInfoAsync(ServicePageViewModel vm);
        Task<ServicePageViewModel> ServiceFindAsync(int id);
        Task<List<ServicePageViewModel>> GetServicePages();
        Task<Int16> DeleteServiceAsync(int id);

        //..................................................................................
        // Projects
        Task<Int16> AddNewProjectInfo(VmProject n);
        Task<Int16> UpdateProjectInfo(VmProject n);
        Task<VmProject> GetTheProject(int id);
        Task<List<VmProject>> GetProjects(int? projectID = null);
        Task<Int16> AddNewProjectImage(VmProjectImage n);
        Task<bool> DeleteProjectImage(int id);
        //....................................................................................

        //== Blog
        Task<clsResult> AddBlogCategory(VmBlogCategory vm);
        Task<List<VmNewsCategories>> GetCategories();
        Task<List<VmBlogCategory>> GetBlogCategories();
        Task<List<VmBlog>> GetBlogs(string category = "", bool? IsApprove = null, bool IsDeleted = false, bool? CommentApproved = null);
        Task<VmBlogForEdit> FindBlogAsync(int BlogID);
        Task<Int16> AddNews(VmBlog vm);
        Task<Int16> UpdateNews(VmBlogForEdit vm);
        Task<Int16> DeleteNews(int Id);
        Task<Int16> NewsApprove(int Id);
        List<VmNewsCategories> GetCategoriesList();
        Task<List<VmNewsCategories>> CategoriesStatistic();
        Task<List<VmBlogComment>> GetBlogComments(int BlogID, bool? CommentApproved = null);
        Task<Int16> AddNewsComment(VmBlogComment vm);
        Task<Int16> NewsCommentApprove(int Id);


        //Email Sender Management
        Task<SelectList> GetEmailAddresses();
        Task<string[]> CRMEmail_GetByIdAsync(int id);

    }
}
