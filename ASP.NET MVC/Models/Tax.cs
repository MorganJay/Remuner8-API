using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Remuner8_Backend.Models
{
    [Keyless]
    [Index(nameof(EmployeeId), Name = "UQ__Taxes__C134C9C0AE6154C9", IsUnique = true)]
    public partial class Tax
    {
        [Required]
        [Column("employeeId")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column("PAYE", TypeName = "decimal(19, 4)")]
        public decimal? Paye { get; set; }
        [Column("pension", TypeName = "decimal(19, 4)")]
        public decimal? Pension { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual EmployeeBiodata Employee { get; set; }
    }
}
