using API.Models;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface ICompanyRepository
    {
        Task<SystemDefault> GetCompanyDetailsAsync();

        Task CreateCompanyAsync(SystemDefault systemDefault);

        Task<bool> SaveAllAsync();

        void UpdateAsync(SystemDefault Company);
    }
}