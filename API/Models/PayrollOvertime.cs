using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class PayrollOvertime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rateid { get; set; }
        public decimal Rate { get; set; }
    }
}
