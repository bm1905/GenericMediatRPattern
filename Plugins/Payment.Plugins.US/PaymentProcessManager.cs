using System;
using System.Threading.Tasks;
using GenericMediatRPattern.PaymentValidationProcessor;
using Microsoft.Extensions.Configuration;

namespace Payment.Plugins.US
{
    public class PaymentProcessManager : IPaymentValidationProcessor
    {
        private readonly IConfiguration _configuration;

        public PaymentProcessManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PaymentValidationProcessorResponse> ValidateAndProcessPayment(string key)
        {
            // Operation based on Locale
            await Task.Delay(1);
            int random = new Random().Next();
            PaymentValidationProcessorResponse response = new PaymentValidationProcessorResponse
            {
                Locale = "US",
                IsValid = random % 2 == 0
            };

            return response;
        }
    }
}
