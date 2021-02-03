using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class Department
    {
        public Department()
        {
            EmployeeBiodata = new HashSet<EmployeeBiodatum>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<EmployeeBiodatum> EmployeeBiodata { get; set; }
    }
}
