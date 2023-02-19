using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models.ViewModels;
using MyResumeSite.Utilities;

namespace MyResumeSite.ViewComponents
{
    public class MainProfileViewComponent : ViewComponent
    {
        private readonly UnitOfWork _context;
        public MainProfileViewComponent(UnitOfWork context)
        {
            _context = context;
        }
        public MainProfileViewModel MainProfileVM { get; set; }
        public async Task<IViewComponentResult> InvokeAsync(string ID)
        {
            MainProfileViewModel MainProfileVM = new MainProfileViewModel();
            if (_context.ValidationRepo.isAnyRole().Result == false ||
               _context.ValidationRepo.isAnyUserRole().Result == false)
            {
                MainProfileVM.FullName = "Your Name goes here !";
                MainProfileVM.Image = "DefaultProfile.jpg";
            }
            else
            {
                string userID = _context.AdminRepo.AdminID();
                MainProfileVM.FullName = _context.AdminInfoRepo.GetAsync(n => n.Id == userID)
                    .Result.First().FullName;
                MainProfileVM.Image = _context.AdminInfoRepo.GetAsync(n => n.Id == userID)
                    .Result.First().Image;
            }
            return View("~/Pages/Components/_MainProfileComponent.cshtml", MainProfileVM);
        }
    }
}
