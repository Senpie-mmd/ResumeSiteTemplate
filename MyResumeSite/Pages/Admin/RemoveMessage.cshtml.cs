using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class RemoveMessageModel : PageModel
    {
        private readonly UnitOfWork _context;
        public RemoveMessageModel(UnitOfWork context)
        {
            _context = context;
        }

        public Models.Message Message { get; set; }

        public async Task<IActionResult> OnGet(int ID)
        {
            Message = await _context.MessageRepo.GetByID(ID);
            if (Message == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPost(int ID)
        {
            try
            {
                _context.MessageRepo.Delete(ID);
            }
            catch
            {
                return NotFound();
            }
            await _context.Save();
            return RedirectToPage("/Admin/Index");
        }
    }
}
