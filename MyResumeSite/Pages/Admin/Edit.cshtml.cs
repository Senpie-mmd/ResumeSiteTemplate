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
    public class EditModel : PageModel
    {
        private readonly UnitOfWork _context;
        public EditModel(UnitOfWork context)
        {
            _context = context;
        }
        [BindProperty]
        public AdminResume AdminResume { get; set; }
        public async Task<IActionResult> OnGet(int ID)
        {

            AdminResume = await _context.AdminResumeRepo.GetByID(ID);
            if (AdminResume == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.AdminResumeRepo.Update(AdminResume);
                await _context.Save();
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
