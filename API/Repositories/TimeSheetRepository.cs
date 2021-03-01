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
    public class TimeSheetRepository:ITimeSheetRepository
    {
        private readonly Remuner8Context context;
        private readonly IMapper mapper;
        

        public TimeSheetRepository(Remuner8Context context , IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
            
        }

        public async  Task<TimeSheetModel> AddTimeSheetAsync(TimeSheetModel model)
        {

            var datatimesheet = new TimeSheet();
           var timesheetmodel= mapper.Map(model,datatimesheet);
             await context.TimeSheets.AddAsync(timesheetmodel);
            await context.SaveChangesAsync();
            return mapper.Map<TimeSheetModel>(timesheetmodel);       
        }

        public async  Task<bool> DeleteTimeSheetAsync(string id)
        {
           var timesheet= await context.TimeSheets.FindAsync(id);
            context.TimeSheets.Remove(timesheet);
           await  context.SaveChangesAsync();
            return true;
        }

        public async  Task<IEnumerable<TimeSheetModel>> GetAllTimeSheetAsync()
        {
            var listOfdata =   await context.TimeSheets.ToListAsync() ;
            return mapper.Map<IEnumerable<TimeSheetModel>>(listOfdata);
            
        }

        public async Task<TimeSheetModel> GetTimeSheetByIdAsync(string id)
        {
           var datatimesheet=  await context.TimeSheets.FirstOrDefaultAsync (s => s.EmployeeId == id);

            return mapper.Map<TimeSheetModel>(datatimesheet);
        }

        public async   Task<bool> UpdateTimeSheetAsync(TimeSheetModel model)
        {
            var datatimesheet = await context.TimeSheets.FirstOrDefaultAsync(s => s.EmployeeId == model.EmployeeId);
            if (datatimesheet!= null)
            {
                mapper.Map(model, datatimesheet);
                await context.SaveChangesAsync();
                return true;
            }
            return false;


        }
    }
}
