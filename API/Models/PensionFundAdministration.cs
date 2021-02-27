using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("PensionFundAdministration")]
    public partial class PensionFundAdministration
    {
        public PensionFundAdministration()
        {
            StatutoryDeductions = new HashSet<StatutoryDeduction>();
        }

        [Key]
        [Column("pfaCode")]
        [StringLength(10)]
        public string PfaCode { get; set; }
        [Required]
        [Column("pfaName")]
        [StringLength(50)]
        public string PfaName { get; set; }
        [Required]
        [Column("accountNumber")]
        [StringLength(10)]
        public string AccountNumber { get; set; }
        [Required]
        [Column("address")]
        [StringLength(200)]
        public string Address { get; set; }

        [InverseProperty(nameof(StatutoryDeduction.PfaCodeNavigation))]
        public virtual ICollection<StatutoryDeduction> StatutoryDeductions { get; set; }
    }
}
