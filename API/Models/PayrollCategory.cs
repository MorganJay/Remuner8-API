using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("PayrollCategory")]
    public partial class PayrollCategory
    {
        [Key]
        [Column("categoryId")]
        public int CategoryId { get; set; }
        [Required]
        [Column("categoryName")]
        [StringLength(30)]
        public string CategoryName { get; set; }
    }
}
