using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class BonusDto
    {
        public int JobDescriptionId { get; set; }
        public string BonusName { get; set; }
        public decimal Amount { get; set; }
    }
}
