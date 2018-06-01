using Calendar.Core.Models;
using Calendar.Infrastructure.Services.Abstract;
using System;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static async Task<Payments> GetOrFail(this IPaymentService paymentService, int id)
        {
            var payment = await paymentService.Get(id);
            if(payment == null)
            {
                throw new Exception($"Event with id: '{id}' does not exist.");
            }
            return payment;
        }
    }
}
