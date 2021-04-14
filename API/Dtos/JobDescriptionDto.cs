using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class JobDescriptionDto
    {
        public int JobDescriptionId { get; set; }

        [Required]
        public string JobDescriptionName { get; set; }

        [Required]
        public decimal BasicSalary { get; set; }

        [Required]
        public decimal HousingAllowance { get; set; }

        [Required]
        public decimal TransportAllowance { get; set; }
    }
}