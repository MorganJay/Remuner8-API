using API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
   public  interface IBonusRepository
    {
       Task< IEnumerable<BonusDto>> GetAllBonusAsync();
        Task<BonusDto> AddBonusAsync(BonusDto model);
        BonusDto UpdateBonusAsync(BonusDto model);
        Task<BonusDto> GetBonusById(int id);
        bool DeleteBonus(int id);


    }
}
