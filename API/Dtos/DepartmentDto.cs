using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}