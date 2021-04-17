using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class SendGridMailServiceRepository : IMailServiceRepository
    {
        private readonly IConfiguration _configuration;

        public SendGridMailServiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@authdemo.com", "JWT Auth Demo");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }

}
