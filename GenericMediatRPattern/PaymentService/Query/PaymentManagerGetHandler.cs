using System.Threading;
using System.Threading.Tasks;
using GenericMediatRPattern.PaymentManager;
using MediatR;

namespace GenericMediatRPattern.PaymentService.Query
{
    public class PaymentManagerGetHandler<T> : IRequestHandler<PaymentManagerGetHandlerRequest<T>, PaymentManagerGetHandlerResponse<T>>
    {
        private readonly IPaymentManager _model;

        public PaymentManagerGetHandler(IPaymentManager model)
        {
            _model = model;
        }

        public async Task<PaymentManagerGetHandlerResponse<T>> Handle(PaymentManagerGetHandlerRequest<T> request, CancellationToken cancellationToken)
        {
            var response = await _model.GetPayment<T>(request.Key);
            return new PaymentManagerGetHandlerResponse<T>(response);
        }
    }
}