using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    [Keyless]
    public partial class Bonus
    {
        [Column("jobDescriptionId")]
        public int JobDescriptionId { get; set; }

        [Column("departmentId")]
        public int DepartmentId { get; set; }

        [Required]
        [Column("bonusName")]
        [StringLength(100)]
        public string BonusName { get; set; }

        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(JobDescriptionId))]
        public virtual JobDescription JobDescription { get; set; }
    }
}