using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    [Table("PayrollDeductionItemsAssignment")]
    public partial class PayrollDeductionItemsAssignment
    {
        public int PayrollItemId { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeeId { get; set; }

        [Column(TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.PayrollDeductionItemsAssignments))]
        public virtual EmployeeBiodata Employee { get; set; }

        [ForeignKey(nameof(PayrollItemId))]
        [InverseProperty(nameof(PayrollDeductionItem.PayrollDeductionItemsAssignments))]
        public virtual PayrollDeductionItem PayrollItem { get; set; }
    }
}