using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PayrollRateCreateDto
    {
        
        [Required]
        [Column("rateType")]
        [StringLength(50)]
        public string RateType { get; set; }
    }
}
