using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        public int? TypeID { get; set; }

        [Precision(18, 2)]
        public decimal? Amount { get; set; }

        public string? Method { get; set; }

        public string? RefNo { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("TypeID")]
        public TransTypeModel? TransType { get; set; }

        public ICollection<TransTypeModel>? TransTypes { get; set; }
    }
}
