using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IEmailSender
    {
        Task EmailSender(Message message);
    }
}
