namespace API.Dtos
{
    public class BonusDto
    {
        public int JobDescriptionId { get; set; }
        public string BonusName { get; set; }
        public decimal Amount { get; set; }
        public string JobDescriptionName { get; set; }
        public string DepartmentName { get; set; }
    }
}