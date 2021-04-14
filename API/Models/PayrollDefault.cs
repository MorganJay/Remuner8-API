using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    public partial class PayrollDefault
    {
        [Column(TypeName = "date")]
        public DateTime MinimumSalaryPeriod { get; set; }

        [Column(TypeName = "date")]
        public DateTime MaximumSalaryPeriod { get; set; }

        public int MaxWorkingDays { get; set; }
        public int MaxOvertimeHours { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal MinTaxPercentage { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NonTaxableIncome { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FirstAnnualTaxableIncome { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SecondAnnualTaxableIncome { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ThirdAnnualTaxableIncome { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FourthAnnualTaxableIncome { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FifthAnnualTaxableIncome { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SixthAnnualTaxableIncome { get; set; }

        [Required]
        [StringLength(255)]
        public string Tax { get; set; }

        [StringLength(255)]
        public string Office { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
    }
}