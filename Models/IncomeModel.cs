using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class IncomeModel
    {
        public int Id { get; set; }

        public int? CategoryID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [Precision(18, 2)]
        public decimal Amount { get; set; }

        public DateOnly Date { get; set; } = default(DateOnly);

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<IncomeCategoryModel>? IncomeCategories { get; set; }

        [ForeignKey("CategoryID")]
        public IncomeCategoryModel? incomeCategory { get; set; }
    }
}
