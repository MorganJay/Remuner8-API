using API.Core.Dtos;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IPayslipRepository
    {
        Task<PayslipDto> GetPayslipByIdAsync(string id);
    }
}