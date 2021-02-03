using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class Bonuse
    {
        public int JobDescriptionId { get; set; }
        public int DepartmentId { get; set; }
        public decimal BonusName { get; set; }
        public decimal Amount { get; set; }

        public virtual Department Department { get; set; }
        public virtual JobDescription JobDescription { get; set; }
    }
}
