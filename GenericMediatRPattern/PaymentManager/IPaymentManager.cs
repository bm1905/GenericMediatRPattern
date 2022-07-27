using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericMediatRPattern.PaymentManager
{
    public interface IPaymentManager
    {
        Task<bool> SetPayment<TEntity>(string key, TEntity entityModel);
        Task<TEntity> GetPayment<TEntity>(string key);
        Task<List<TEntity>> GetAllPayments<TEntity>();
    }
}
