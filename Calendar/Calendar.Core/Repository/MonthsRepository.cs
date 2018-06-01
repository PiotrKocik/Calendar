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
    public class MonthsRepository : IMonthsRepository
    {
        private PaymentDbContext paymentDbContext;
        public MonthsRepository(PaymentDbContext paymentDbContext)
        {
            this.paymentDbContext = paymentDbContext;
        }

        public async Task Delete(Months months)
        {
            paymentDbContext.Months.Remove(months);
            await Task.CompletedTask;
        }

        public async Task<Months> Get(int id)
        {
            return await paymentDbContext.Months.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Months> GetByName(string name)
        {
            return await paymentDbContext.Months.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Months>> GetAll()
        {
            return await paymentDbContext.Months.ToListAsync();
        }

        public async Task SaveChanges()
        {
            paymentDbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task Update(Months months)
        {
            paymentDbContext.Entry(months).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
