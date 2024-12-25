using Microsoft.EntityFrameworkCore;

namespace FinFlow.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public ICollection<ItemsModel> items { get; set; } = new List<ItemsModel>();

        [Precision(16,2)]
        public decimal Amount { get; set; }

        public decimal Quantity { get; set; }

        public string Notes { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
