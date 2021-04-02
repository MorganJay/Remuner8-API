using API.Data_Models.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly Remuner8Context context;
        private readonly IMapper mapper;

        public TimeSheetRepository(Remuner8Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TimeSheetDto> AddTimeSheetAsync(TimeSheetDto model)
        {
            var dataTimeSheet = new TimeSheet();
            var timeSheetModel = mapper.Map(model, dataTimeSheet);
            await context.TimeSheets.AddAsync(timeSheetModel);
            await context.SaveChangesAsync();
            return mapper.Map<TimeSheetDto>(timeSheetModel);
        }

        public async Task<bool> DeleteTimeSheetAsync(string id)
        {
            var timeSheet = await context.TimeSheets.FindAsync(id);
            context.TimeSheets.Remove(timeSheet);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TimeSheetDto>> GetAllTimeSheetAsync()
        {
            var timeSheetLog = await context.TimeSheets.ToListAsync();
            return mapper.Map<IEnumerable<TimeSheetDto>>(timeSheetLog);
        }

        public async Task<TimeSheetDto> GetTimeSheetByIdAsync(string id)
        {
            var datatimesheet = await context.TimeSheets.Where(s => s.EmployeeId == id).FirstOrDefaultAsync();
            return mapper.Map<TimeSheetDto>(datatimesheet);
        }

        public async Task<bool> UpdateTimeSheetAsync(TimeSheetDto model)
        {
            var datatimesheet = await context.TimeSheets.FirstOrDefaultAsync(s => s.EmployeeId == model.EmployeeId);
            if (datatimesheet is not null)
            {
                mapper.Map(model, datatimesheet);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}