using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models.ViewModels;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class RemoveModel : PageModel
    {
        private readonly UnitOfWork _context;
        public RemoveModel(UnitOfWork context)
        {
            _context = context;
        }
        [BindProperty]
        public ResumeRemoveViewModel ResumeRemoveVM { get; set; }
        public async Task<IActionResult> OnGet(int ID)
        {
            ResumeRemoveVM = new ResumeRemoveViewModel();

            ResumeRemoveVM.AdminResume = await _context.AdminResumeRepo.GetByID(ID);
            if (ResumeRemoveVM.AdminResume == null)
                return NotFound();
            if (ResumeRemoveVM.AdminResume.TypeID == "type3")
            {

                ResumeRemoveVM.SectionTitles = _context.SectionTitleRepo
                    .GetAsync(n => n.AdminResumeID == ID).Result.ToList();
                ResumeRemoveVM.TitleDetails = _context.TitleDetailRepo
                    .GetAsync().Result.ToList();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            _context.AdminResumeRepo.Delete(ResumeRemoveVM.AdminResume);
            await _context.Save();
            return RedirectToPage("/Admin/Index");
        }
    }
}
