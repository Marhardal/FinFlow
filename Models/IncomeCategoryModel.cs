namespace FinFlow.Models
{
    public class IncomeCategoryModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<IncomeModel>? incomes { get; set; }
    }
}
