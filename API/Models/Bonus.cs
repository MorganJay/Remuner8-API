using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Keyless]
    public partial class Bonus
    {
        [Column("jobDescriptionId")]
        public int JobDescriptionId { get; set; }

        [Column("departmentId")]
        public int DepartmentId { get; set; }

        [Column("bonusName", TypeName = "decimal(19, 4)")]
        public decimal BonusName { get; set; }

        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(JobDescriptionId))]
        public virtual JobDescription JobDescription { get; set; }
    }
}