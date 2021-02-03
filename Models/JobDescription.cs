using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class JobDescription
    {
        public JobDescription()
        {
            EmployeeBiodata = new HashSet<EmployeeBiodatum>();
        }

        public int JobDescriptionId { get; set; }
        public string JobDescriptionName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal TransportAllowance { get; set; }

        public virtual ICollection<EmployeeBiodatum> EmployeeBiodata { get; set; }
    }
}
