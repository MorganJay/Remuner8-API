using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PayrollOvertimeItemCreateDto
    {
        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("rateid")]
        public int Rateid { get; set; }
    }
}
