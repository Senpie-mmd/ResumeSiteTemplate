using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models;
using MyResumeSite.Models.ViewModels;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _context;
        private readonly ReCaptcha _captcha;

        public IndexModel(UnitOfWork context,
            ReCaptcha captcha)
        {
            _context = context;
            _captcha = captcha;
        }
        [BindProperty]
        public IndexViewModel IndexVM { get; set; }

        public IActionResult OnGet()
        {
            if (_context.ValidationRepo.isAnyRole().Result &&
                _context.ValidationRepo.isAnyUserRole().Result)
            {
                string userID = _context.AdminRepo.AdminID();
                IndexVM = new IndexViewModel()
                {
                    Comment = new Comment(),
                    AdminInfo = _context.AdminInfoRepo.GetByID(userID).Result,
                    AdminResumes = _context.AdminResumeRepo.GetAsync().Result.ToList(),
                    SectionTitle = _context.SectionTitleRepo.GetAsync().Result.ToList(),
                    TitleDetails = _context.TitleDetailRepo.GetAsync().Result.ToList(),
                    Comments = _context.CommentRepo.GetAsync(n => n.IsConfirmed == true)
                    .Result.OrderByDescending(n => n.AddedDate).ToList()
                };
                return Page();
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!Request.Form.ContainsKey("g-recaptcha-response")) return Page();
                var captcha = Request.Form["g-recaptcha-response"].ToString();
                if (!await _captcha.IsValid(captcha)) return Page();

                IndexVM.Comment.AddedDate = DateTime.Now;
                _context.CommentRepo.Insert(IndexVM.Comment);
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
