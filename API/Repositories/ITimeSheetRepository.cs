using API.Data_Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
   public  interface ITimeSheetRepository
    {
        Task<TimeSheetModel> AddTimeSheetAsync (TimeSheetModel model);
        Task<bool> DeleteTimeSheetAsync (string id);
        Task<TimeSheetModel> GetTimeSheetByIdAsync (string id);
        Task<bool> UpdateTimeSheetAsync (TimeSheetModel model);
        Task<IEnumerable<TimeSheetModel>> GetAllTimeSheetAsync ();




    }
}
