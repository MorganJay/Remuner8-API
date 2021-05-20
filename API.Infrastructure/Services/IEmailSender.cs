using System.Threading.Tasks;

namespace API.Infrastructure.Services
{
    public interface IEmailSender
    {
        Task EmailSender(string recipient, string Name);
    }
}