using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Keyless]
    [Table("TimeSheet")]
    public partial class TimeSheet
    {
        [Required]
        [Column("employeeId")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("timeIn", TypeName = "time(0)")]
        public TimeSpan TimeIn { get; set; }
        [Column("timeOut", TypeName = "time(0)")]
        public TimeSpan TimeOut { get; set; }
        [Column("hoursWorked", TypeName = "time(0)")]
        public TimeSpan HoursWorked { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual EmployeeBiodata Employee { get; set; }
    }
}
