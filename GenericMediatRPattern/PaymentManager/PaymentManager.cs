using System.Collections.Generic;
using System.Threading.Tasks;
using GenericMediatRPattern.Data;
using Newtonsoft.Json;

namespace GenericMediatRPattern.PaymentManager
{
    public class PaymentManager : IPaymentManager
    {
        private readonly Database _database;

        public PaymentManager(Database database)
        {
            _database = database;
        }

        public async Task<List<TEntity>> GetAllPayments<TEntity>()
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (var data in _database.Data)
            {
                var response = _database.Data[data.Key];
                var responseJson = JsonConvert.DeserializeObject<TEntity>(response);
                entities.Add(responseJson);
            }
            await Task.Delay(1);
            return entities;
        }

        public async Task<TEntity> GetPayment<TEntity>(string paymentKey)
        {
            if (!_database.Data.ContainsKey(paymentKey)) return default;

            var response = _database.Data[paymentKey];
            var responseJson = JsonConvert.DeserializeObject<TEntity>(response);
            await Task.Delay(1);
            return responseJson;

        }

        public async Task<bool> SetPayment<TEntity>(string key, TEntity entityModel)
        {
            var model = JsonConvert.SerializeObject(entityModel);
            _database.Data.Add(key, model);
            await Task.Delay(1);
            return true;
        }
    }
}
