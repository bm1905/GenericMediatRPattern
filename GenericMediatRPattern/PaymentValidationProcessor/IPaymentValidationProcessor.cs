using System.Threading.Tasks;

namespace GenericMediatRPattern.PaymentValidationProcessor
{
    public interface IPaymentValidationProcessor
    {
        Task<PaymentValidationProcessorResponse> ValidateAndProcessPayment(string key);
    }
}
