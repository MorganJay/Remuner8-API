using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class EmailSenderRepository : IEmailSender
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailSenderRepository(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        //private readonly MailConfig _mailConfig;
        //private string mailPath = @"MailTemplate/{0}.html";

        //public EmailSenderRepository(IOptions<MailConfig>mailConfig  )
        //{
        //    this._mailConfig = mailConfig.Value;
        //}
        //public async  Task EmailSender(Message message)
        //{
        //    try
        //    {
        //        message.Subject = "Remuner8 Notification";
        //        message.Body = GetEmailBody("MailTest");
        //        await CreateEmail(message);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task mailsender()
        //{
        //    try
        //    {
        //        var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
        //        {
        //            Port = 587,
        //            EnableSsl = true,

        //            Credentials = new NetworkCredential("soetanqaweey@gmail.com","bidex001"),
        //            UseDefaultCredentials = false
        //        }) ;
        //        Email.DefaultSender = sender;

        //        var mail = Email
        //            .From("soetanqaweey@gmail.com", "Qaweey")
        //            .To("Sekinahdeleoladepo@gmail.com")
        //            .Subject("Hello my love")
        //            .Body("Thanks for everything you do my love");
        //        await mail.SendAsync();

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //}

        //private async  Task CreateEmail(Message message)
        //{
        //    var mail = new MailMessage
        //    {
        //        From = new MailAddress(_mailConfig.SenderAddress, _mailConfig.SenderDisplayName),
        //        Subject = message.Subject,
        //        IsBodyHtml = _mailConfig.IsBodyHTML,
        //        Body = message.Body

        //    };
        //    foreach (var item in message.To)
        //    {
        //        mail.To.Add(item);
        //    }
        //    mail.BodyEncoding = Encoding.Default;
        //    var credential = new NetworkCredential(_mailConfig.Username, _mailConfig.Password);
        //    SmtpClient smtp = new SmtpClient
        //    {
        //        Port = _mailConfig.Port,
        //        Host = _mailConfig.Host,
        //        EnableSsl= _mailConfig.EnableSsL,
        //        Credentials = credential,
        //        UseDefaultCredentials = _mailConfig.UseDefaultCredentials
        //    };
        //    await smtp.SendMailAsync(mail);

        //}
        //private string GetEmailBody(string mailTemplate)
        //{
        //    var body = File.ReadAllText(string.Format(mailPath, mailTemplate));
        //    return body;
        //}
        public async Task EmailSender(string recipient, string Name)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mail = scope.ServiceProvider.GetRequiredService<IFluentEmail>();

                    var mailler = mail.
                         To(recipient)
                         .Subject("Renumer8 Registration Update")
                         .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/MailTemplate/mailtemplate.cshtml", new { UserName = Name });
                    await mailler.SendAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}