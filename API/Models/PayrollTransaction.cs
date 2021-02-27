using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class PayrollTransaction
    {
        public int TransactionId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public bool Deduction { get; set; }
        public decimal Principal { get; set; }
        public decimal Rate { get; set; }
        public decimal Balance { get; set; }
        public bool Statutory { get; set; }

        public virtual EmployeeBiodata Employee { get; set; }
    }
}
