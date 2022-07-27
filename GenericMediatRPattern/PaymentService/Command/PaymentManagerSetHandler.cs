using System.Threading;
using System.Threading.Tasks;
using GenericMediatRPattern.PaymentManager;
using MediatR;

namespace GenericMediatRPattern.PaymentService.Command
{
    public class PaymentManagerSetHandler<T> : IRequestHandler<PaymentManagerSetHandlerRequest<T>, PaymentManagerSetHandlerResponse>
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentManagerSetHandler(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        public async Task<PaymentManagerSetHandlerResponse> Handle(PaymentManagerSetHandlerRequest<T> request, CancellationToken cancellationToken)
        {
            var response = await _paymentManager.SetPayment(request.Key, request.Model);
            return new PaymentManagerSetHandlerResponse(response);
        }
    }
}
