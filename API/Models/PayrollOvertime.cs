using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("PayrollOvertime")]
    public partial class PayrollOvertime
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("rateid")]
        public int Rateid { get; set; }
        [Column("rate", TypeName = "decimal(3, 2)")]
        public decimal Rate { get; set; }

        [ForeignKey(nameof(Rateid))]
        [InverseProperty(nameof(PayrollRate.PayrollOvertimes))]
        public virtual PayrollRate RateNavigation { get; set; }
    }
}
