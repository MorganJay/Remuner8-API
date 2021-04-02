using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmploymentTypeCreateDto
    {
        [Required]
        [Column("employmentName")]
        [StringLength(50)]
        public string EmploymentName { get; set; }
    }
}