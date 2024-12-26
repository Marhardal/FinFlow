using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        
        public int? SelectedItemId { get; set; } // For the selected category

        public ICollection<ItemsModel> items { get; set; } = new List<ItemsModel>();

        [Precision(16,2)]
        public decimal Amount { get; set; }

        public double Quantity { get; set; }

        public string Notes { get; set; } = string.Empty;

        public DateTime? Date { get; set; } = default(DateTime?);

        [ForeignKey("SelectedItemId")]
        public ItemsModel? Item { get; set; } // Navigation property
    }
}
