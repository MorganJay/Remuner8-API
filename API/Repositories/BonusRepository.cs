using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class BonusRepository : IBonusRepository
    {
        private readonly Remuner8Context context;
        private readonly IMapper mapper;

        public BonusRepository(Remuner8Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BonusDto> AddBonusAsync(BonusDto model)
        {
            try
            {
                var bonus = new Bonus
                {
                    BonusName = model.BonusName,
                    Amount = model.Amount,
                };

                var bonusentity = await context.AddAsync(bonus);
                await context.SaveChangesAsync();
                var a = bonusentity.Entity;
                model.BonusName = a.BonusName;
                model.Amount = a.Amount;
                return model;
            }
            catch (Exception)
            {
                throw; // new Exception("The process was not successful");
            }
        }

        public bool DeleteBonus(int id)
        {
            try
            {
                var deletebonus = context.Bonuses.Where(s => s.JobDescriptionId == id).FirstOrDefault();
                if (deletebonus is not null)
                {
                    context.Bonuses.Remove(deletebonus);
                    return true;
                }
                throw new ArgumentNullException(deletebonus.BonusName);
            }
            catch (Exception)
            {
                throw; // new Exception();
            }
        }

        public async Task<IEnumerable<BonusDto>> GetAllBonusAsync()
        {
            var listOfBonuses = await context.Bonuses.Include(s => s.JobDescription).Include(s => s.Department).ToListAsync();
            var listofBonusDto = new List<BonusDto>();

            foreach (var item in listOfBonuses)
            {
                var bonusDto = new BonusDto
                {
                    BonusName = item.BonusName,
                    Amount = item.Amount,
                    JobDescriptionName = item.JobDescription.JobDescriptionName,
                    DepartmentName = item.Department.DepartmentName
                };
                listofBonusDto.Add(bonusDto);
            }
            return listofBonusDto;
        }

        public async Task<BonusDto> GetBonusById(int id)
        {
            try
            {
                var getBonusById = await context.Bonuses.Where(s => s.JobDescriptionId == id).FirstOrDefaultAsync();
                if (getBonusById is not null)
                {
                    var bonusDto = new BonusDto
                    {
                        BonusName = getBonusById.BonusName,
                        Amount = getBonusById.Amount
                    };
                    return bonusDto;
                }
                throw new ArgumentNullException(getBonusById.BonusName);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public BonusDto UpdateBonus(BonusDto model)
        {
            try
            {
                var bonus = context.Bonuses.Find(model.JobDescriptionId);
                bonus.BonusName = model.BonusName;
                bonus.Amount = model.Amount;
                context.Bonuses.Update(bonus);
                context.SaveChanges();

                return mapper.Map<BonusDto>(bonus);
            }
            catch (Exception)
            {
                throw; // new Exception("The update was not successful");
            }
        }
    }
}