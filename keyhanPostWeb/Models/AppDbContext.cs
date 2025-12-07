using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using keyhanPostWeb.Areas.CMS.Models.Entities;
using keyhanPostWeb.Areas.CMS.Models.ModelConfigs;
using keyhanPostWeb.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using keyhanPostWeb.Models.Entities.PersonEntities;
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp;
using keyhanPostWeb.Areas.KP.Models.ModelConfigs.OrderMapp;


namespace keyhanPostWeb.Models
{
    public class AppDbContext : IdentityDbContext<
         ApplicationUser
        , ApplicationRole
        , string
        , IdentityUserClaim<string>
        , ApplicationUserRole
        , IdentityUserLogin<string>
        , IdentityRoleClaim<string>
        , IdentityUserToken<string>
        >
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>()
                   .HasOne(role => role.Role)
                   .WithMany(usr => usr.Users)
                   .HasForeignKey(r => r.RoleId);

            builder.Entity<ApplicationUserRole>()
                    .HasOne(u => u.User)
                    .WithMany(r => r.Roles)
                    .HasForeignKey(u => u.UserId);

            //================= CRN Configs ==============================================
            builder.ApplyConfiguration<ProductCategory>(new ProductCategoryMap());
            builder.ApplyConfiguration<Product>(new ProductMap());
            builder.ApplyConfiguration<PhotoGallery>(new PhotoGalleryMap());
            builder.ApplyConfiguration<SitePageAndSection>(new SitePageAndSectionMap());
            builder.ApplyConfiguration<SectionsContent>(new SectionsContentMap());
            builder.ApplyConfiguration<SectionsListItem>(new SectionListItemMap());
            builder.ApplyConfiguration<ProductCategory>(new ProductCategoryMap());
            builder.ApplyConfiguration<ProductService>(new ProductServiceMap());
            builder.ApplyConfiguration<ProductServiceImage>(new ProductServiceImageMap());
            builder.ApplyConfiguration<Blog>(new BlogMap());
            builder.ApplyConfiguration<BlogComment>(new BlogCommentMap());
            builder.ApplyConfiguration<Project>(new ProjectMap());
            builder.ApplyConfiguration<ProjectImage>(new ProjectImageMap());
            builder.ApplyConfiguration<CRMEmailAddress>(new CRMEmailAddressMap());

            // //================= CRN Configs ==============================================
            builder.ApplyConfiguration<ProductCategory>(new ProductCategoryMap());
            builder.ApplyConfiguration<Product>(new ProductMap());



            // //================= Rep Configs ==============================================
            builder.ApplyConfiguration(new RepApplicantMapp());
            builder.ApplyConfiguration(new RepJobRequestMapp());
            builder.ApplyConfiguration(new RepEntityTypeMapp());
            builder.ApplyConfiguration(new RepAgencyTypeMapp());
            builder.ApplyConfiguration(new RepRequestStatusMapp());
            builder.ApplyConfiguration(new RepExperienceMapp());
            builder.ApplyConfiguration(new RepVehicleAvailabilityMapp());
            builder.ApplyConfiguration(new RepVehicleTypeMapp());
            builder.ApplyConfiguration(new RepPropertyTypeMapp());
            builder.ApplyConfiguration(new RepDocumentTypeMapp());
            builder.ApplyConfiguration(new RepProvinceMapp());
            builder.ApplyConfiguration(new RepCityMapp());
            builder.ApplyConfiguration(new RepIntroductionMethodMap());
            builder.ApplyConfiguration(new RepEducationDegreeMapp());

