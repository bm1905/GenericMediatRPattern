namespace GenericMediatRPattern.PaymentService.Command
{
    public class PaymentManagerSetHandlerResponse
    {
        public bool Result { get; }

        public PaymentManagerSetHandlerResponse(bool result)
        {
            Result = result;
        }
    }
}
