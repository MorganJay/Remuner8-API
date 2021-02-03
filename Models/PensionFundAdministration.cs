using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class PensionFundAdministration
    {
        public PensionFundAdministration()
        {
            StatutoryDeductions = new HashSet<StatutoryDeduction>();
        }

        public string PfaCode { get; set; }
        public string PfaName { get; set; }
        public string AccountNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<StatutoryDeduction> StatutoryDeductions { get; set; }
    }
}
