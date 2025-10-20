using keyhanPostWeb.Areas.CMS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.CmsInterfaces
{
    public interface IGalleryService
    {
        Task<Int16> AddPicToGalleryAsync(VM_Gallery entity);
        Task<List<VM_Gallery>> GalleriesAsync(bool? visible = null);
        Task<VM_Gallery> FindPhotoGalery(int id);
    }
}
