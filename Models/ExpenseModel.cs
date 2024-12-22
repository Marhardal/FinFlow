using Microsoft.EntityFrameworkCore;

namespace FinFlow.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        [Precision(16,2)]
        public decimal Amount { get; set; }

        public decimal Notes { get; set; }

        public DateTime Date { get; set; }
    }
}
