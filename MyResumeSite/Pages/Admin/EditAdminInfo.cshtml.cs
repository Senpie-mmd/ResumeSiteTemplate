using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditAdminInfoModel : PageModel
    {
        private readonly UnitOfWork _context;
        public EditAdminInfoModel(UnitOfWork context)
        {
            _context = context;
        }
        [BindProperty]
        public AdminInfo AdminInfo { get; set; }

        public async Task<IActionResult> OnGet(string UserID)
        {
            AdminInfo = await _context.AdminInfoRepo.GetByID(UserID);
            if (AdminInfo == null)
                return NotFound();
            return Page();
        }
        [BindProperty]
        public IFormFile ImgUp { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                AdminInfo admin0 = await _context.AdminInfoRepo.GetByID(AdminInfo.Id);
                string Path = System.IO.Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/Images");
                if (ImgUp != null)
                {
                    string imgName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(ImgUp.FileName);
                    if (AdminInfo.Image != null)
                    {
                        string removePath = System.IO.Path.Combine(Path, AdminInfo.Image);
                        if (System.IO.File.Exists(removePath))
                            System.IO.File.Delete(removePath);
                    }
                    string savePath = System.IO.Path.Combine(Path, imgName);
                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                    {
                        ImgUp.CopyTo(fileStream);
                    }
                    admin0.Image = imgName;
                }
                admin0.Id = AdminInfo.Id;

                admin0.FullName = AdminInfo.FullName;
                admin0.PhoneNum = AdminInfo.PhoneNum;
                admin0.Address = AdminInfo.Address;
                _context.AdminInfoRepo.Update(admin0);
                await _context.Save();
                return RedirectToPage("/Admin/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
