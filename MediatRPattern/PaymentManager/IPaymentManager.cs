﻿using System.Threading.Tasks;

namespace MediatRPattern.PaymentManager
{
    public interface IPaymentManager<TEntity>
    {
        Task<bool> SetPayment(string key, TEntity entityModel);
        Task<TEntity> GetPayment(string key);
    }
}