namespace GenericMediatRPattern.Models
{
    public class CashPaymentModel : LocaleModel
    {
        public int TotalBillCount { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentBy { get; set; }
        public string PaymentFor { get; set; }
        public string Notes { get; set; }
    }
}
