using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class ReplyMessageModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        public ReplyMessageModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [BindProperty]
        public Models.Message Message { get; set; }
        public void OnGet(string EmailAddress)
        {
            Message = new Models.Message();
            Message.Email = EmailAddress;
            Message.Name = "Admin";
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync(Message.Email,
                    Message.Title,
                    Message.Body);

                return RedirectToPage("/Admin/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
