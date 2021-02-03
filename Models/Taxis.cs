using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class Taxis
    {
        public string EmployeeId { get; set; }
        public decimal? Paye { get; set; }
        public decimal? Pension { get; set; }

        public virtual EmployeeBiodatum Employee { get; set; }
    }
}
