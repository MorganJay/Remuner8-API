﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Remuner8_Backend.Models
{
    public partial class Password
    {
        [Key]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must be 8-32 characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,33}$",
            ErrorMessage = @"Password must contain at least one lowercase and uppercase letter, a number and a special character")]
        public string Password1 { get; set; }

        [InverseProperty("EmailAddressNavigation")]
        public virtual EmployeeBiodata EmployeeBiodata { get; set; }
    }
}