using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class JobDescription
    {
        public JobDescription()
        {
            EmployeeBiodatas = new HashSet<EmployeeBiodata>();
        }

        public int JobDescriptionId { get; set; }
        public string JobDescriptionName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal TransportAllowance { get; set; }

        public virtual ICollection<EmployeeBiodata> EmployeeBiodatas { get; set; }
    }
}
