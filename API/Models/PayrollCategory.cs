using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class PayrollCategory
    {
        public PayrollCategory()
        {
            PayrollAdditionItems = new HashSet<PayrollAdditionItem>();
        }

        [Key]
        [Column("categoryId")]
        public int CategoryId { get; set; }
        [Required]
        [Column("categoryName")]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(PayrollAdditionItem.Category))]
        public virtual ICollection<PayrollAdditionItem> PayrollAdditionItems { get; set; }
    }
}
