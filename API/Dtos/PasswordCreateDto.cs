using Remuner8_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PasswordCreateDto
    {
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        [StringLength(32)]
        public string Password1 { get; set; }
    }
}
