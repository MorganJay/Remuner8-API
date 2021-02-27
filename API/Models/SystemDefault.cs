using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Keyless]
    public partial class SystemDefault
    {
        [Required]
        [Column("companyName")]
        [StringLength(30)]
        public string CompanyName { get; set; }
        [Required]
        [Column("address")]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("officialPhoneNumber")]
        [StringLength(15)]
        public string OfficialPhoneNumber { get; set; }
        [Column("mobileNumber")]
        [StringLength(15)]
        public string MobileNumber { get; set; }
        [Required]
        [Column("websiteURL")]
        [StringLength(100)]
        public string WebsiteUrl { get; set; }
        [Column("postalCode")]
        [StringLength(7)]
        public string PostalCode { get; set; }
        [Column("maxSalaryDays")]
        public int MaxSalaryDays { get; set; }
        [Column("salaryStartDate", TypeName = "date")]
        public DateTime SalaryStartDate { get; set; }
        [Column("salaryEndDate", TypeName = "date")]
        public DateTime SalaryEndDate { get; set; }
    }
}
