using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmploymentTypeReadDto
    {
      
        [Column("employmentTypeId")]
        public int EmploymentTypeId { get; set; }
       
        [Column("employmentName")]
    
        public string EmploymentName { get; set; }
    }
}
