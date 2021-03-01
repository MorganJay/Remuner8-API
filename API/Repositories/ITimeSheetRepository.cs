using API.Data_Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
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