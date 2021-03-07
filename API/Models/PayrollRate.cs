using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class PayrollRate
    {
        public PayrollRate()
        {
            PayrollOvertimeItems = new HashSet<PayrollOvertimeItem>();
        }

        [Key]
        [Column("rateId")]
        public int RateId { get; set; }
        [Required]
        [Column("rateType")]
        [StringLength(50)]
        public string RateType { get; set; }

        [InverseProperty(nameof(PayrollOvertimeItem.Rate))]
        public virtual ICollection<PayrollOvertimeItem> PayrollOvertimeItems { get; set; }
    }
}
