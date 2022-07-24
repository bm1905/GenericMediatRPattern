using MediatR;

namespace GenericMediatRPattern.PaymentService.Command
{
    public class PaymentManagerSetHandlerRequest<T> : IRequest<PaymentManagerSetHandlerResponse>
    {
        public T Model { get; private set; }
        public string Key { get; set; }

        public PaymentManagerSetHandlerRequest(string key, T model)
        {
            Key = key;
            Model = model;
        }
    }
}
