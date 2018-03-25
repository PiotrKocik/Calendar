using Calendar.Core.Context;
using Calendar.Core.Models;
using Calendar.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Core.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private PaymentDbContext paymentDbContext;
        public PaymentRepository(PaymentDbContext paymentDbContext)
        {
            this.paymentDbContext = paymentDbContext;
        }

        public async Task Add(Payments payments)
        {
            paymentDbContext.Payments.Add(payments);
            await Task.CompletedTask;
        }

        public async Task Delete(Payments payments)
        {
            paymentDbContext.Payments.Remove(payments);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            paymentDbContext.Dispose();
        }

        public async Task<Payments> Get(Guid id)
        {
            return await paymentDbContext.Payments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Payments>> GetAll()
        {
            return await paymentDbContext.Payments.ToListAsync();
        }

        public async Task SaveChanges()
        {
            paymentDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task Update(Payments payments)
        {
            paymentDbContext.Entry(payments).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
