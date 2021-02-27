using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class PayrollAdditionItem
    {
        public PayrollAdditionItem()
        {
            EmployeeBiodatas = new HashSet<EmployeeBiodata>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("categoryId")]
        public int? CategoryId { get; set; }
        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }

        [InverseProperty(nameof(EmployeeBiodata.PayrollAdditionItem))]
        public virtual ICollection<EmployeeBiodata> EmployeeBiodatas { get; set; }
    }
}
