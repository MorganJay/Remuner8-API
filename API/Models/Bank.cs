using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Bank
    {
        public Bank()
        {
            EmployeeBiodatas = new HashSet<EmployeeBiodata>();
        }

        public string BankCode { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<EmployeeBiodata> EmployeeBiodatas { get; set; }
    }
}
