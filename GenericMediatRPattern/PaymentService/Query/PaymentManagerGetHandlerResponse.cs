namespace GenericMediatRPattern.PaymentService.Query
{
    public class PaymentManagerGetHandlerResponse<T>
    {
        public T Model { get; }

        public PaymentManagerGetHandlerResponse(T model)
        {
            Model = model;
        }
    }
}
