using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Config;

namespace Pras.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendFeedbackEmailAsync(string subject, string message, List<IFormFile> files = null)
        {
            var emailingSection = _configuration.GetSection("Emailing");
            var emailing = emailingSection.Get<EmailSettings>();

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(emailing.FromName, emailing.FromEmail));
            emailMessage.To.Add(new MailboxAddress("", emailing.ToEmail));
            emailMessage.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = message };

            if (files != null && files.Any())
            {
                foreach (var file in files)
                {
                    builder.Attachments.Add(file.FileName, file.OpenReadStream());
                }
            }

            emailMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                //client.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => true;

                await client.ConnectAsync("smtp.gmail.com", 25, false);
                await client.AuthenticateAsync(emailing.FromEmail, emailing.FromPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        public async Task SendEmailAsync(string subject, string email, string message, List<IFormFile> files = null)
        {
            var emailingSection = _configuration.GetSection("Emailing");
            var emailing = emailingSection.Get<EmailSettings>();

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(emailing.FromName, emailing.FromEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = message };

            if (files != null && files.Any())
            {
                foreach (var file in files)
                {
                    builder.Attachments.Add(file.FileName, file.OpenReadStream());
                }
            }

            emailMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                //client.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => true;

                await client.ConnectAsync("smtp.gmail.com", 25, false);
                await client.AuthenticateAsync(emailing.FromEmail, emailing.FromPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
