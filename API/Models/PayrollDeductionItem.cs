using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class PayrollDeductionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int AssigneeId { get; set; }
    }
}
