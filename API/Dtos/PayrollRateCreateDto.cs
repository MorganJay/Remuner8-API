using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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