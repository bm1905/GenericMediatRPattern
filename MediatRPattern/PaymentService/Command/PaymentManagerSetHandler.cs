﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRPattern.PaymentManager;

namespace MediatRPattern.Command.PaymentService
{
    public class PaymentManagerSetHandler<T> : IRequestHandler<PaymentManagerSetHandlerRequest<T>, PaymentManagerSetHandlerResponse>
    {
        private readonly IPaymentManager<T> _paymentModel;
        
        public PaymentManagerSetHandler(IPaymentManager<T> paymentModel)
        {
            _paymentModel = paymentModel;
        }

        public async Task<PaymentManagerSetHandlerResponse> Handle(PaymentManagerSetHandlerRequest<T> request, CancellationToken cancellationToken)
        {
            var response = await _paymentModel.SetPayment(request.Key, request.Model);
            return new PaymentManagerSetHandlerResponse(response);
        }
    }
}
