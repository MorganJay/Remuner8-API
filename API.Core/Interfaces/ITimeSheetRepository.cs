using API.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface ITimeSheetRepository
    {
        Task<TimeSheetDto> AddTimeSheetAsync(TimeSheetDto model);

        Task<bool> DeleteTimeSheetAsync(string id);

        Task<TimeSheetDto> GetTimeSheetByIdAsync(string id);

        Task<bool> UpdateTimeSheetAsync(TimeSheetDto model);

        Task<IEnumerable<TimeSheetDto>> GetAllTimeSheetAsync();
    }
}