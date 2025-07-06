using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace External_Logins.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        #region Send Email Using Gmail
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    _config["EmailSettings:SenderEmail"],
                    _config["EmailSettings:SenderPassword"])
            };

            var message = new MailMessage
            {
                From = new MailAddress(_config["EmailSettings:SenderEmail"] ?? ""),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(email);

            await smtpClient.SendMailAsync(message);
        }

        #endregion

        #region Send Email Using mailtrap
        /*  public async Task SendEmailAsync(string email, string subject, string htmlMessage)
          {
              var smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io")
              {
                  Port = 2525,
                  EnableSsl = true,
                  Credentials = new NetworkCredential("18fbf4c390a1ce", "a9eda17eb805ab")
              };

              var message = new MailMessage
              {
                  From = new MailAddress(_config["EmailSettings:SenderEmail"] ?? ""),
                  Subject = subject,
                  Body = htmlMessage,
                  IsBodyHtml = true
              };

              message.To.Add(email);

              await smtpClient.SendMailAsync(message);
          }*/
        #endregion

    }
}
