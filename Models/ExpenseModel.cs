using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        
        public int? ItemId { get; set; }

        public int? BudgetID { get; set; } // For the selected category

        public ICollection<ItemsModel> items { get; set; } = new List<ItemsModel>();

        public ICollection<BudgetModel> Budgets { get; set; } = new List<BudgetModel>();

        [Precision(16,2)]
        public decimal Amount { get; set; }

        public double Quantity { get; set; }

        public string Notes { get; set; } = string.Empty;

        public DateTime? Date { get; set; } = default(DateTime?);

        [ForeignKey("ItemId")]
        public ItemsModel? Item { get; set; } // Navigation property

        [ForeignKey("BudgetID")]
        public BudgetModel? Budget { get; set; } // Navigation property
    }
}
