using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace MyResumeSite.Utilities
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("mmdyousefi95@Domain.com");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = htmlMessage;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("mmdyousefi95@gmail.com", "fddfanmdrcotjumb");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return Task.CompletedTask;

            //fddfanmdrcotjumb * (mmdyousefi95@gmail.com) AppPassword :)
        }
    }
}
