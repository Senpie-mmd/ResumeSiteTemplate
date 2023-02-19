using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Context;
using MyResumeSite.Models;
using MyResumeSite.Utilities;

namespace MyResumeSite.Pages
{
    public class SendMailModel : PageModel
    {
        private readonly UnitOfWork _context;
        private readonly IEmailSender _emailSender;
        private readonly ReCaptcha _captcha;
        public SendMailModel(IEmailSender emailSender, UnitOfWork context, ReCaptcha captcha)
        {
            _context = context;
            _emailSender = emailSender;
            _captcha = captcha;
        }

        [BindProperty]
        public Models.Message Message { get; set; }
        [BindProperty]
        public string AdminEmail { get; set; }
        public void OnGet()
        {
            Message = new Models.Message();
            string AdminID = _context.AdminRepo.AdminID();
            AdminEmail = _context.AdminInfoRepo.GetAsync(n => n.Id == AdminID)
                .Result.First().Email;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!Request.Form.ContainsKey("g-recaptcha-response")) return Page();
                var captcha = Request.Form["g-recaptcha-response"].ToString();
                if (!await _captcha.IsValid(captcha)) return Page();

                Message.AddedTime = DateTime.Now;
                _context.MessageRepo.Insert(Message);
                await _context.Save();
                await _emailSender.SendEmailAsync(AdminEmail, Message.Title, Message.Body);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
