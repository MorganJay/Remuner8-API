using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public LeaveRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task CreateLeaveTypeAsync(LeaveType leaveType)
        {
            if (leaveType is null)
            {
                throw new ArgumentNullException(nameof(leaveType));
            }
            await _remuner8Context.LeaveTypes.AddAsync(leaveType);
        }

        public async Task<IEnumerable<LeaveType>> GetAllLeaveTypeAsync()
        {
            return await _remuner8Context.LeaveTypes.ToListAsync();
        }

        public async Task<LeaveType> GetLeaveById(int id)
        {
            return await _remuner8Context.LeaveTypes.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                await _remuner8Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateLeaveType(LeaveType leaveType)
        {
            //
        }
    }
}