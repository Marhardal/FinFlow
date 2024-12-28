using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class IncomeModel
    {
        public int Id { get; set; }

        public int? incCategoryID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [Precision(18, 2)]
        public decimal Amount { get; set; }

        public bool Status { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<IncomeCategoryModel> IncomeCategories { get; set; } = new List<IncomeCategoryModel>();
        
        //public ICollection<IncomeModel> Incomes{ get; set; } = new List<IncomeModel>();

        [ForeignKey("incCategoryID")]
        public IncomeCategoryModel? incomeCategory { get; set; }
    }
}
