using MediatR;

namespace GenericMediatRPattern.PaymentService.Query
{
    public class PaymentManagerGetHandlerRequest<T> : IRequest<PaymentManagerGetHandlerResponse<T>>
    {
        public string Key { get; set; }

        public PaymentManagerGetHandlerRequest(string key)
        {
            Key = key;
        }
    }
}
