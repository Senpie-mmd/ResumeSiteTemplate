using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models;
using MyResumeSite.Models.ViewModels;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _context;
        public IndexModel(UnitOfWork context)
        {
            _context = context;
        }
        [BindProperty]
        public AdminIndexViewModel AdminIndexVM { get; set; }
        public async Task<IActionResult> OnGet()
        {
            string userID = _context.AdminRepo.AdminID();
            AdminIndexVM = new AdminIndexViewModel()
            {
                AdminInfo = await _context.AdminInfoRepo.GetByID(userID),
                AdminResumes = _context.AdminResumeRepo.GetAsync().Result.ToList(),
                SectionTitles = _context.SectionTitleRepo.GetAsync().Result.ToList(),
                TitleDetails = _context.TitleDetailRepo.TitleDetail().Result,
                Comments = _context.CommentRepo.GetAsync(n => n.IsConfirmed == false).Result.ToList(),
                Messages = _context.MessageRepo.GetAsync().Result.OrderByDescending(n => n.AddedTime)
                .ToList()
            };
            return Page();
        }

        public async Task<IActionResult> OnPost(int ConfirmID, int RejectID)
        {
            if (ConfirmID == 0)
            {
                Comment cm0 = await _context.CommentRepo.GetByID(RejectID);
                _context.CommentRepo.Delete(cm0);
            }
            else
            {
                Comment cm0 = await _context.CommentRepo.GetByID(ConfirmID);
                cm0.IsConfirmed = true;
                _context.CommentRepo.Update(cm0);

            }
            await _context.Save();
            return RedirectToPage("/Admin/Index");
        }
    }
}
