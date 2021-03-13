using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public interface ILeaveRepository
    {
        bool SaveChanges();  
        IEnumerable<LeaveType> GetAllLeaveType();
        LeaveType GetLeaveById(int id);
        void CreateLeaveType(LeaveType leaveType);
        void UpdateLeaveType(LeaveType leaveType);
    }
}
