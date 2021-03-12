using API.Data_Models.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
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
            var datatimesheet = new TimeSheet();
            var timesheetmodel = mapper.Map(model, datatimesheet);
            await context.TimeSheets.AddAsync(timesheetmodel);
            await context.SaveChangesAsync();
            return mapper.Map<TimeSheetDto>(timesheetmodel);
        }

        public async Task<bool> DeleteTimeSheetAsync(string id)
        {
            var timesheet = await context.TimeSheets.FindAsync(id);
            context.TimeSheets.Remove(timesheet);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TimeSheetDto>> GetAllTimeSheetAsync()
        {
            var listOfdata = await context.TimeSheets.ToListAsync();
            return mapper.Map<IEnumerable<TimeSheetDto>>(listOfdata);
        }

        public async Task<TimeSheetDto> GetTimeSheetByIdAsync(string id)
        {
            var datatimesheet = await context.TimeSheets.Where(s => s.EmployeeId == id).FirstOrDefaultAsync();
            return mapper.Map<TimeSheetDto>(datatimesheet);
        }

        public async Task<bool> UpdateTimeSheetAsync(TimeSheetDto model)
        {
            var datatimesheet = await context.TimeSheets.FirstOrDefaultAsync(s => s.EmployeeId == model.EmployeeId);
            if (datatimesheet != null)
            {
                context.TimeSheets.Update(datatimesheet);
                 context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}