            // //================= order Configs ==============================================
            builder.ApplyConfiguration(new OrderStatusMapp());
            builder.ApplyConfiguration(new OrderMapp());
            builder.ApplyConfiguration(new InternationalOrderMapp());
            builder.ApplyConfiguration(new WaybillStatusHistoryMapp());
            builder.ApplyConfiguration(new WaybillStatusMapp());
            builder.ApplyConfiguration(new InternationalWaybillMapp());
        }

        //============================================================================
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // ایجاد نقش‌ها
                List<ApplicationRole> roleList = new List<ApplicationRole>();
                roleList.Add(new ApplicationRole { Name = "Admin", Description = "مدیر سیستم" });
                roleList.Add(new ApplicationRole { Name = "User", Description = "کاربر" });
                roleList.Add(new ApplicationRole { Name = "VIPUser", Description = "کاربر ویژه" });
                roleList.Add(new ApplicationRole { Name = "Customer", Description = "مشتری" });
 
                roleList.Add(new ApplicationRole { Name = "ContentManager", Description = "مدیر محتوا" });
                roleList.Add(new ApplicationRole { Name = "Manager", Description = "مدیر ارشد" });

                foreach (var roleName in roleList)
                {
                    if (!await roleManager.RoleExistsAsync(roleName.Name))
                    {
                        var role = new ApplicationRole
                        {
                            Name = roleName.Name,
                            Description = roleName.Description,
                        };
                        await roleManager.CreateAsync(role);
                    }
                }

                // ایجاد کاربر ادمین
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "Ahi.siamak@gmail.com",
                    FName = "گروه نرم افزاری",
                    Family = "گارنت",
                    Mobile = "09161114954",
                    PhoneNumber = "06131010369",
                    IsActive = true,
                    Gender = 1,
                    RegistrDate = DateTime.Now,
                };
                // ایجاد کاربر ادمین
                var KeyhanPostUser = new ApplicationUser
                {
                    UserName = "keyhanPost",
                    Email = "info@keyhanPost.ir",
                    FName = " علی",
                    Family = "پارسی پور",
                    Mobile = "09166113229",
                    PhoneNumber = "09166113229",
                    IsActive = true,
                    Gender = 2,
                    RegistrDate = DateTime.Now,
                };

                if (userManager.Users.All(u => u.UserName != adminUser.UserName))
                {
                    var createUser = await userManager.CreateAsync(adminUser, "Ava@123456");
                    if (createUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
                if (userManager.Users.All(u => u.UserName != KeyhanPostUser.UserName))
                {
                    var createUser = await userManager.CreateAsync(KeyhanPostUser, "KP3229");
                    if (createUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(KeyhanPostUser, "Manager");
                    }
                }

            }
        }

        public DbSet<Person> People { get; set; }
        //============================== CRM ===================
        public virtual DbSet<PhotoGallery> PhotoGallery { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SitePageAndSection> SitePages { get; set; }
        public virtual DbSet<SectionsContent> SectionsContents { get; set; }
        public virtual DbSet<SectionsListItem> SectionsListItems { get; set; }
        public virtual DbSet<ProductServiceCategory> ProductServiceCategories { get; set; }
        public virtual DbSet<ProductService> ProductServices { get; set; }
        public virtual DbSet<ProductServiceImage> ProductServiceImages { get; set; }
        public virtual DbSet<ServicePage> ServicePages { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<CompanyMember> CompanyMembers { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogComment> BlogComments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectImage> ProjectImages { get; set; }
        public virtual DbSet<pakage> Pakeges { get; set; }
        public virtual DbSet<ProductInPakge> ProductInPakges { get; set; }
        public virtual DbSet<VisitorLog> VisitorLogs { get; set; }
        public virtual DbSet<CRMEmailAddress> CRMEmailAddresses { get; set; }




        //============================== KP ===================
        // جداول اصلی
        public DbSet<RepApplicant> RepApplicants { get; set; }
        public DbSet<RepUploadedDocument> RepUploadedDocuments { get; set; }

        // جداول پایه

        public DbSet<RepIntroductionMethod> RepIntroductionMethods { get; set; }
        public DbSet<RepProvince> Provinces { get; set; }
        public DbSet<RepCity> Cities { get; set; }
        public DbSet<RepJobRequest> RepJobRequests { get; set; }
        public DbSet<RepEntityType> RepEntityTypes { get; set; }
        public DbSet<RepAgencyType> RepAgencyTypes { get; set; }
        public DbSet<RepRequestStatus> RepRequestStatuses { get; set; }
        public DbSet<RepExperience> RepExperiences { get; set; }
        public DbSet<RepVehicleAvailability> RepVehicleAvailabilities { get; set; }
        public DbSet<RepVehicleType> RepVehicleTypes { get; set; }
        public DbSet<RepPropertyType> RepPropertyTypes { get; set; }
        public DbSet<RepDocumentType> RepDocumentTypes { get; set; }
        public DbSet<RepEducationDegree> EducationDegrees { get; set; }

        //============================== Order ===================
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<InternationalOrder> InternationalOrders { get; set; }
        public DbSet<InternationalWaybill> InternationalWaybill { get; set; }
        public DbSet<WaybillStatusHistory> WaybillStatusHistory { get; set; }
        public DbSet<WaybillStatus> WaybillStatus { get; set; }
    }
}
