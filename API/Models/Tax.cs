using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Tax
    {
        public string EmployeeId { get; set; }
        public decimal? Paye { get; set; }
        public decimal? Pension { get; set; }

        public virtual EmployeeBiodata Employee { get; set; }
    }
}
