using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRPattern.PaymentManager;

namespace MediatRPattern.Query.PaymentService
{
    public class PaymentManagerGetHandler<T> : IRequestHandler<PaymentManagerGetHandlerRequest<T>, PaymentManagerGetHandlerResponse<T>>
    {
        private readonly IPaymentManager<T> _model;

        public PaymentManagerGetHandler(IPaymentManager<T> model)
        {
            _model = model;
        }

        public async Task<PaymentManagerGetHandlerResponse<T>> Handle(PaymentManagerGetHandlerRequest<T> request, CancellationToken cancellationToken)
        {
            var response = await _model.GetPayment(request.Key);
            return new PaymentManagerGetHandlerResponse<T>(response);
        }
    }
}