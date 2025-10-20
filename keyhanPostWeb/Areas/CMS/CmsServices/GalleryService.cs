using Microsoft.EntityFrameworkCore;
using keyhanPostWeb.Areas.CMS.CmsInterfaces;
using keyhanPostWeb.Areas.CMS.Dtos;
using keyhanPostWeb.Areas.CMS.Models.Entities;
using keyhanPostWeb.Classes;
using keyhanPostWeb.Models;

namespace keyhanPostWeb.Areas.CMS.CmsServices
{

    public class GalleryService : IGalleryService
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public GalleryService(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        //افزودن تصویر به گالری
        public async Task<Int16> AddPicToGalleryAsync(VM_Gallery entity)
        {
            if (entity.ImageFile == null)
                return (Int16)SaveResult.NoImageSelected;

            string FileExtension = Path.GetExtension(entity.ImageFile.FileName);
            string fileName = string.Concat(Guid.NewGuid().ToString(), FileExtension);
            string SavePath = $"{_env.WebRootPath}/img/gallery/{fileName}";

            using (var streem = new FileStream(SavePath, FileMode.Create))
            {
                await entity.ImageFile.CopyToAsync(streem);
            }
            PhotoGallery photo = new PhotoGallery()
            {
                Description = entity.Description,
                FileName = fileName,
                Title = entity.Title,
                CategoryID = entity.CategoryID,
            };

            await _db.PhotoGallery.AddAsync(photo);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
                return (Int16)SaveResult.SaveSuccess;
            else
                return (Int16)SaveResult.InternalErrorr;
        }

        public async Task<List<VM_Gallery>> GalleriesAsync(bool? visible = null)
        {
            var photos = await _db.PhotoGallery
                .Where(n => visible == null ? n.photoID > 0 : n.Visible == visible)

                .Select(n => new VM_Gallery
                {
                    CategoryID = n.CategoryID,
                    photoID = n.photoID,
                    Description = n.Description,
                    FileName = n.FileName,
                    Title = n.Title,
                    Visible = n.Visible
                }).OrderByDescending(n => n.photoID).ToListAsync();

            return photos;
        }

        public async Task<VM_Gallery> FindPhotoGalery(int id)
        {
            var phto = await _db.PhotoGallery.FindAsync(id);

            return new VM_Gallery
            {
                CategoryID = phto.CategoryID,
                Description = phto.Description,
                FileName = phto.FileName,
                photoID = phto.photoID,
                Title = phto.Title,
                Visible = phto.Visible,
            };
        }
        //
    }
}
