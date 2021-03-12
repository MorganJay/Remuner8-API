using System.Collections.Generic;
using API.Models;

namespace API.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        //private readonly ILeaveRepository _leaveType;

        //public LeaveRepository(ILeaveRepository leaveType)
        //{
        //    _leaveType = leaveType;
        //}
        public IEnumerable<LeaveType> GetAllLeaveType()
        {
            var leave = new List<LeaveType>
            {
                new LeaveType{Days = 30, Id = 1, Name = "Olawale Olalekan", Status = true }
            };
                return leave;
        }
    }
}
