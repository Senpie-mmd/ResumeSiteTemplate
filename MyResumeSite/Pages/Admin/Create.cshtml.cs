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
    public class CreateModel : PageModel
    {
        private readonly UnitOfWork _context;
        public CreateModel(UnitOfWork context)
        {
            _context = context;
        }
        [BindProperty]
        public AdminResume AdminResume { get; set; }
        public void OnGet(string TypeID = "")
        {
            AdminResume = new AdminResume();
            AdminResume.UserID = _context.AdminRepo.AdminID();
            AdminResume.TypeID = TypeID;
        }

        public IActionResult OnPostType(string TypeID)
        {
            return RedirectToPage("/Admin/Create", new { TypeID = TypeID });
        }

        public async Task<IActionResult> OnPost(string TypeID)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (_context.AdminResumeRepo.GetAsync(n => n.Title == AdminResume.Title)
                        .Result.Count() == 0)
                    {
                        _context.AdminResumeRepo.Insert(AdminResume);
                        await _context.Save();
                        switch (TypeID)
                        {
                            case "type1":
                                return RedirectToPage("/Index");
                            case "type2":
                                return RedirectToPage("/Index");

                            case "type3":
                                return RedirectToPage("Create2",
                                    new
                                    {
                                        AdminResumeID = _context.AdminResumeRepo
                                 .GetAsync(n => n.Title == AdminResume.Title).Result.First().ID
                                    });
                            default:
                                return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                }
                catch
                {
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
