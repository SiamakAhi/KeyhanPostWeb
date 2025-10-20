using keyhanPostWeb.GeneralInterfaces;
using keyhanPostWeb.GeneralViewModels.PersonViewModels;
using keyhanPostWeb.Models;
using keyhanPostWeb.Models.Entities.PersonEntities;

namespace keyhanPostWeb.GeneralService
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _db;
        public PersonService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddPersonAsync(VmPerson n)
        {
            Person p = new Person();
            p.FatherName = n.FatherName;
            p.FName = n.FName;
            p.LastName = n.LastName;
            p.NotionalityCode = n.NotionalityCode;
            p.Mobile = n.Mobile;
            p.IdentityCode = n.IdentityCode;
            p.IsEmployee = n.IsEmployee;
            p.IsMoaref = n.IsMoaref;
            p.Gender = n.Gender;
            p.PersonType = n.PersonType;

            _db.People.Add(p);
            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
            {
                return p.Id;
            }

            return 0;
        }

    }
}
