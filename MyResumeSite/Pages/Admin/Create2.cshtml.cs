using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models.ViewModels;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class Create2Model : PageModel
    {
        private readonly UnitOfWork _context;
        public Create2Model(UnitOfWork context)
        {
            _context = context;
        }
        [BindProperty]
        public CreateResumeViewModel CreateResumeVM { get; set; }
        [BindProperty]
        public bool isFirstTitle { get; set; }
        public void OnGet(int AdminResumeID, int SectionID)
        {
            if (_context.TitleDetailRepo.Count(n => n.SectionID == SectionID).Result != 0)
            {
                isFirstTitle = true;
            }
            else
            {
                isFirstTitle = false;
            }

            CreateResumeVM = new CreateResumeViewModel();
            CreateResumeVM.SectionTitle = new Models.AdminResumeSectionTitle()
            {
                AdminResumeID = AdminResumeID
            };
            CreateResumeVM.TitleDetails = new Models.SectionTitleDetail()
            {
                SectionID = SectionID
            };
        }

        public async Task<IActionResult> OnPost(int SectionID)
        {
            if (ModelState.IsValid)
            {
                if (SectionID == 0)
                {

                    if (_context.SectionTitleRepo.Count(n =>
                    n.SectionTitle == CreateResumeVM.SectionTitle.SectionTitle).Result == 0)
                    {
                        _context.SectionTitleRepo.Insert(CreateResumeVM.SectionTitle);
                        await _context.Save();
                        return RedirectToPage("/Admin/Create2",
                            new
                            {
                                SectionID = _context.SectionTitleRepo
                                .SectionID(n => n.SectionTitle ==
                                CreateResumeVM.SectionTitle.SectionTitle)
                            });
                    }
                    else
                    {
                        return Page();
                    }

                }
                else
                {
                    _context.TitleDetailRepo.Insert(CreateResumeVM.TitleDetails);
                    await _context.Save();
                    return RedirectToPage("/Admin/Create2", new { SectionID = SectionID });
                }
            }
            else
            {
                isFirstTitle = isFirstTitle;
                CreateResumeVM.TitleDetails = new Models.SectionTitleDetail()
                {
                    SectionID = SectionID
                };
                return Page();
            }
        }
    }
}
