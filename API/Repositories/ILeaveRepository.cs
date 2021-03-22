using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public interface ILeaveRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<LeaveType>> GetAllLeaveTypeAsync();

        Task<LeaveType> GetLeaveById(int id);

        Task CreateLeaveTypeAsync(LeaveType leaveType);

        void UpdateLeaveType(LeaveType leaveType);
    }
}