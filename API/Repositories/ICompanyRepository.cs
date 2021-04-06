using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public interface ICompanyRepository
    {
        Task<CompanyDetails> GetCompanyDetailsAsync();

        Task CreateCompanyAsync(CompanyDetails systemDefault);

        Task<bool> SaveAllAsync();

        void UpdateAsync(CompanyDetails Company);
    }
}