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
    public class JobDescriptionrepository : IJobDescriptionRepository
    {
        private readonly Remuner8Context _context;
        private readonly IMapper _mapper;

        public JobDescriptionrepository(Remuner8Context context,IMapper mapper )
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async  Task<JobDescriptionDto> AddJobDescriptionAsync(JobDescriptionDto model)
        {
            try
            {
                var jobDescriptionModel = _mapper.Map<JobDescription>(model);
                var addedJobDescription =  await _context.JobDescriptions.AddAsync(jobDescriptionModel);
                 await _context.SaveChangesAsync();
                var addedJobDescriptionEntity = addedJobDescription.Entity;
                return _mapper.Map<JobDescriptionDto>(addedJobDescriptionEntity);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteJobDescription(int  id)
        {
            try
            {
                var jobDescriptionEntity = _context.JobDescriptions.Find(id);
                if (jobDescriptionEntity is not null)
                {
                    _context.JobDescriptions.Remove(jobDescriptionEntity);
                    _context.SaveChanges();
                    return true;
                }
                throw new ArgumentNullException();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async  Task<IEnumerable<JobDescriptionDto>> GetAllJobDescriptionAsync()
        {
            try
            {
                 var listOfJobDescription=await   _context.JobDescriptions.ToListAsync();
                return _mapper.Map<IEnumerable<JobDescriptionDto>>(listOfJobDescription);

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public  async Task<JobDescriptionDto> GetJobDescriptionByIdAsync(int  id)
        {
            try
            {
                var jobdescription = await _context.JobDescriptions.Where(s => s.JobDescriptionId == id).FirstOrDefaultAsync();
                if (jobdescription is not null)
                {
                    return _mapper.Map<JobDescriptionDto>(jobdescription);
                }
                throw new ArgumentNullException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<JobDescriptionDto> UpdateJobDescription(JobDescriptionDto model)
        {
            try
            {
                var getJobDescriptionById    = await _context.JobDescriptions.Where(s => s.JobDescriptionId == model.JobDescriptionId).FirstOrDefaultAsync();
                if (getJobDescriptionById is not null)
                {
                    var s = _mapper.Map(model, getJobDescriptionById);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<JobDescriptionDto>(s);
                }
                throw new ArgumentNullException();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
