using API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    interface IBonusRepository
    {
        IEnumerable<BonusDto> GetAllBonusAsync();
        Task<BonusDto> AddBonusAsync(BonusDto model);
        BonusDto UpdateBonusAsync(BonusDto model);
        


    }
}
