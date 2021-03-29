namespace API.Dtos
{
    public class LeaveTypeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public bool Status { get; set; }
    }
}