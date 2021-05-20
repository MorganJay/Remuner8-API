using API.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IJobDescriptionRepository
    {
        Task<JobDescriptionDto> AddJobDescriptionAsync(JobDescriptionDto model);

        bool DeleteJobDescription(int id);

        Task<JobDescriptionDto> GetJobDescriptionByIdAsync(int id);

        Task<JobDescriptionDto> UpdateJobDescription(JobDescriptionDto model);

        Task<IEnumerable<JobDescriptionDto>> GetAllJobDescriptionAsync();
    }
}