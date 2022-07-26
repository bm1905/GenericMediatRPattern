namespace GenericMediatRPattern.PaymentValidationProcessor
{
    public class PaymentValidationProcessorResponse
    {
        public bool IsValid { get; set; }
        public string Locale { get; set; }
    }
}
