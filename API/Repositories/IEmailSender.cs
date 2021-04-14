using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IEmailSender
    {
        Task EmailSender(string recipient, string Name);
    }
}