using API.Dtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class EmailSenderRepository : IEmailSender
    {
        private readonly MailConfig _mailConfig;
        private string mailPath = @"MailTemplate/{0}.html";

        public EmailSenderRepository(IOptions<MailConfig>mailConfig  )
        {
            this._mailConfig = mailConfig.Value;
        }
        public async  Task EmailSender(Message message)
        {
            message.Subject = "Remuner8 Notification";
            message.Body = GetEmailBody("MailTest");
            await CreateEmail(message);
        }

        private async  Task CreateEmail(Message message)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_mailConfig.SenderAddress, _mailConfig.SenderDisplayName),
                Subject = message.Subject,
                IsBodyHtml = _mailConfig.IsBodyHTML,
                Body = message.Body

            };
            foreach (var item in message.To)
            {
                mail.To.Add(item);
            }
            mail.BodyEncoding = Encoding.Default;
            var credential = new NetworkCredential(_mailConfig.Username, _mailConfig.Password);
            SmtpClient smtp = new SmtpClient
            {
                Port = _mailConfig.Port,
                Host = _mailConfig.Host,
                Credentials = credential,
                UseDefaultCredentials = _mailConfig.UseDefaultCredentials
            };
            await smtp.SendMailAsync(mail); 
            

        }
        private string GetEmailBody(string mailTemplate)
        {
            var body = File.ReadAllText(string.Format(mailPath, mailTemplate));
            return body;
        }
    }
}
