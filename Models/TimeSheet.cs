using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class TimeSheet
    {
        public string EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public TimeSpan? HoursWorked { get; set; }

        public virtual EmployeeBiodatum Employee { get; set; }
    }
}
