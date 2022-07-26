using System;
using System.Threading;
using System.Threading.Tasks;
using GenericMediatRPattern.PluginHandler;
using MediatR;

namespace GenericMediatRPattern.PaymentValidationProcessor.Command
{
    public class PaymentValidationProcessorHandler : IRequestHandler<PaymentValidationProcessorHandlerRequest, PaymentValidationProcessorHandlerResponse>
    {
        private readonly PluginFactory _pluginFactory;

        public PaymentValidationProcessorHandler(PluginFactory pluginFactory)
        {
            _pluginFactory = pluginFactory;
        }

        public async Task<PaymentValidationProcessorHandlerResponse> Handle(PaymentValidationProcessorHandlerRequest request, CancellationToken cancellationToken)
        {
            var service = _pluginFactory.GetService<IPaymentValidationProcessor>(request.Locale);
            if (service == null)
            {
                throw new ApplicationException("Something went wrong while loading plugin!");
            }
            var response = await service.ValidateAndProcessPayment(request.Key);
            return new PaymentValidationProcessorHandlerResponse(response);
        }
    }
}
