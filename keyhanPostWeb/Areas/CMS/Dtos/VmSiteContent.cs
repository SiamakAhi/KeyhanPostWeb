
using keyhanPostWeb.GeneralViewModels.Identity;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmSiteContent
    {
        public List<VmSectionContent> AllSection { get; set; }
        public VmCompanyInfo CompanyInfo { get; set; }
        public VmSectionListItem SectionItem { get; set; }

        //products
        public List<VmProductAndService> Products { get; set; }
        public VmProductAndService Product { get; set; }

        //services
        public List<ServicePageViewModel> ServicePages { get; set; }
        public ServicePageViewModel ServicePage { get; set; }

        //Projects
        public List<VmProject> Projects { get; set; }

        //Blog
        public List<VmNewsCategories> NewsCategories { get; set; }
        public Vm_BlogPagination Blogs { get; set; }
        public VmBlogForEdit BlogDetails { get; set; }
        public List<VmBlog> LastNews { get; set; }

        public VmBlogComment VmBlogComment { get; set; }
        public List<VmBlogComment> BlogComments { get; set; }

        //
        public SendEmailDto EmailDto { get; set; }

        

    }
}
