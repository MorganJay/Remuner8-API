using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Bonus
    {
        public int JobDescriptionId { get; set; }
        public int DepartmentId { get; set; }
        public decimal BonusName { get; set; }
        public decimal Amount { get; set; }

        public virtual Department Department { get; set; }
        public virtual JobDescription JobDescription { get; set; }
    }
}
