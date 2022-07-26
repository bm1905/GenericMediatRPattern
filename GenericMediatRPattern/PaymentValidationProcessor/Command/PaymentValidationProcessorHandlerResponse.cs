namespace GenericMediatRPattern.PaymentValidationProcessor.Command
{
    public class PaymentValidationProcessorHandlerResponse
    {
        public PaymentValidationProcessorResponse Response { get; }

        public PaymentValidationProcessorHandlerResponse(PaymentValidationProcessorResponse response)
        {
            Response = response;
        }
    }
}
