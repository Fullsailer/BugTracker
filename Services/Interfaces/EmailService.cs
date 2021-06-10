using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace BugTracker.Services.Interfaces
{
    public class EmailService : IEmailSender
    {
      
            private readonly IConfiguration _configuration;

            public EmailService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task SendEmailAsync(string email, string subject, string htmlMessage)
            {
                //Step 1: Use MimeMessage, MailboxAddress.Parse and BodyBuilder
                // to help asssemble the content of an email
                var emailTo = new MimeMessage();
                emailTo.Sender = MailboxAddress.Parse(_configuration["MailSettings:Mail"]);
                emailTo.To.Add(MailboxAddress.Parse(email));
                emailTo.Subject = subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlMessage;

                emailTo.Body = bodyBuilder.ToMessageBody();

                ////Step 2: Configure smtp server to send email
                ////using var smtp = new SmtpClient();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                var host = _configuration["MailSettings:Host"];
                var port = Convert.ToInt32(_configuration["MailSettings:Port"]);
                smtp.Connect(host, port, SecureSocketOptions.StartTls);

                var userName = _configuration["MailSettings:Mail"];
                var password = _configuration["MailSettings:Password"];
                smtp.Authenticate(userName, password);

                await smtp.SendAsync(emailTo);
                await smtp.DisconnectAsync(true);

            }
        }
    }
