using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Remuner8_Backend.Models
{
    [Index(nameof(BankName), Name = "UQ__Banks__3EA6523332347041", IsUnique = true)]
    public partial class Bank
    {
        public Bank()
        {
            EmployeeBiodatas = new HashSet<EmployeeBiodata>();
        }

        [Key]
        [Column("bankCode")]
        [StringLength(10)]
        public string BankCode { get; set; }
        [Required]
        [Column("bankName")]
        [StringLength(50)]
        public string BankName { get; set; }

        [InverseProperty(nameof(EmployeeBiodata.BankCodeNavigation))]
        public virtual ICollection<EmployeeBiodata> EmployeeBiodatas { get; set; }
    }
}
