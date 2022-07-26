using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericMediatRPattern.PaymentManager
{
    public interface IPaymentManager<TEntity>
    {
        Task<bool> SetPayment(string key, TEntity entityModel);
        Task<TEntity> GetPayment(string key);
        Task<List<TEntity>> GetAllPayments();
    }
}
