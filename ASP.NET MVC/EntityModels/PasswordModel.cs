using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Remuner8_Backend.EntityModels
{
    public class PasswordModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must be 8-32 characters")]
        public string Password { get; set; }
    }
}