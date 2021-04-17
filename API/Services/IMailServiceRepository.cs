using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IMailServiceRepository
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
