using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Password
    {
        public string Email { get; set; }
        public string Password1 { get; set; }

        public virtual EmployeeBiodata EmployeeBiodata { get; set; }
    }
}
