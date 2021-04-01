using API.Dtos;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayslipRepository
    {
        Task<PayslipDto> GetPayslipByIdAsync(string id);
    }
}