using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PayrollCategoryCreateDto
    {
        [Required]
        [Column("categoryName")]
        [StringLength(30)]
        public string CategoryName { get; set; }
    }
}