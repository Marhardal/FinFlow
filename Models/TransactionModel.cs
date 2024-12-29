using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        public int? TypeID { get; set; }

        public int? PaymentTypeID { get; set; }

        public int? LinkedEntityId { get; set; }

        [Precision(18, 2)]
        public decimal Amount { get; set; } = decimal.Zero;

        public string? RefNo { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("TypeID")]
        public TransTypeModel? TransType { get; set; }

        [ForeignKey("PaymentTypeID")]
        public PaymentTypeModel? PaymentType { get; set; }

        public TransTypeModel? TransTypes { get; set; }

        public ICollection<AttachmentModel>? Attachments { get; set; }

    }
}
