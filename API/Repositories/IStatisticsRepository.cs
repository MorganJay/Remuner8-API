using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IStatisticsRepository
    {
        Task<int> DepartmentsCountAsync();

        Task<int> EmployeeCountAsync();
    }
}