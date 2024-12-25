using Microsoft.EntityFrameworkCore;

namespace FinFlow.Models
{
    public class BudgetModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool Status { get; set; } = default(bool);

        [Precision(16, 2)]
        public decimal Amount { get; set; } = decimal.Zero;

        public DateTime? CreatedDate { get; set; } = default(DateTime?);
    }
}
