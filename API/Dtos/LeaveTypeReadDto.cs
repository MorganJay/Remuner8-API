using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class LeaveTypeReadDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public bool Status { get; set; }
    }
}
