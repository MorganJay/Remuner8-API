using API.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IBonusRepository
    {
        Task<IEnumerable<BonusDto>> GetAllBonusAsync();

        Task<BonusDto> AddBonusAsync(BonusDto model);

        BonusDto UpdateBonus(BonusDto model);

        Task<BonusDto> GetBonusById(int id);

        bool DeleteBonus(int id);
    }
}