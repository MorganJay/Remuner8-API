using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class StatutoryDeduction
    {
        public int StatutoryTypeId { get; set; }
        public string EmployeeId { get; set; }
        public decimal Amount1 { get; set; }
        public decimal Amount2 { get; set; }
        public string PfaCode { get; set; }
        public string PfaAccountNumber { get; set; }
        public string PfaAccountNumber1 { get; set; }
        public string Description { get; set; }

        public virtual EmployeeBiodatum Employee { get; set; }
        public virtual PensionFundAdministration PfaCodeNavigation { get; set; }
    }
}
