using System.Collections.Generic;
using MediatR;

namespace GenericMediatRPattern.PaymentService.Query
{
    public class PaymentManagerGetAllHandlerRequest<T> : IRequest<List<PaymentManagerGetHandlerResponse<T>>>
    {
    }
}



