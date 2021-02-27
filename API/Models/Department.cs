using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Department
    {
        public Department()
        {
            EmployeeBiodatas = new HashSet<EmployeeBiodata>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<EmployeeBiodata> EmployeeBiodatas { get; set; }
    }
}
