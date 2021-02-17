using Remuner8_Backend.EntityModels;

namespace Remuner8_Backend.Repositories
{
    public interface ILoginRepository
    {
        bool ValidateCredentials(PasswordModel model);
    }
}