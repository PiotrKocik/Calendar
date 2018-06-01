using Calendar.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Core.Repository.Abstract
{
    public interface IPaymentRepository
    {
        Task<Payments> Get(int id);
        Task SaveChanges();
        Task Add(Payments payments);
        Task Delete(Payments payments);
        Task<IEnumerable<Payments>> GetAll();
        Task<IEnumerable<Payments>> GetFilteredPayments(string name);
        Task Update(Payments payments);
        void Dispose();
    }
}
