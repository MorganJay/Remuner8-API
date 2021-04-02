using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos
{
    public class LeaveTypeCreateDto
    {
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