using keyhanPostWeb.GeneralViewModels.PersonViewModels;

namespace keyhanPostWeb.GeneralInterfaces
{
    public interface IPersonService
    {
        Task<int> AddPersonAsync(VmPerson n);

    }
}
