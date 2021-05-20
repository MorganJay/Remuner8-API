using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Core.Dtos
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