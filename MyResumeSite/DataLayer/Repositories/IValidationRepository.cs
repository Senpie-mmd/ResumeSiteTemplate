using MyResumeSite.Models.ViewModels;

namespace MyResumeSite.DataLayer.Repositories
{
    public interface IValidationRepository
    {
        Task<bool> isAnyRole();
        Task<bool> isAnyUserRole();
    }
}
