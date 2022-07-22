using System.Threading.Tasks;
using MediatRPattern.Data;
using Newtonsoft.Json;

namespace MediatRPattern.PaymentManager
{
    public class PaymentManager<TEntity> : IPaymentManager<TEntity>
    {
        private readonly Database _database;

        public PaymentManager(Database database)
        {
            _database = database;
        }

        public async Task<TEntity> GetPayment(string paymentKey)
        {
            if (_database.Data.ContainsKey(paymentKey))
            {
                var response = _database.Data[paymentKey];
                var responseJson = JsonConvert.DeserializeObject<TEntity>(response);
                await Task.Delay(1);
                return responseJson;
            }

            return default;
        }

        public async Task<bool> SetPayment(string key, TEntity entityModel)
        {
            var model = JsonConvert.SerializeObject(entityModel);
            _database.Data.Add(key, model);
            await Task.Delay(1);
            return true;
        }
    }
}
