using Remuner8_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PayrollAdditionItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Column("amount2", TypeName = "decimal(19, 4)")]
        public decimal Amount1 { get; set; }

        public IEnumerable<EmployeeBiodata> Assignee { get; set; }
    }
}