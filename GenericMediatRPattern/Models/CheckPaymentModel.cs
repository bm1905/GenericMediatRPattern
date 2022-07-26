namespace GenericMediatRPattern.Models
{
    public class CheckPaymentModel : LocaleModel
    {
        public int CheckNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentBy { get; set; }
        public string PaymentFor { get; set; }
        public string Notes { get; set; }
    }
}
