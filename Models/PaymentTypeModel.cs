namespace FinFlow.Models
{
    public class PaymentTypeModel
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public TransactionModel? Transaction { get; set; }
    }
}
