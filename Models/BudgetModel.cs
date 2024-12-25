namespace FinFlow.Models
{
    public class BudgetModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; } = default(DateTime?);
    }
}
