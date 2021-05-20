using API.Core.Dtos;
using API.Core.Entities;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task<SystemDefault> GetCompanyDetailsAsync();

        Task CreateCompanyAsync(SystemDefault systemDefault);

        Task<bool> SaveAllAsync();

        void UpdateAsync(SystemDefaultDto Company);
    }
}