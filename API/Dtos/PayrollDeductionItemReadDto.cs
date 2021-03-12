using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PayrollDeductionItemReadDto
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Amount { get; set; }
       
        public int AssigneeId { get; set; }
    }
}
