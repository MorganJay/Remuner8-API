using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data_Models.Dtos
{
    public class PayrollAdditionItemReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        public int AssigneeId { get; set; }
    }
}
