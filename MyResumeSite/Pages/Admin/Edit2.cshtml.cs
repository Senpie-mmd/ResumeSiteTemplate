using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class Edit2Model : PageModel
    {
        private readonly UnitOfWork _context;
        public Edit2Model(UnitOfWork context)
        {
            _context = context;
        }
        [BindProperty]
        public AdminResumeSectionTitle SectionTitle { get; set; }
        [BindProperty]
        public SectionTitleDetail TitleDetail { get; set; }
        public async Task<IActionResult> OnGet(int SectionID, int DetailID)
        {
            if (SectionID == 0)
            {
                TitleDetail = await _context.TitleDetailRepo.GetByID(DetailID);
            }
            else
            {
                SectionTitle = await _context.SectionTitleRepo.GetByID(SectionID);
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (SectionTitle.SectionTitle == null)
            {
                _context.TitleDetailRepo.Update(TitleDetail);
            }
            else
            {
                _context.SectionTitleRepo.Update(SectionTitle);
            }
            await _context.Save();
            return RedirectToPage("/Admin/Index");
        }
    }
}
