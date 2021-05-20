using API.Core.Entities;
using System;

namespace API.Core.Dtos
{
    public class TimeSheetDto
    {
        public string EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public TimeSpan? HoursWorked => (TimeOut - TimeIn);
        public virtual EmployeeBiodata Employee { get; set; }
    }
}