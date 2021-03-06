using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("PayrollRate")]
    public partial class PayrollRate
    {
        public PayrollRate()
        {
            PayrollOvertimes = new HashSet<PayrollOvertime>();
        }

        [Key]
        [Column("rateId")]
        public int RateId { get; set; }
        [Required]
        [Column("rateType")]
        [StringLength(30)]
        public string RateType { get; set; }

        [InverseProperty(nameof(PayrollOvertime.RateNavigation))]
        public virtual ICollection<PayrollOvertime> PayrollOvertimes { get; set; }
    }
}
