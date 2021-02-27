using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class PayrollAdditionItem
    {
        public PayrollAdditionItem()
        {
            EmployeeBiodatas = new HashSet<EmployeeBiodata>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<EmployeeBiodata> EmployeeBiodatas { get; set; }
    }
}
