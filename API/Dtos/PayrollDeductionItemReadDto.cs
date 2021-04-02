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