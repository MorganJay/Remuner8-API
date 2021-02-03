using System;
using System.Collections.Generic;

#nullable disable

namespace Remuner8.Models
{
    public partial class Password
    {
        public string Email { get; set; }
        public string Password1 { get; set; }

        public virtual EmployeeBiodatum EmployeeBiodatum { get; set; }
    }
}
