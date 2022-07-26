using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GenericMediatRPattern.PaymentManager;
using MediatR;

namespace GenericMediatRPattern.PaymentService.Query
{
    public class PaymentManagerGetAllHandler<T> : IRequestHandler<PaymentManagerGetAllHandlerRequest<T>, List<PaymentManagerGetHandlerResponse<T>>>
    {
        private readonly IPaymentManager<T> _model;

        public PaymentManagerGetAllHandler(IPaymentManager<T> model)
        {
            _model = model;
        }

        public async Task<List<PaymentManagerGetHandlerResponse<T>>> Handle(PaymentManagerGetAllHandlerRequest<T> request, CancellationToken cancellationToken)
        {
            var responses = await _model.GetAllPayments();
            List<PaymentManagerGetHandlerResponse<T>> response = new List<PaymentManagerGetHandlerResponse<T>>();
            foreach (var model in responses)
            {
                var value = new PaymentManagerGetHandlerResponse<T>(model);
                response.Add(value);
            }
            return new List<PaymentManagerGetHandlerResponse<T>>(response);
        }
    }
}

