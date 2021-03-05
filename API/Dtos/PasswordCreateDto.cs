using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Remuner8_Backend.Dtos
{
    public class PasswordCreateDto
    {
        [Required]
        [Column("email")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must be 8-32 characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-`~()_=+{}\|'.<>;:,/""]).{8,33}$",
            ErrorMessage = "8 - 32 characters long, with at least one lowercase and uppercase letter, a number and a special character")]
        public string Password1 { get; set; }
    }
}