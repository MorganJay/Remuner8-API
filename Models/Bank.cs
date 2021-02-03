using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class Bank
    {
        public Bank()
        {
            EmployeeBiodata = new HashSet<EmployeeBiodatum>();
        }

        public string BankCode { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<EmployeeBiodatum> EmployeeBiodata { get; set; }
    }
}
