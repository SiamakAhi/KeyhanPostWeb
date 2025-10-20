using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using keyhanPostWeb.Areas.CMS.CmsInterfaces;
using keyhanPostWeb.Areas.CMS.Dtos;
using keyhanPostWeb.Areas.CMS.Models.Entities;
using keyhanPostWeb.Classes;
using keyhanPostWeb.Models;

namespace keyhanPostWeb.Areas.CMS.CmsServices
{
    public class ContentManagerService : IContentManager
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ContentManagerService(AppDbContext Context, IWebHostEnvironment Environment)
        {
            _db = Context;
            _env = Environment;
        }

        //افزودن یک محتوا برای سایت
        public async Task<Int16> CreateSection(VmSectionContent vmSection)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;


            if (vmSection.imageFile != null)
            {
                string FileExtension = Path.GetExtension(vmSection.imageFile.FileName);
                NewFileName = string.Concat("imgHome-", vmSection.SectionID, FileExtension);
                SavePath = $"{_env.WebRootPath}/img/ContentImages/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await vmSection.imageFile.CopyToAsync(Stream);
                }
            }

            SectionsContent entiry = new SectionsContent
            {
                FooterText = vmSection.FooterText,
                image = NewFileName,
                SectionID = vmSection.SectionID,
                Subtitle = vmSection.Subtitle,
                Text1 = vmSection.Text1,
                Text2 = vmSection.Text2,
                Title = vmSection.Title,
            };

            _db.SectionsContents.Add(entiry);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        // افزودن آیتم برای نمایش لیست ها در محتوای یک بخش
        public async Task<Int16> CreateSectionItem(VmSectionListItem Item)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;


            if (Item.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(Item.ImageFile.FileName);
                NewFileName = string.Concat("imgContentItem-", Item.ContentID, Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/ContentImages/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await Item.ImageFile.CopyToAsync(Stream);
                }
            }

            SectionsListItem entity = new SectionsListItem
            {

                Image = NewFileName,
                SectionContentID = Item.ContentID,
                Title = Item.Title,
                Subtitle = Item.Subtitle,
                Text = Item.Text,
                Text1 = Item.Text1,
                Text2 = Item.Text2,
                FooterText = Item.FooterText,
                Priority = Item.Priority,
                altImage = Item.altImage,
                link1_Address = Item.link1_Address,
                link2_Address = Item.link2_Address,
                link3_Address = Item.link3_Address,
                link1_Title = Item.link1_Title,
                link2_Title = Item.link2_Title,
                link3_Title = Item.link3_Title,
            };

            _db.SectionsListItems.Add(entity);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        //حذف یک آیتم از دیتابیس
        public async Task<Int16> DeleteSectionItem(int id)
        {
            var item = _db.SectionsListItems.Find(id);
            _db.Remove(item);

            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        // ویرایش اطلاعات محتوای یک بخش
        public async Task<Int16> EditSection(VmSectionContent vmSection)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;


            if (vmSection.imageFile != null)
            {
                string FileExtension = Path.GetExtension(vmSection.imageFile.FileName);
                NewFileName = string.Concat("imgHome-", vmSection.SectionID, FileExtension);
                SavePath = $"{_env.WebRootPath}/img/ContentImages/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await vmSection.imageFile.CopyToAsync(Stream);
                }
            }
            SectionsContent entiry = _db.SectionsContents.Where(n => n.Id == vmSection.Id).SingleOrDefault();


            entiry.FooterText = vmSection.FooterText;
            if (NewFileName != string.Empty)
                entiry.image = NewFileName;
            entiry.SectionID = vmSection.SectionID;
            entiry.Subtitle = vmSection.Subtitle;
            entiry.Text1 = vmSection.Text1;
            entiry.Text2 = vmSection.Text2;
            entiry.Title = vmSection.Title;
            entiry.Id = vmSection.Id;

            _db.Update(entiry);

            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        //ویرایش یک آیتم از لیست
        public async Task<Int16> EditSectionItem(VmSectionListItem Item)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;


            if (Item.ImageFile != null)
            {

                string FileExtension = Path.GetExtension(Item.ImageFile.FileName);
                NewFileName = string.Concat("imgContentItem-", Item.ContentID, Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/ContentImages/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await Item.ImageFile.CopyToAsync(Stream);
                }
            }

            SectionsListItem entity = _db.SectionsListItems.SingleOrDefault(n => n.Id == Item.Id);

            // Set New Data
            entity.FooterText = Item.FooterText;
            if (NewFileName != string.Empty)
                entity.Image = NewFileName;
            entity.SectionContentID = Item.ContentID;
            entity.Subtitle = Item.Subtitle;
            entity.Text = Item.Text;
            entity.Text1 = Item.Text1;
            entity.Text2 = Item.Text2;
            entity.Priority = Item.Priority;
            entity.Title = Item.Title;
            entity.altImage = Item.altImage;
            entity.link1_Address = Item.link1_Address;
            entity.link2_Address = Item.link2_Address;
            entity.link3_Address = Item.link3_Address;
            entity.link1_Title = Item.link1_Title;
            entity.link2_Title = Item.link2_Title;
            entity.link3_Title = Item.link3_Title;

            _db.Update(entity);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        //دریافت لیست آیتم های یک محتوا در سایت
        public async Task<List<VmSectionListItem>> GetSectionItems(int id)
        {
            return await _db.SectionsListItems.Include(i => i.ForSection).Where(n => n.SectionContentID == id)
                 .Select(n => new VmSectionListItem
                 {
                     ContentID = n.SectionContentID,
                     Id = n.Id,
                     FooterText = n.FooterText,
                     Image = n.Image,
                     Priority = n.Priority,
                     Subtitle = n.Subtitle,
                     Text = n.Text,
                     Text1 = n.Text1,
                     Text2 = n.Text2,
                     Title = n.Title,
                     SectionID = n.ForSection.SectionID,
                     altImage = n.altImage,
                     link1_Address = n.link1_Address,
                     link2_Address = n.link2_Address,
                     link3_Address = n.link3_Address,
                     link1_Title = n.link1_Title,
                     link2_Title = n.link2_Title,
                     link3_Title = n.link3_Title,
                 }).OrderBy(n => n.Priority).ToListAsync();
        }
        //دریافت آیتم
        public async Task<VmSectionListItem> FindItemAsync(int Id)
        {
            var n = await _db.SectionsListItems.Include(n => n.ForSection).SingleOrDefaultAsync(n => n.Id == Id);

            return new VmSectionListItem
            {
                ContentID = n.SectionContentID,
                Id = n.Id,
                FooterText = n.FooterText,
                Image = n.Image,
                Priority = n.Priority,
                Subtitle = n.Subtitle,
                Text = n.Text,
                Text1 = n.Text1,
                Text2 = n.Text2,
                Title = n.Title,
                SectionID = n.ForSection.SectionID,
                altImage = n.altImage,
                link1_Address = n.link1_Address,
                link2_Address = n.link2_Address,
                link3_Address = n.link3_Address,
                link1_Title = n.link1_Title,
                link2_Title = n.link2_Title,
                link3_Title = n.link3_Title,
            };
        }

        //دریافت یک محتوا همراه با ایتم های آن
        public async Task<VmSectionContent> GetTheContent(int sectionID)
        {
            VmSectionContent TheContent = await _db.SectionsContents.Include(i => i.PageOrSection).Where(n => n.SectionID == sectionID)
                .Select(n => new VmSectionContent
                {
                    Id = n.Id,
                    FooterText = n.FooterText,
                    image = n.image,
                    SectionID = n.SectionID,
                    Subtitle = n.Subtitle,
                    Text1 = n.Text1,
                    Text2 = n.Text2,
                    Title = n.Title,
                    SectionName = n.PageOrSection.SerctionName,
                }).FirstOrDefaultAsync();

            if (TheContent == null)
                TheContent = new VmSectionContent(); 

            TheContent.listItems = await _db.SectionsListItems
                .Where(n => n.SectionContentID == TheContent.Id)
                            .Select(n => new VmSectionListItem
                {
                    ContentID = n.SectionContentID,
                    Id = n.Id,
                    FooterText = n.FooterText,
                    Image = n.Image,
                    Priority = n.Priority,
                    Subtitle = n.Subtitle,
                    Text = n.Text,
                    Text1 = n.Text1,
                    Text2 = n.Text2,
                    Title = n.Title,
                    altImage = n.altImage,
                    link1_Address = n.link1_Address,
                    link2_Address = n.link2_Address,
                    link3_Address = n.link3_Address,
                    link1_Title = n.link1_Title,
                    link2_Title = n.link2_Title,
                    link3_Title = n.link3_Title,
                    SectionID = TheContent.SectionID,
                }).OrderBy(n => n.Priority).ToListAsync();

            return TheContent;
        }

        //دریافت تمام بخش ها
        public async Task<List<VmSectionContent>> GetAllSection()
        {
            List<VmSectionContent> lst = new List<VmSectionContent>();

            var allSectionID = _db.SitePages.Select(n => new { SectionID = n.Id }).ToList();

            foreach (var i in allSectionID)
            {
                VmSectionContent TheContent = await _db.SectionsContents.Include(i => i.PageOrSection).Where(n => n.SectionID == i.SectionID)
               .Select(n => new VmSectionContent
               {
                   Id = n.Id,
                   FooterText = n.FooterText,
                   image = n.image,
                   SectionID = n.SectionID,
                   Subtitle = n.Subtitle,
                   Text1 = n.Text1,
                   Text2 = n.Text2,
                   Title = n.Title,
                   SectionName = n.PageOrSection.SerctionName,
               }).FirstOrDefaultAsync();

                if (TheContent != null)
                    TheContent.listItems = await GetSectionItems(TheContent.Id);

                lst.Add(TheContent);
            }

            return lst;
        }

        //دریافت بخش ها و صفحات سایت
        public async Task<List<VmSitePages>> GetPagesList()
        {
            return await _db.SitePages.Select(n => new VmSitePages
            {
                Id = n.Id,
                SectionCode = n.SectionCode,
                SerctionName = n.SerctionName,
                SectionUrl = n.SectionUrl
            }).ToListAsync();
        }

        public async Task<string> GetSectionTitle(int SectionID)
        {
            var result = await _db.SectionsContents.FirstOrDefaultAsync(n => n.SectionID == SectionID);

            return result == null ? "موردی یافت نشد" : result.Title;
        }


        //..==========================..
        // Company Information

        //چک می کند اطلاعات شرکت وارد شده است یا خیر
        public async Task<bool> CompanyInfoHasData()
        {
            return Convert.ToBoolean(await _db.CompanyInfo.CountAsync());
        }

        //دریافت اطلاعات شرکت
        public async Task<VmCompanyInfo> GetCompanyInfo()
        {
            var n = await _db.CompanyInfo.SingleOrDefaultAsync() ?? new CompanyInfo(); 

            return new VmCompanyInfo
            {
                Address1 = n.Address1,
                Address1_email = n.Address1_email,
                Address1_fax = n.Address1_fax,
                Address1_Mobile = n.Address1_Mobile,
                Address1_Phone1 = n.Address1_Phone1,
                Address1_Phone2 = n.Address1_Phone2,
                Address2_fax = n.Address2_fax,
                Address2 = n.Address2,
                Address2_email = n.Address2_email,
                Address2_Mobile = n.Address2_Mobile,
                Address2_Phone1 = n.Address2_Phone1,
                Address2_Phone2 = n.Address2_Phone2,
                AddressName1 = n.AddressName1,
                AddressName2 = n.AddressName2,
                FullName = n.FullName,
                MeliNo = n.MeliNo,
                id = n.id,
                SabtNo = n.SabtNo,
                ShortName = n.ShortName,
                Instagram = n.Instagram,
                Facebook = n.Facebook,
                Twitter = n.Twitter,
                LinkedIn = n.LinkedIn,
                YouTube = n.YouTube,
            };
        }

        //ویرایش اطلاعات شرکت
        public async Task<Int16> UpdateCompanyInfo(VmCompanyInfo n)
        {
            CompanyInfo Info = new CompanyInfo();

            if (await CompanyInfoHasData())
                Info = await _db.CompanyInfo.FirstOrDefaultAsync();

            Info.Address2_Phone1 = n.Address2_Phone1;
            Info.ShortName = n.ShortName;
            Info.SabtNo = n.SabtNo;
            Info.Address1 = n.Address1;
            Info.Address1_email = n.Address1_email;
            Info.Address1_fax = n.Address1_fax;
            Info.Address1_Mobile = n.Address1_Mobile;
            Info.Address1_Phone1 = n.Address1_Phone1;
            Info.Address1_Phone2 = n.Address1_Phone2;
            Info.Address2 = n.Address2;
            Info.Address2_email = n.Address2_email;
            Info.Address2_fax = n.Address2_fax;
            Info.Address2_Mobile = n.Address2_Mobile;
            Info.Address2_Phone2 = n.Address2_Phone2;
            Info.AddressName1 = n.AddressName1;
            Info.AddressName2 = n.AddressName2;
            Info.FullName = n.FullName;
            Info.MeliNo = n.MeliNo;
            Info.Facebook = n.Facebook;
            Info.Instagram = n.Instagram;
            Info.LinkedIn = n.LinkedIn;
            Info.Twitter = n.Twitter;
            Info.YouTube = n.YouTube;

            if (await CompanyInfoHasData())
                _db.Update(Info);
            else
                _db.CompanyInfo.Add(Info);

            //result
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        //افزودن اطلاعات شرکت
        public async Task<Int16> AddCompanyInfo(VmCompanyInfo n)
        {
            CompanyInfo Info = new CompanyInfo();

            Info.Address2_Phone1 = n.Address2_Phone1;
            Info.ShortName = n.ShortName;
            Info.SabtNo = n.SabtNo;
            Info.Address1 = n.Address1;
            Info.Address1_email = n.Address1_email;
            Info.Address1_fax = n.Address1_fax;
            Info.Address1_Mobile = n.Address1_Mobile;
            Info.Address1_Phone1 = n.Address1_Phone1;
            Info.Address1_Phone2 = n.Address1_Phone2;
            Info.Address2 = n.Address2;
            Info.Address2_email = n.Address2_email;
            Info.Address2_fax = n.Address2_fax;
            Info.Address2_Mobile = n.Address2_Mobile;
            Info.Address2_Phone2 = n.Address2_Phone2;
            Info.AddressName1 = n.AddressName1;
            Info.AddressName2 = n.AddressName2;
            Info.FullName = n.FullName;
            Info.MeliNo = n.MeliNo;
            Info.Facebook = n.Facebook;
            Info.Instagram = n.Instagram;
            Info.LinkedIn = n.LinkedIn;
            Info.Twitter = n.Twitter;
            Info.YouTube = n.YouTube;

            _db.CompanyInfo.Add(Info);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }


        //محصولات و دسته بندی
        //....................................................
        //لیست دسته بندی های
        public async Task<List<VmProductCategory>> GetProductCategories(bool IsActive = true)
        {
            return await _db.ProductServiceCategories.Include(p => p.ProductServices).Where(n => IsActive == true ? n.IsActive == IsActive : n.Id > 0)
                .Select(n => new VmProductCategory
                {
                    Id = n.Id,
                    CategoryName = n.CategoryName,
                    Description = n.Description,
                    Image = n.Image,
                    IsActive = n.IsActive,
                    IsProduct = n.IsProduct,
                    ProductQty = n.ProductServices.Count()
                }).OrderByDescending(n => n.Id).ToListAsync();
        }
        public async Task<SelectList> SelectList_ProductCategories()
        {
            var cates = await _db.ProductServiceCategories.Select(n => new { id = n.Id, name = n.CategoryName }).OrderBy(n => n.name).ToListAsync();

            return new SelectList(cates, "id", "name");
        }
        public async Task<VmProductCategory> GetTheCategory(int Id)
        {
            var n = await _db.ProductServiceCategories.FindAsync(Id);

            return new VmProductCategory
            {
                Id = n.Id,
                CategoryName = n.CategoryName,
                Description = n.Description,
                Image = n.Image,
                IsActive = n.IsActive,
                IsProduct = n.IsProduct,
            };
        }

        //افزودن دسته ی جدید
        public async Task<Int16> AddProductCategory(VmProductCategory n)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (n.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(n.ImageFile.FileName);
                NewFileName = string.Concat("imgProduct-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/products/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await n.ImageFile.CopyToAsync(Stream);
                }
            }

            ProductServiceCategory cat = new ProductServiceCategory()
            {
                CategoryName = n.CategoryName,
                Description = n.Description,
                Image = NewFileName,
                IsActive = n.IsActive,
                IsProduct = n.IsProduct,
            };

            _db.ProductServiceCategories.Add(cat);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        //ویرایش  اطلاعات دسته
        public async Task<Int16> UpdateProductCategory(VmProductCategory n)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (n.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(n.ImageFile.FileName);
                NewFileName = string.Concat("imgProduct-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/products/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await n.ImageFile.CopyToAsync(Stream);
                }
            }
            ProductServiceCategory cat = await _db.ProductServiceCategories.FindAsync(n.Id);
            cat.Id = n.Id;
            cat.CategoryName = n.CategoryName;
            cat.Description = n.Description;
            if (NewFileName != string.Empty)
                cat.Image = NewFileName;
            cat.IsActive = n.IsActive;
            cat.IsProduct = n.IsProduct;


            _db.Update(cat);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        //تغیر وضعیت از فعال به غیرفعال و برعکس
        public async Task<Int16> UpdateProductCategory(int Id)
        {
            ProductServiceCategory cat = await _db.ProductServiceCategories.FindAsync(Id);
            if (cat.IsActive)
                cat.IsActive = false;
            else
                cat.IsActive = true;


            _db.Update(cat);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        public async Task<Int16> DeleteProduCategory(int Id)
        {
            bool HasData = await _db.ProductServices.AnyAsync(n => n.ProductCategoryID == Id);
            if (HasData)
                return (Int16)SaveResult.HassDataErrorr;

            var cat = await _db.ProductServiceCategories.FindAsync(Id);
            _db.ProductServiceCategories.Remove(cat);

            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        //.........................................................................................

        //===========محصول
        public async Task<List<VmProductAndService>> GetVmProductAndServices(int? CategoryID = null, bool? IsProduct = null)
        {
            List<VmProductAndService> lst = await _db.ProductServices.Include(i => i.ProductCategory).Include(i => i.ProductServiceImages)
                .Where(n =>
                       (CategoryID == null ? n.ProductCategoryID > 0 : n.ProductCategoryID == CategoryID)
                       && (IsProduct == null ? n.Id > 0 : n.ProductCategory.IsProduct == IsProduct))
                .Select(n => new VmProductAndService
                {
                    CategoryID = n.ProductCategoryID,
                    CategoryName = n.ProductCategory.CategoryName,
                    Description = n.Description,
                    MainText = n.MainText,
                    FooterText = n.FooterText,
                    Subtext1 = n.Subtext1,
                    Subtext2 = n.Subtext2,
                    Subtext3 = n.Subtext3,
                    FinalPrice = n.FinalPrice,
                    price = n.price,
                    discount = n.discount,
                    IsAvalable = n.IsAvalable,
                    LongTitle = n.FullName,
                    ShortTitle = n.ShortName,
                    ProductID = n.Id,
                    ShowInHome = n.ShowInHome,
                    SpecialProduct = n.SpecialProduct,
                    AlowShowPrice = n.AlowShowPrice,
                }).OrderBy(n => n.ProductID).ToListAsync();

            foreach (var i in lst)
            {
                i.images = _db.ProductServiceImages.Where(n => n.ProductID == i.ProductID).Select(n => new VmProductAndServiceImages
                {
                    Id = n.Id,
                    Description = n.Description,
                    AllowToShow = n.AllowToShow,
                    CategoryID = i.CategoryID,
                    CategoryName = i.CategoryName,
                    Image = n.Image,
                    IsMainImage = n.IsMainImage,
                    name = n.name,
                    Priority = n.Priority,
                    ProductID = n.ProductID,
                    ProductName = i.ShortTitle,

                }).OrderBy(n => n.Priority).ToList();
            }

            return lst;
        }

        public async Task<SelectList> SelectList_Product(int? CategoryID = null)
        {
            List<VmProductAndService> lst = await _db.ProductServices
                 .Where(n =>
                        (CategoryID == null ? n.ProductCategoryID > 0 : n.ProductCategoryID == CategoryID)
                        )
                 .Select(n => new VmProductAndService
                 {
                     ShortTitle = n.ShortName,
                     ProductID = n.Id,
                 }).OrderBy(n => n.ShortTitle).ToListAsync();

            return new SelectList(lst, "ProductID", "ShortTitle");
        }
        public async Task<VmProductAndService> GetVmProductAndService(int Id)
        {
            var n = await _db.ProductServices.Include(c => c.ProductCategory).SingleOrDefaultAsync(n => n.Id == Id);

            VmProductAndService vm = new VmProductAndService
            {
                CategoryID = n.ProductCategoryID,
                CategoryName = n.ProductCategory.CategoryName,
                Description = n.Description,
                FinalPrice = n.FinalPrice,
                price = n.price,
                discount = n.discount,
                IsAvalable = n.IsAvalable,
                LongTitle = n.FullName,
                ShortTitle = n.ShortName,
                ProductID = n.Id,
                ShowInHome = n.ShowInHome,
                SpecialProduct = n.SpecialProduct,
                AlowShowPrice = n.AlowShowPrice,
                MainText = n.MainText,
                FooterText = n.FooterText,
                Subtext1 = n.Subtext1,
                Subtext2 = n.Subtext2,
                Subtext3 = n.Subtext3,

            };


            vm.images = _db.ProductServiceImages.Where(n => n.ProductID == Id).Select(n => new VmProductAndServiceImages
            {
                Id = n.Id,
                Description = n.Description,
                AllowToShow = n.AllowToShow,
                CategoryID = vm.CategoryID,
                CategoryName = vm.CategoryName,
                Image = n.Image,
                IsMainImage = n.IsMainImage,
                name = n.name,
                Priority = n.Priority,
                ProductID = n.ProductID,
                ProductName = vm.ShortTitle,
            }).OrderBy(n => n.Priority).ToList();


            return vm;
        }
        public async Task<Int16> AddNewProductInfo(VmProductAndService n)
        {
            ProductService ent = new ProductService();
            ent.Description = n.Description;
            ent.discount = n.discount == null ? 0 : n.discount.Value;
            ent.FinalPrice = n.FinalPrice == null ? 0 : n.FinalPrice.Value;
            ent.FullName = n.LongTitle;
            ent.IsAvalable = n.IsAvalable;
            ent.price = n.price == null ? 0 : n.price.Value;
            ent.ProductCategoryID = n.CategoryID;
            ent.ShortName = n.ShortTitle;
            ent.ShowInHome = n.ShowInHome;
            ent.SpecialProduct = n.SpecialProduct;
            ent.AlowShowPrice = n.AlowShowPrice;
            ent.MainText = n.MainText;
            ent.FooterText = n.FooterText;
            ent.Subtext1 = n.Subtext1;
            ent.Subtext2 = n.Subtext2;
            ent.Subtext3 = n.Subtext3;

            _db.ProductServices.Add(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> UpdateProductInfo(VmProductAndService n)
        {
            ProductService ent = await _db.ProductServices.FindAsync(n.ProductID);
            ent.Description = n.Description;
            ent.discount = n.discount == null ? 0 : n.discount.Value;
            ent.FinalPrice = n.FinalPrice == null ? 0 : n.FinalPrice.Value;
            ent.FullName = n.LongTitle;
            ent.IsAvalable = n.IsAvalable;
            ent.price = n.price == null ? 0 : n.price.Value; ;
            ent.ProductCategoryID = n.CategoryID;
            ent.ShortName = n.ShortTitle;
            ent.ShowInHome = n.ShowInHome;
            ent.SpecialProduct = n.SpecialProduct;
            ent.AlowShowPrice = n.AlowShowPrice;
            ent.MainText = n.MainText;
            ent.FooterText = n.FooterText;
            ent.Subtext1 = n.Subtext1;
            ent.Subtext2 = n.Subtext2;
            ent.Subtext3 = n.Subtext3;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> ChangeProductViewInHome(int Id)
        {
            ProductService ent = await _db.ProductServices.FindAsync(Id);

            if (ent.ShowInHome == true)
                ent.ShowInHome = false;
            else
                ent.ShowInHome = true;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> ChangeProductAvalable(int Id)
        {
            ProductService ent = await _db.ProductServices.FindAsync(Id);

            if (ent.IsAvalable == true)
                ent.IsAvalable = false;
            else
                ent.IsAvalable = true;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> ChangeAlowShowPrice(int Id)
        {
            ProductService ent = await _db.ProductServices.FindAsync(Id);

            if (ent.AlowShowPrice == true)
                ent.AlowShowPrice = false;
            else
                ent.AlowShowPrice = true;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> DeleteProduct(int Id)
        {
            ProductService ent = await _db.ProductServices.FindAsync(Id);

            _db.RemoveRange(_db.ProductServiceImages.Where(n => n.ProductID == ent.Id));
            _db.Remove(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> AddNewProductImage(VmProductAndServiceImages n)
        {
            int imgCount = await _db.ProductServiceImages.Where(b => b.ProductID == n.ProductID).CountAsync();
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (n.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(n.ImageFile.FileName);
                NewFileName = string.Concat("imgProduct-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/products/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await n.ImageFile.CopyToAsync(Stream);
                }
            }

            ProductServiceImage ent = new ProductServiceImage();
            ent.AllowToShow = n.AllowToShow;
            ent.Description = n.Description;
            ent.Image = NewFileName;
            ent.IsMainImage = imgCount == 0 ? true : false;
            ent.name = n.name;
            ent.Priority = n.Priority;
            ent.ProductID = n.ProductID;


            _db.ProductServiceImages.Add(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> UpdateProductImage(VmProductAndServiceImages n)
        {
            ProductServiceImage ent = await _db.ProductServiceImages.FindAsync(n.Id);
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (n.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(n.ImageFile.FileName);
                if (n.Image == null || n.Image == "")
                    NewFileName = string.Concat("imgProduct-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/products/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await n.ImageFile.CopyToAsync(Stream);
                }
            }


            ent.AllowToShow = n.AllowToShow;
            ent.Description = n.Description;
            ent.Image = NewFileName;
            ent.IsMainImage = n.IsMainImage;
            ent.name = n.name;
            ent.Priority = n.Priority;
            ent.ProductID = n.ProductID;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> DeleteProductImage(int Id)
        {
            ProductServiceImage ent = await _db.ProductServiceImages.FindAsync(Id);

            _db.Remove(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> SetAsMainProductImage(int Id)
        {
            ProductServiceImage ent = await _db.ProductServiceImages.FindAsync(Id);
            var allimages = await _db.ProductServiceImages.Where(n => n.ProductID == ent.ProductID).ToListAsync();
            allimages.ForEach(l => l.IsMainImage = false);
            _db.UpdateRange(allimages);

            ent.IsMainImage = true;
            _db.Update(ent);

            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<VmProductAndServiceImages> GetProductImage(int Id)
        {
            ProductServiceImage n = await _db.ProductServiceImages.Include(n => n.ProductService).ThenInclude(n => n.ProductCategory).SingleOrDefaultAsync(n => n.Id == Id);

            return new VmProductAndServiceImages
            {
                Id = n.Id,
                Description = n.Description,
                AllowToShow = n.AllowToShow,
                CategoryID = n.ProductService.ProductCategoryID,
                CategoryName = n.ProductService.ProductCategory.CategoryName,
                Image = n.Image,
                IsMainImage = n.IsMainImage,
                name = n.name,
                Priority = n.Priority,
                ProductID = n.ProductID,
                ProductName = n.ProductService.ShortName,
            };
        }
        //.............................................................................................


        // ========== Service Page Section

        public async Task<Int16> CreateNewServiceAsync(ServicePageViewModel vm)
        {

            ServicePage s = new ServicePage();
            s.Priority = vm.Priority;
            s.CategoryName = vm.CategoryName;
            s.Title = vm.Title;
            s.ShortDescription = vm.ShortDescription;
            s.Text1 = vm.Text1;
            s.Text2 = vm.Text2;
            s.Text3 = vm.Text3;
            s.Text4 = vm.Text4;
            s.Text5 = vm.Text5;
            s.Text6 = vm.Text6;
            //
            s.Link1 = vm.Link1;
            s.Link2 = vm.Link2;
            s.Link3 = vm.Link3;
            s.Link4 = vm.Link4;
            s.Link5 = vm.Link5;
            s.Link1Title = vm.Link1Title;
            s.Link2Title = vm.Link2Title;
            s.Link3Title = vm.Link3Title;
            s.Link4Title = vm.Link4Title;
            s.Link5Title = vm.Link5Title;
            //
            s.Meta_author = vm.Meta_author;
            s.Meta_description = vm.Meta_description;
            s.Meta_title = vm.Meta_title;
            s.Meta_keywords = vm.Meta_keywords;
            s.Meta_copyright = vm.Meta_copyright;
            s.Meta_name = vm.Meta_name;
            s.Meta_license = vm.Meta_license;
            //Images
            //Main Image
            string SavePath1 = string.Empty;
            string NewFileName1 = string.Empty;

            if (vm.ImageFile1 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile1.FileName);
                NewFileName1 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath1 = $"{_env.WebRootPath}/img/ContentImages/{NewFileName1}";

                using (var Stream = new FileStream(SavePath1, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile1.CopyToAsync(Stream);
                }
                s.Image1Path = NewFileName1;
                s.Image1Description = vm.Image1Description;
            }
            //Image 2
            string SavePath2 = string.Empty;
            string NewFileName2 = string.Empty;

            if (vm.ImageFile2 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile2.FileName);
                NewFileName2 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath2 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName2);

                using (var Stream = new FileStream(SavePath2, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile2.CopyToAsync(Stream);
                }
                s.Image2Path = NewFileName2;
                s.Image2Description = vm.Image2Description;
            }
            //Image 3
            string SavePath3 = string.Empty;
            string NewFileName3 = string.Empty;

            if (vm.ImageFile3 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile3.FileName);
                NewFileName3 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath3 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName3);

                using (var Stream = new FileStream(SavePath3, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile3.CopyToAsync(Stream);
                }

                s.Image3Path = NewFileName3;
                s.Image3Description = vm.Image3Description;
            }
            //Image 4
            string SavePath4 = string.Empty;
            string NewFileName4 = string.Empty;

            if (vm.ImageFile4 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile4.FileName);
                NewFileName4 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath4 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName4);

                using (var Stream = new FileStream(SavePath4, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile4.CopyToAsync(Stream);
                }
                s.Image4Path = NewFileName4;
                s.Image4Description = vm.Image4Description;
            }
            //Image 5
            string SavePath5 = string.Empty;
            string NewFileName5 = string.Empty;

            if (vm.ImageFile5 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile5.FileName);
                NewFileName5 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath5 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName5);

                using (var Stream = new FileStream(SavePath5, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile5.CopyToAsync(Stream);
                }
                s.Image5Path = NewFileName5;
                s.Image5Description = vm.Image5Description;
            }
            //Image 6
            string SavePath6 = string.Empty;
            string NewFileName6 = string.Empty;

            if (vm.ImageFile6 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile6.FileName);
                NewFileName6 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath6 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName6);

                using (var Stream = new FileStream(SavePath6, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile6.CopyToAsync(Stream);
                }
                s.Image6Path = NewFileName6;
                s.Image6Description = vm.Image6Description;
            }

            _db.ServicePages.Add(s);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        public async Task<Int16> UpdateServiceInfoAsync(ServicePageViewModel vm)
        {

            ServicePage s = await _db.ServicePages.FindAsync(vm.Id);
            s.Priority = vm.Priority;
            s.CategoryName = vm.CategoryName;
            s.Title = vm.Title;
            s.ShortDescription = vm.ShortDescription;
            s.Text1 = vm.Text1;
            s.Text2 = vm.Text2;
            s.Text3 = vm.Text3;
            s.Text4 = vm.Text4;
            s.Text5 = vm.Text5;
            s.Text6 = vm.Text6;
            //
            s.Link1 = vm.Link1;
            s.Link2 = vm.Link2;
            s.Link3 = vm.Link3;
            s.Link4 = vm.Link4;
            s.Link5 = vm.Link5;
            s.Link1Title = vm.Link1Title;
            s.Link2Title = vm.Link2Title;
            s.Link3Title = vm.Link3Title;
            s.Link4Title = vm.Link4Title;
            s.Link5Title = vm.Link5Title;
            //
            s.Meta_author = vm.Meta_author;
            s.Meta_description = vm.Meta_description;
            s.Meta_title = vm.Meta_title;
            s.Meta_keywords = vm.Meta_keywords;
            s.Meta_copyright = vm.Meta_copyright;
            s.Meta_name = vm.Meta_name;
            s.Meta_license = vm.Meta_license;
            //Images
            //Main Image
            string SavePath1 = string.Empty;
            string NewFileName1 = string.Empty;

            if (vm.ImageFile1 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile1.FileName);
                NewFileName1 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath1 = $"{_env.WebRootPath}/img/ContentImages/{NewFileName1}";

                using (var Stream = new FileStream(SavePath1, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile1.CopyToAsync(Stream);
                }
                s.Image1Path = NewFileName1;
                s.Image1Description = vm.Image1Description;
            }
            //Image 2
            string SavePath2 = string.Empty;
            string NewFileName2 = string.Empty;

            if (vm.ImageFile2 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile2.FileName);
                NewFileName2 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath2 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName2);

                using (var Stream = new FileStream(SavePath2, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile2.CopyToAsync(Stream);
                }
                s.Image2Path = NewFileName2;
                s.Image2Description = vm.Image2Description;
            }
            //Image 3
            string SavePath3 = string.Empty;
            string NewFileName3 = string.Empty;

            if (vm.ImageFile3 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile3.FileName);
                NewFileName3 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath3 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName3);

                using (var Stream = new FileStream(SavePath3, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile3.CopyToAsync(Stream);
                }

                s.Image3Path = NewFileName3;
                s.Image3Description = vm.Image3Description;
            }
            //Image 4
            string SavePath4 = string.Empty;
            string NewFileName4 = string.Empty;

            if (vm.ImageFile4 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile4.FileName);
                NewFileName4 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath4 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName4);

                using (var Stream = new FileStream(SavePath4, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile4.CopyToAsync(Stream);
                }
                s.Image4Path = NewFileName4;
                s.Image4Description = vm.Image4Description;
            }
            //Image 5
            string SavePath5 = string.Empty;
            string NewFileName5 = string.Empty;

            if (vm.ImageFile5 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile5.FileName);
                NewFileName5 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath5 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName5);

                using (var Stream = new FileStream(SavePath5, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile5.CopyToAsync(Stream);
                }
                s.Image5Path = NewFileName5;
                s.Image5Description = vm.Image5Description;
            }
            //Image 6
            string SavePath6 = string.Empty;
            string NewFileName6 = string.Empty;

            if (vm.ImageFile6 != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile6.FileName);
                NewFileName6 = string.Concat("ContentImages-", Guid.NewGuid().ToString(), FileExtension);
                SavePath6 = Path.Combine(_env.WebRootPath, "img", "ContentImages", NewFileName6);

                using (var Stream = new FileStream(SavePath6, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile6.CopyToAsync(Stream);
                }
                s.Image6Path = NewFileName6;
                s.Image6Description = vm.Image6Description;
            }

            _db.ServicePages.Update(s);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }

        public async Task<ServicePageViewModel> ServiceFindAsync(int id)
        {
            var vm = await _db.ServicePages.Where(n => n.Id == id).SingleOrDefaultAsync();
            ServicePageViewModel s = new ServicePageViewModel();
            s.Id = vm.Id;
            s.Priority = vm.Priority;
            s.CategoryName = vm.CategoryName;
            s.Title = vm.Title;
            s.ShortDescription = vm.ShortDescription;
            s.Text1 = vm.Text1;
            s.Text2 = vm.Text2;
            s.Text3 = vm.Text3;
            s.Text4 = vm.Text4;
            s.Text5 = vm.Text5;
            s.Text6 = vm.Text6;
            //
            s.Link1 = vm.Link1;
            s.Link2 = vm.Link2;
            s.Link3 = vm.Link3;
            s.Link4 = vm.Link4;
            s.Link5 = vm.Link5;
            s.Link1Title = vm.Link1Title;
            s.Link2Title = vm.Link2Title;
            s.Link3Title = vm.Link3Title;
            s.Link4Title = vm.Link4Title;
            s.Link5Title = vm.Link5Title;
            //
            s.Image1Path = vm.Image1Path;
            s.Image1Description = vm.Image1Description;
            s.Image2Path = vm.Image2Path;
            s.Image2Description = vm.Image2Description;
            s.Image3Path = vm.Image3Path;
            s.Image3Description = vm.Image3Description;
            s.Image4Path = vm.Image4Path;
            s.Image4Description = vm.Image4Description;
            s.Image5Path = vm.Image5Path;
            s.Image5Description = vm.Image5Description;
            s.Image6Path = vm.Image6Path;
            s.Image6Description = vm.Image6Description;

            //
            s.Meta_author = vm.Meta_author;
            s.Meta_description = vm.Meta_description;
            s.Meta_title = vm.Meta_title;
            s.Meta_keywords = vm.Meta_keywords;
            s.Meta_copyright = vm.Meta_copyright;
            s.Meta_name = vm.Meta_name;
            s.Meta_license = vm.Meta_license;


            return s;
        }
        public async Task<List<ServicePageViewModel>> GetServicePages()
        {
            var lst = await _db.ServicePages.Select(n => new ServicePageViewModel
            {
                Id = n.Id,
                Priority = n.Priority,
                CategoryName = n.CategoryName,
                Title = n.Title,
                ShortDescription = n.ShortDescription,
                Text1 = n.Text1,
                Text2 = n.Text2,
                Text3 = n.Text3,
                Text4 = n.Text4,
                Text5 = n.Text5,
                Text6 = n.Text6,
                Link1 = n.Link1,
                Link2 = n.Link2,
                Link3 = n.Link3,
                Link4 = n.Link4,
                Link5 = n.Link5,
                Link1Title = n.Link1Title,
                Link2Title = n.Link2Title,
                Link3Title = n.Link3Title,
                Link4Title = n.Link4Title,
                Link5Title = n.Link5Title,
                Image1Path = n.Image1Path,
                Image1Description = n.Image1Description,
                Image2Path = n.Image2Path,
                Image2Description = n.Image2Description,
                Image3Path = n.Image3Path,
                Image3Description = n.Image3Description,
                Image4Path = n.Image4Path,
                Image4Description = n.Image4Description,
                Image5Path = n.Image5Path,
                Image5Description = n.Image5Description,
                Image6Path = n.Image6Path,
                Image6Description = n.Image6Description,
                Meta_author = n.Meta_author,
                Meta_description = n.Meta_description,
                Meta_title = n.Meta_title,
                Meta_keywords = n.Meta_keywords,
                Meta_copyright = n.Meta_copyright,
                Meta_name = n.Meta_name,
                Meta_license = n.Meta_license,
            }).ToListAsync();

            return lst;
        }
        public async Task<Int16> DeleteServiceAsync(int id)
        {
            var s = await _db.ServicePages.FindAsync(id);
            _db.ServicePages.Remove(s);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }

        //..............................................................................................
        //=========== Projects Section
        public async Task<Int16> AddNewProjectInfo(VmProject n)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (n.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(n.ImageFile.FileName);
                NewFileName = string.Concat("imgProjectInfo-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/ContentImages/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await n.ImageFile.CopyToAsync(Stream);
                }
            }

            Project p = new Project();
            p.Customer = n.Customer;
            p.Description = n.Description;
            p.Description2 = n.Description2;
            p.Description3 = n.Description3;
            p.Description4 = n.Description4;
            p.FooterText = n.FooterText;
            p.Duration = n.Duration;
            p.EndDate = n.EndDate;
            //p.ProductID = n.ProductID == 0 ? p.ProductID=null : n.ProductID;
            p.StartDate = n.StartDate;
            p.Title = n.Title;
            p.Image = NewFileName;
            p.CategoryId = n.ProductID;

            _db.Projects.Add(p);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> AddNewProjectImage(VmProjectImage n)
        {
            int imgCount = await _db.ProjectImages.Where(b => b.projectId == n.ProjectId).CountAsync();
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (n.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(n.ImageFile.FileName);
                NewFileName = string.Concat("imgProject-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/ContentImages/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await n.ImageFile.CopyToAsync(Stream);
                }
            }

            ProjectImage ent = new ProjectImage();
            ent.AllowToShow = n.AllowToShow;
            ent.Description = n.Description;
            ent.Image = NewFileName;
            ent.IsMainImage = imgCount == 0 ? true : false;
            ent.name = n.name;
            ent.Priority = n.Priority;
            ent.projectId = n.ProjectId;


            _db.ProjectImages.Add(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        public async Task<bool> DeleteProjectImage(int id)
        {
            var img = await _db.ProjectImages.SingleOrDefaultAsync(n => n.Id == id);
            _db.ProjectImages.Remove(img);

            return Convert.ToBoolean(await _db.SaveChangesAsync());
        }

        public async Task<Int16> UpdateProjectInfo(VmProject n)
        {
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (n.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(n.ImageFile.FileName);
                NewFileName = string.Concat("imgProjectInfo-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/ContentImages/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create))
                {
                    await n.ImageFile.CopyToAsync(Stream);
                }
            }
            Project p = await _db.Projects.SingleOrDefaultAsync(x => x.projectID == n.projectID);
            p.Customer = n.Customer;
            p.Description = n.Description;
            p.Description2 = n.Description2;
            p.Description3 = n.Description3;
            p.Description4 = n.Description4;
            p.FooterText = n.FooterText;
            p.Duration = n.Duration;
            p.EndDate = n.EndDate;
            p.StartDate = n.StartDate;
            p.Title = n.Title;
            p.CategoryId = n.ProductID;
            if (NewFileName != string.Empty)
                p.Image = NewFileName;

            _db.Projects.Update(p);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<VmProject> GetTheProject(int id)
        {
            var p = await _db.Projects.Include(n => n.Images).SingleOrDefaultAsync(n => n.projectID == id);

            VmProject vm = new VmProject
            {
                Customer = p.Customer,
                projectID = p.projectID,
                Description = p.Description,
                Description2 = p.Description2,
                Description3 = p.Description3,
                Description4 = p.Description4,
                FooterText = p.FooterText,
                Duration = p.Duration,
                EndDate = p.EndDate,
                ProductID = p.CategoryId,
                //ProductName = p.ProductOrService!=null ? p.ProductOrService.FullName :"-",
                StartDate = p.StartDate,
                Title = p.Title,
                Image = p.Image,
                Galleries = p.Images
            };

            return vm;
        }
        public async Task<List<VmProject>> GetProjects(int? projectID = null)
        {
            List<VmProject> Projects = await _db.Projects.Include(n => n.Images).Where(n =>
            projectID == null ? n.CategoryId > 0 : n.CategoryId == projectID)
                .Select(p => new VmProject
                {
                    Customer = p.Customer,
                    projectID = p.projectID,
                    Description = p.Description,
                    Description2 = p.Description2,
                    Description3 = p.Description3,
                    Description4 = p.Description4,
                    FooterText = p.FooterText,
                    Duration = p.Duration,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    Title = p.Title,
                    Image = p.Image,
                    Galleries = p.Images,
                    ProductID = p.CategoryId,


                }).ToListAsync();

            return Projects;
        }
        //...............................................................................................

        //Begin Blog
        //========================= خبرنامه

        public async Task<clsResult> AddBlogCategory(VmBlogCategory vm)
        {
            clsResult result = new clsResult();
            result.Success = false;

            //Main Image
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (vm.imageFile != null)
            {
                string FileExtension = Path.GetExtension(vm.imageFile.FileName);
                NewFileName = string.Concat("imgBlogCategory-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/blog/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create, FileAccess.Write))
                {
                    await vm.imageFile.CopyToAsync(Stream);
                }
            }

            BlogCategory cat = new BlogCategory
            {
                AltImage = vm.AltImage,
                Description = vm.Description,
                image = NewFileName,
                Name = vm.Name,
            };

            _db.BlogCategories.Add(cat);
            try
            {
                await _db.SaveChangesAsync();
                result.Success = true;
                result.Message = "دسته جدید با موفقیت ایجاد شد";
            }
            catch (Exception)
            {
                result.Message = "خطابی در ثبت اطلاعات رخ داده است";
            }
            return result;

        }

        public async Task<List<VmBlogCategory>> GetBlogCategories()
        {
            List<VmBlogCategory> lst = await _db.BlogCategories.Select(n => new VmBlogCategory
            {
                AltImage = n.AltImage,
                Description = n.Description,
                image = n.image,
                Name = n.Name,

            }).ToListAsync();

            return lst;
        }
        public async Task<List<VmNewsCategories>> GetCategories()
        {
            List<VmNewsCategories> lst = await _db.BlogCategories.Select(n => new VmNewsCategories
            {
                AltImage = n.AltImage,
                Description = n.Description,
                image = n.image,
                name = n.Name,
                PostQty = 0
            }).ToListAsync();

            return lst;
        }
        public List<VmNewsCategories> GetCategoriesList()
        {
            var cats = _db.BlogCategories.Select(n => new VmNewsCategories
            {
                name = n.Name,
                PostQty = 0
            }).ToList();
            return cats;
        }
        public async Task<List<VmNewsCategories>> CategoriesStatistic()
        {
            List<VmNewsCategories> lstCat = GetCategoriesList();

            foreach (var item in lstCat)
            {
                item.PostQty = await _db.Blogs.Where(n => n.IsDeleted == false && n.Approve == true && n.Category == item.name).CountAsync();
            }

            return lstCat.OrderByDescending(n => n.PostQty).ToList();

        }
        public async Task<List<VmBlog>> GetBlogs(string category, bool? IsApprove = null, bool IsDeleted = false, bool? CommentApproved = null)
        {
            List<VmBlog> blogs = await _db.Blogs.Where(n =>
                                           (category == string.Empty ? n.Id > 0 : n.Category == category)
                                          && (IsApprove == null ? n.Id > 0 : n.Approve == IsApprove)
                                          && (n.IsDeleted == IsDeleted)).Select(n => new VmBlog
                                          {
                                              Id = n.Id,
                                              Category = n.Category,
                                              Title = n.Title,
                                              Approve = n.Approve,
                                              FooterText = n.FooterText,
                                              HeaderText = n.HeaderText,
                                              Image = n.Image,
                                              IsDeleted = n.IsDeleted,
                                              MainText = n.MainText,
                                              PostDate = n.PostDate,
                                              Sender = n.Sender,
                                              Image1 = n.Image1,
                                              Image2 = n.Image2,
                                              Text2 = n.Text2,
                                              Text3 = n.Text3,
                                              CommentQty = n.BlogComments.Where(c => c.IsDeleted == false && c.Approve == true).Count(),
                                              Comments = n.BlogComments
                                              .Where(c => c.IsDeleted == false && (CommentApproved == null ? c.ComID > 0 : c.Approve == CommentApproved))
                                              .Select(c => new VmBlogComment
                                              {
                                                  Approve = c.Approve,
                                                  CommentText = c.CommentText,
                                                  BlogID = c.BlogID,
                                                  BlogTitle = n.Title,
                                                  ComDate = c.ComDate,
                                                  ComEmail = c.ComEmail,
                                                  ComID = c.ComID,
                                                  ComSender = c.ComSender,
                                                  Mobile = c.Mobile,
                                                  IsDeleted = c.IsDeleted
                                              }).OrderByDescending(c => c.ComDate).ToList(),
                                          }).OrderByDescending(n => n.PostDate).ToListAsync();
            return blogs;
        }
        public async Task<VmBlogForEdit> FindBlogAsync(int BlogID)
        {
            var n = await _db.Blogs.Include(i => i.BlogComments).SingleOrDefaultAsync(c => c.Id == BlogID);

            VmBlogForEdit blog = new VmBlogForEdit
            {
                Id = n.Id,
                Category = n.Category,
                Title = n.Title,
                Approve = n.Approve,
                FooterText = n.FooterText,
                HeaderText = n.HeaderText,
                Image = n.Image,
                IsDeleted = n.IsDeleted,
                MainText = n.MainText,
                PostDate = n.PostDate,
                Sender = n.Sender,
                Image1 = n.Image1,
                Image2 = n.Image2,
                Text2 = n.Text2,
                Text3 = n.Text3,
                CommentQty = n.BlogComments.Where(c => c.IsDeleted == false && c.Approve == true).Count(),
                Comments = n.BlogComments.Where(c => c.IsDeleted == false && c.Approve == true)
                                            .Select(c => new VmBlogComment
                                            {
                                                CommentText = c.CommentText,
                                                Approve = c.Approve,
                                                BlogID = c.BlogID,
                                                BlogTitle = n.Title,
                                                ComDate = c.ComDate,
                                                ComEmail = c.ComEmail,
                                                ComID = c.ComID,
                                                ComSender = c.ComSender,
                                                Mobile = c.Mobile,
                                                IsDeleted = c.IsDeleted
                                            }).OrderByDescending(c => c.ComDate).ToList(),
            };

            return blog;
        }
        public async Task<Int16> AddNews(VmBlog vm)
        {
            //Main Image
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (vm.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile.FileName);
                NewFileName = string.Concat("imgBlog-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/blog/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile.CopyToAsync(Stream);
                }
            }
            //2end Image
            string SavePath1 = string.Empty;
            string NewFileName1 = string.Empty;

            if (vm.Image1File != null)
            {
                string FileExtension = Path.GetExtension(vm.Image1File.FileName);
                NewFileName1 = string.Concat("imgBlog-", Guid.NewGuid().ToString(), FileExtension);
                SavePath1 = $"{_env.WebRootPath}/img/blog/{NewFileName1}";

                using (var Stream1 = new FileStream(SavePath1, FileMode.Create, FileAccess.Write))
                {
                    await vm.Image1File.CopyToAsync(Stream1);
                }
            }
            //3end Image
            string SavePath2 = string.Empty;
            string NewFileName2 = string.Empty;

            if (vm.Image2File != null)
            {
                string FileExtension = Path.GetExtension(vm.Image2File.FileName);
                NewFileName2 = string.Concat("imgBlog-", Guid.NewGuid().ToString(), FileExtension);
                SavePath2 = $"{_env.WebRootPath}/img/blog/{NewFileName2}";

                using (var Stream2 = new FileStream(SavePath2, FileMode.Create, FileAccess.Write))
                {
                    await vm.Image2File.CopyToAsync(Stream2);
                }
            }

            Blog n = new Blog();
            n.Approve = vm.Approve;
            n.Title = vm.Title;
            n.Category = vm.Category;
            n.FooterText = vm.FooterText;
            n.HeaderText = vm.HeaderText;
            n.MainText = vm.MainText;
            n.PostDate = DateTime.Now;
            n.Sender = vm.Sender;
            n.Image = NewFileName;
            n.Image1 = NewFileName1;
            n.Image2 = NewFileName2;
            n.Text2 = vm.Text2;
            n.Text3 = vm.Text3;
            n.IsDeleted = false;



            _db.Blogs.Add(n);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        public async Task<Int16> UpdateNews(VmBlogForEdit vm)
        {
            Blog n = await _db.Blogs.SingleOrDefaultAsync(b => b.Id == vm.Id);

            //Main Image
            string SavePath = string.Empty;
            string NewFileName = string.Empty;

            if (vm.ImageFile != null)
            {
                string FileExtension = Path.GetExtension(vm.ImageFile.FileName);
                NewFileName = string.Concat("imgBlog-", Guid.NewGuid().ToString(), FileExtension);
                SavePath = $"{_env.WebRootPath}/img/blog/{NewFileName}";

                using (var Stream = new FileStream(SavePath, FileMode.Create, FileAccess.Write))
                {
                    await vm.ImageFile.CopyToAsync(Stream);
                }
            }
            //2end Image
            string SavePath1 = string.Empty;
            string NewFileName1 = string.Empty;

            if (vm.Image1File != null)
            {
                string FileExtension = Path.GetExtension(vm.Image1File.FileName);
                NewFileName1 = string.Concat("imgBlog-", Guid.NewGuid().ToString(), FileExtension);
                SavePath1 = $"{_env.WebRootPath}/img/blog/{NewFileName1}";

                using (var Stream1 = new FileStream(SavePath1, FileMode.Create, FileAccess.Write))
                {
                    await vm.Image1File.CopyToAsync(Stream1);
                }
            }
            //3end Image
            string SavePath2 = string.Empty;
            string NewFileName2 = string.Empty;

            if (vm.Image2File != null)
            {
                string FileExtension = Path.GetExtension(vm.Image2File.FileName);
                NewFileName2 = string.Concat("imgBlog-", Guid.NewGuid().ToString(), FileExtension);
                SavePath2 = $"{_env.WebRootPath}/img/blog/{NewFileName2}";

                using (var Stream2 = new FileStream(SavePath2, FileMode.Create, FileAccess.Write))
                {
                    await vm.Image2File.CopyToAsync(Stream2);
                }
            }

            n.Approve = vm.Approve;
            n.Title = vm.Title;
            n.Category = vm.Category;
            n.FooterText = vm.FooterText;
            n.HeaderText = vm.HeaderText;
            n.MainText = vm.MainText;
            n.Text2 = vm.Text2;
            n.Text3 = vm.Text3;
            //n.PostDate = DateTime.Now;
            n.Sender = vm.Sender;
            if (NewFileName != string.Empty)
                n.Image = NewFileName;
            if (NewFileName1 != string.Empty)
                n.Image1 = NewFileName1;
            if (NewFileName2 != string.Empty)
                n.Image2 = NewFileName2;

            n.IsDeleted = false;


            _db.Update(n);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        public async Task<Int16> DeleteNews(int Id)
        {
            Blog ent = await _db.Blogs.FindAsync(Id);
            ent.IsDeleted = true;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.DeleteSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> DeleteAdditionalNewsimage(int Id, int imageNumber)
        {
            Blog ent = await _db.Blogs.FindAsync(Id);
            if (imageNumber == 1)
                ent.Image1 = null;
            else if (imageNumber == 2)
                ent.Image2 = null;
            else
                return 0;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.DeleteSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }
        public async Task<Int16> NewsApprove(int Id)
        {
            Blog ent = await _db.Blogs.FindAsync(Id);
            if (ent.Approve == false)
                ent.Approve = true;
            else
                ent.Approve = false;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.ApproveChange;
            else
                return (Int16)SaveResult.InternalErrorr;
        }


        //..............................................................
        public async Task<List<VmBlogComment>> GetBlogComments(int BlogID, bool? CommentApproved = null)
        {
            return await _db.BlogComments.Include(n => n.Blog)
                           .Where(c =>
                           (c.BlogID == BlogID)
                           && (c.IsDeleted == false)
                           && (CommentApproved == null ? c.ComID > 0 : c.Approve == CommentApproved))
                           .Select(c => new VmBlogComment
                           {
                               CommentText = c.CommentText,
                               Approve = c.Approve,
                               BlogID = c.BlogID,
                               BlogTitle = c.Blog.Title,
                               ComDate = c.ComDate,
                               ComEmail = c.ComEmail,
                               ComID = c.ComID,
                               ComSender = c.ComSender,
                               Mobile = c.Mobile,
                               IsDeleted = c.IsDeleted
                           }).OrderByDescending(c => c.ComDate).ToListAsync();

        }
        public async Task<Int16> AddNewsComment(VmBlogComment vm)
        {

            BlogComment n = new BlogComment();
            n.CommentText = vm.CommentText;
            n.Approve = vm.Approve;
            n.IsDeleted = false;
            n.BlogID = vm.BlogID;
            n.ComDate = DateTime.Now;
            n.ComEmail = vm.ComEmail;
            n.ComSender = vm.ComSender;
            n.Mobile = vm.Mobile;

            _db.BlogComments.Add(n);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;

        }
        public async Task<Int16> NewsCommentApprove(int Id)
        {
            BlogComment ent = await _db.BlogComments.FindAsync(Id);
            if (ent.Approve == false)
                ent.Approve = true;
            else
                ent.Approve = false;

            _db.Update(ent);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.ApproveChange;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        public async Task<SelectList> GetEmailAddresses()
        {
            var lst = await _db.CRMEmailAddresses.Select(n => new { id = n.Id, name = n.Name }).ToListAsync();

            return new SelectList(lst, "id", "name");
        }
        public async Task<string[]> CRMEmail_GetByIdAsync(int id)
        {
            var n = await _db.CRMEmailAddresses.FindAsync(id);
            string[] ary = { n.Name, n.EmailAddress };
            return ary;
        }
    }
}
