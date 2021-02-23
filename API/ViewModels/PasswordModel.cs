using System.ComponentModel.DataAnnotations;

namespace Remuner8_Backend.EntityModels
{
    public class PasswordModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must be 8-32 characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-`~()_=+{}\|'.<>;:,/""]).{8,33}$",
            ErrorMessage = "8 - 32 characters long, with at least one lowercase and uppercase letter, a number and a special character")]
        public string Password { get; set; }
    }
}