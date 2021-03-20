using API.Dtos;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class BonusRepository : IBonusRepository
    {
        private readonly Remuner8Context context;

        public BonusRepository(Remuner8Context context )
        {
            this.context = context;
        }
        public async Task<BonusDto> AddBonusAsync(BonusDto model)
        {
            try
            {
                var bonus = new Bonus
                {
                    BonusName = model.BonusName,
                    Amount = model.Amount

                };

                var bonusentity = await context.AddAsync(bonus);
                var a = bonusentity.Entity;
                model.BonusName = a.BonusName;
                model.Amount = a.Amount;
                return model;
            }
            catch (Exception)
            {

                throw new Exception("The process was not successful");
            }

            
        }

        public   IEnumerable<BonusDto> GetAllBonusAsync()
        {
            var listOfBonuses =   context.Bonuses;
            var listofBonusDto = new List<BonusDto>();
            
            foreach (var item in listOfBonuses)
            {
                var bonusDto = new BonusDto
                {
                    BonusName = item.BonusName,
                    Amount = item.Amount,
                };
                listofBonusDto.Add(bonusDto);

            }
            return listofBonusDto;
        }

        public BonusDto UpdateBonusAsync(BonusDto model)
        {
           var bonus= context.Bonuses.Find() 
        }
    }
}
