using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<int> DepartmentsCountAsync();

        Task<int> EmployeeCountAsync();
    }
}