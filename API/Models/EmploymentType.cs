using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("EmploymentType")]
    [Index(nameof(EmploymentName), Name = "UQ__Employme__7E571DB88372C814", IsUnique = true)]
    public partial class EmploymentType
    {
        [Key]
        [Column("employmentTypeId")]
        public int EmploymentTypeId { get; set; }
        [Required]
        [Column("employmentName")]
        [StringLength(50)]
        public string EmploymentName { get; set; }
    }
}
