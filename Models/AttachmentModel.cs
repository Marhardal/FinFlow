using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class AttachmentModel
    {
        public int Id { get; set; }

        public int TransactionID { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public string Type { get; set; } = "Image";

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();

        [ForeignKey("TransactionID")]
        public TransactionModel? Transaction { get; set; }
    }
}
