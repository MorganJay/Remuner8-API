using System.ComponentModel.DataAnnotations;
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
        [StringLength(32)]
        public string Password1 { get; set; }

        [InverseProperty("EmailAddressNavigation")]
        public virtual EmployeeBiodata EmployeeBiodata { get; set; }
    }
}