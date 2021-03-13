using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly Remuner8Context _remuner8Context;
        public LeaveRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public void CreateLeaveType(LeaveType leaveType)
        {
            if (leaveType == null)
            {
                throw new ArgumentNullException(nameof(leaveType));
            }
            _remuner8Context.LeaveTypes.Add(leaveType);
        }

        public IEnumerable<LeaveType> GetAllLeaveType()
        {
            return _remuner8Context.LeaveTypes.ToList();
        }

        public LeaveType GetLeaveById(int id)
        {
            return _remuner8Context.LeaveTypes.FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_remuner8Context.SaveChanges() >= 0);
        }

        public void UpdateLeaveType(LeaveType leaveType)
        {
           
        }
        //public IEnumerable<LeaveType> GetAllLeaveType()
        //{
        //    var leave = new List<LeaveType>
        //    {
        //        new LeaveType{Days = 30, Id = 1, Name = "Olawale Olalekan", Status = true }
        //    };
        //        return leave;
        //}
    }
}
