using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RequestReadDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Date { get; set; }
        [Required]
        [StringLength(100)]
        public string Reason { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
