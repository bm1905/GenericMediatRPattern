using MediatR;

namespace GenericMediatRPattern.PaymentValidationProcessor.Command
{
    public class PaymentValidationProcessorHandlerRequest : IRequest<PaymentValidationProcessorHandlerResponse>
    {
        public string Key { get; set; }
        public string Locale { get; set; }

        public PaymentValidationProcessorHandlerRequest(string key, string locale)
        {
            Key = key;
            Locale = locale;
        }
    }
}
