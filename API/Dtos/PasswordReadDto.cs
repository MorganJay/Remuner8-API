using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Remuner8_Backend.EntityModels
{
    public class PasswordReadDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}