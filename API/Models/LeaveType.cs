using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Index(nameof(Name), Name = "UQ__LeaveTyp__72E12F1BF20C58BD", IsUnique = true)]
    public partial class LeaveType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("days")]
        public int Days { get; set; }
        [Column("status")]
        public bool Status { get; set; }
    }
}
