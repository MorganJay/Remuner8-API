using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class JobDescription
    {
        public JobDescription()
        {
            EmployeeBiodatas = new HashSet<EmployeeBiodata>();
        }

        [Key]
        [Column("jobDescriptionId")]
        public int JobDescriptionId { get; set; }
        [Required]
        [Column("jobDescriptionName")]
        [StringLength(50)]
        public string JobDescriptionName { get; set; }
        [Column("basicSalary", TypeName = "decimal(19, 4)")]
        public decimal BasicSalary { get; set; }
        [Column("housingAllowance", TypeName = "decimal(19, 4)")]
        public decimal HousingAllowance { get; set; }
        [Column("transportAllowance", TypeName = "decimal(19, 4)")]
        public decimal TransportAllowance { get; set; }

        [InverseProperty(nameof(EmployeeBiodata.JobDescription))]
        public virtual ICollection<EmployeeBiodata> EmployeeBiodatas { get; set; }
    }
}
